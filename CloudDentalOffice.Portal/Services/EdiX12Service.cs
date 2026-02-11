using CloudDentalOffice.Portal.Data;
using CloudDentalOffice.Portal.Models;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace CloudDentalOffice.Portal.Services;

/// <summary>
/// Generates HIPAA 5010 X12 837D (Dental) transactions from claim data
/// </summary>
public interface IEdiX12Service
{
    Task<string> Generate837DTransactionAsync(Claim claim);
}

public class EdiX12Service : IEdiX12Service
{
    private readonly CloudDentalDbContext _context;
    private readonly ILogger<EdiX12Service> _logger;
    private const string ELEMENT_SEPARATOR = "*";
    private const string SEGMENT_TERMINATOR = "~\n";
    private const string COMPOSITE_SEPARATOR = ">";

    public EdiX12Service(CloudDentalDbContext context, ILogger<EdiX12Service> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<string> Generate837DTransactionAsync(Claim claim)
    {
        // Load all required relationships
        var fullClaim = await _context.Claims
            .Include(c => c.Patient)
            .Include(c => c.Provider)
            .Include(c => c.PatientInsurance)
                .ThenInclude(pi => pi!.InsurancePlan)
            .Include(c => c.Procedures)
            .FirstOrDefaultAsync(c => c.ClaimId == claim.ClaimId);

        if (fullClaim == null)
            throw new InvalidOperationException($"Claim {claim.ClaimNumber} not found");

        if (fullClaim.Provider == null)
            throw new InvalidOperationException($"Claim {claim.ClaimNumber} has no provider");

        if (fullClaim.Patient == null)
            throw new InvalidOperationException($"Claim {claim.ClaimNumber} has no patient");

        if (fullClaim.PatientInsurance?.InsurancePlan == null)
            throw new InvalidOperationException($"Claim {claim.ClaimNumber} has no insurance plan");

        var x12 = new StringBuilder();

        // Generate unique control numbers
        var interchangeControlNumber = GenerateControlNumber();
        var groupControlNumber = GenerateControlNumber();
        var transactionControlNumber = GenerateControlNumber();
        var submitterIdentifier = "123456789"; // Practice/submitter tax ID
        var receiverIdentifier = fullClaim.PatientInsurance.InsurancePlan.EdiPayerId ?? fullClaim.PatientInsurance.InsurancePlan.PayerId;

        // ISA - Interchange Control Header
        x12.Append(BuildISASegment(submitterIdentifier, receiverIdentifier, interchangeControlNumber));

        // GS - Functional Group Header
        x12.Append(BuildGSSegment(submitterIdentifier, receiverIdentifier, groupControlNumber));

        // ST - Transaction Set Header
        x12.Append($"ST{ELEMENT_SEPARATOR}837{ELEMENT_SEPARATOR}{transactionControlNumber}{ELEMENT_SEPARATOR}005010X224A2{SEGMENT_TERMINATOR}");

        // BHT - Beginning of Hierarchical Transaction
        var bhtDate = DateTime.Now.ToString("yyyyMMdd");
        var bhtTime = DateTime.Now.ToString("HHmm");
        x12.Append($"BHT{ELEMENT_SEPARATOR}0019{ELEMENT_SEPARATOR}00{ELEMENT_SEPARATOR}{fullClaim.ClaimNumber}{ELEMENT_SEPARATOR}{bhtDate}{ELEMENT_SEPARATOR}{bhtTime}{ELEMENT_SEPARATOR}CH{SEGMENT_TERMINATOR}");

        // 1000A Loop - Submitter (Dental Office)
        x12.Append($"NM1{ELEMENT_SEPARATOR}41{ELEMENT_SEPARATOR}2{ELEMENT_SEPARATOR}CLOUD DENTAL OFFICE{ELEMENT_SEPARATOR}{ELEMENT_SEPARATOR}{ELEMENT_SEPARATOR}{ELEMENT_SEPARATOR}{ELEMENT_SEPARATOR}46{ELEMENT_SEPARATOR}{submitterIdentifier}{SEGMENT_TERMINATOR}");
        x12.Append($"PER{ELEMENT_SEPARATOR}IC{ELEMENT_SEPARATOR}BILLING DEPT{ELEMENT_SEPARATOR}TE{ELEMENT_SEPARATOR}5555551234{SEGMENT_TERMINATOR}");

        // 1000B Loop - Receiver (Payer)
        x12.Append($"NM1{ELEMENT_SEPARATOR}40{ELEMENT_SEPARATOR}2{ELEMENT_SEPARATOR}{fullClaim.PatientInsurance.InsurancePlan.PayerName}{ELEMENT_SEPARATOR}{ELEMENT_SEPARATOR}{ELEMENT_SEPARATOR}{ELEMENT_SEPARATOR}{ELEMENT_SEPARATOR}46{ELEMENT_SEPARATOR}{receiverIdentifier}{SEGMENT_TERMINATOR}");

        // 2000A Loop - Billing Provider Hierarchical Level
        x12.Append($"HL{ELEMENT_SEPARATOR}1{ELEMENT_SEPARATOR}{ELEMENT_SEPARATOR}20{ELEMENT_SEPARATOR}1{SEGMENT_TERMINATOR}");
        
        // 2010AA Loop - Billing Provider Name
        var providerNPI = fullClaim.Provider.NPI ?? "0000000000";
        var providerName = $"{fullClaim.Provider.LastName}{ELEMENT_SEPARATOR}{fullClaim.Provider.FirstName}";
        x12.Append($"NM1{ELEMENT_SEPARATOR}85{ELEMENT_SEPARATOR}1{ELEMENT_SEPARATOR}{providerName}{ELEMENT_SEPARATOR}{ELEMENT_SEPARATOR}{ELEMENT_SEPARATOR}{ELEMENT_SEPARATOR}{ELEMENT_SEPARATOR}XX{ELEMENT_SEPARATOR}{providerNPI}{SEGMENT_TERMINATOR}");
        x12.Append($"N3{ELEMENT_SEPARATOR}123 DENTAL PLAZA{SEGMENT_TERMINATOR}");
        x12.Append($"N4{ELEMENT_SEPARATOR}ANYTOWN{ELEMENT_SEPARATOR}CA{ELEMENT_SEPARATOR}90210{SEGMENT_TERMINATOR}");
        x12.Append($"REF{ELEMENT_SEPARATOR}EI{ELEMENT_SEPARATOR}{submitterIdentifier}{SEGMENT_TERMINATOR}"); // Tax ID

        // 2000B Loop - Subscriber Hierarchical Level
        x12.Append($"HL{ELEMENT_SEPARATOR}2{ELEMENT_SEPARATOR}1{ELEMENT_SEPARATOR}22{ELEMENT_SEPARATOR}0{SEGMENT_TERMINATOR}");
        x12.Append($"SBR{ELEMENT_SEPARATOR}P{ELEMENT_SEPARATOR}18{ELEMENT_SEPARATOR}{ELEMENT_SEPARATOR}{ELEMENT_SEPARATOR}{ELEMENT_SEPARATOR}{ELEMENT_SEPARATOR}{ELEMENT_SEPARATOR}{ELEMENT_SEPARATOR}MB{SEGMENT_TERMINATOR}");

        // 2010BA Loop - Subscriber Name (Assuming patient is subscriber for now)
        var patientName = $"{fullClaim.Patient.LastName}{ELEMENT_SEPARATOR}{fullClaim.Patient.FirstName}";
        var memberId = fullClaim.PatientInsurance.MemberId ?? fullClaim.Patient.PatientId.ToString();
        x12.Append($"NM1{ELEMENT_SEPARATOR}IL{ELEMENT_SEPARATOR}1{ELEMENT_SEPARATOR}{patientName}{ELEMENT_SEPARATOR}{ELEMENT_SEPARATOR}{ELEMENT_SEPARATOR}{ELEMENT_SEPARATOR}{ELEMENT_SEPARATOR}MI{ELEMENT_SEPARATOR}{memberId}{SEGMENT_TERMINATOR}");
        x12.Append($"N3{ELEMENT_SEPARATOR}{fullClaim.Patient.Address1 ?? "UNKNOWN"}{SEGMENT_TERMINATOR}");
        x12.Append($"N4{ELEMENT_SEPARATOR}{fullClaim.Patient.City ?? "UNKNOWN"}{ELEMENT_SEPARATOR}{fullClaim.Patient.State ?? "CA"}{ELEMENT_SEPARATOR}{fullClaim.Patient.ZipCode ?? "00000"}{SEGMENT_TERMINATOR}");
        x12.Append($"DMG{ELEMENT_SEPARATOR}D8{ELEMENT_SEPARATOR}{fullClaim.Patient.DateOfBirth:yyyyMMdd}{ELEMENT_SEPARATOR}{(fullClaim.Patient.Gender == "Male" ? "M" : "F")}{SEGMENT_TERMINATOR}");

        // 2010BB Loop - Payer Name
        x12.Append($"NM1{ELEMENT_SEPARATOR}PR{ELEMENT_SEPARATOR}2{ELEMENT_SEPARATOR}{fullClaim.PatientInsurance.InsurancePlan.PayerName}{ELEMENT_SEPARATOR}{ELEMENT_SEPARATOR}{ELEMENT_SEPARATOR}{ELEMENT_SEPARATOR}{ELEMENT_SEPARATOR}PI{ELEMENT_SEPARATOR}{receiverIdentifier}{SEGMENT_TERMINATOR}");

        // 2300 Loop - Claim Information
        var claimAmount = fullClaim.TotalChargeAmount.ToString("F2");
        var placeOfService = "11"; // Office
        x12.Append($"CLM{ELEMENT_SEPARATOR}{fullClaim.ClaimNumber}{ELEMENT_SEPARATOR}{claimAmount}{ELEMENT_SEPARATOR}{ELEMENT_SEPARATOR}{ELEMENT_SEPARATOR}{placeOfService}:B:1{ELEMENT_SEPARATOR}Y{ELEMENT_SEPARATOR}A{ELEMENT_SEPARATOR}Y{ELEMENT_SEPARATOR}Y{SEGMENT_TERMINATOR}");
        x12.Append($"DTP{ELEMENT_SEPARATOR}472{ELEMENT_SEPARATOR}RD8{ELEMENT_SEPARATOR}{fullClaim.ServiceDateFrom:yyyyMMdd}-{fullClaim.ServiceDateTo:yyyyMMdd}{SEGMENT_TERMINATOR}");

        // 2310A Loop - Rendering Provider (same as billing for now)
        x12.Append($"NM1{ELEMENT_SEPARATOR}82{ELEMENT_SEPARATOR}1{ELEMENT_SEPARATOR}{providerName}{ELEMENT_SEPARATOR}{ELEMENT_SEPARATOR}{ELEMENT_SEPARATOR}{ELEMENT_SEPARATOR}{ELEMENT_SEPARATOR}XX{ELEMENT_SEPARATOR}{providerNPI}{SEGMENT_TERMINATOR}");

        // 2400 Loops - Service Lines
        int lineNumber = 1;
        foreach (var procedure in fullClaim.Procedures)
        {
            var procedureAmount = procedure.ChargeAmount.ToString("F2");
            x12.Append($"LX{ELEMENT_SEPARATOR}{lineNumber}{SEGMENT_TERMINATOR}");
            x12.Append($"SV3{ELEMENT_SEPARATOR}AD:{procedure.CDTCode}{ELEMENT_SEPARATOR}{procedureAmount}{ELEMENT_SEPARATOR}UN{ELEMENT_SEPARATOR}1{ELEMENT_SEPARATOR}{ELEMENT_SEPARATOR}{ELEMENT_SEPARATOR}{procedure.ToothNumber ?? ""}{SEGMENT_TERMINATOR}");
            x12.Append($"DTP{ELEMENT_SEPARATOR}472{ELEMENT_SEPARATOR}D8{ELEMENT_SEPARATOR}{procedure.ServiceDate:yyyyMMdd}{SEGMENT_TERMINATOR}");
            lineNumber++;
        }

        // SE - Transaction Set Trailer
        var segmentCount = x12.ToString().Split('~').Length;
        x12.Append($"SE{ELEMENT_SEPARATOR}{segmentCount}{ELEMENT_SEPARATOR}{transactionControlNumber}{SEGMENT_TERMINATOR}");

        // GE - Functional Group Trailer
        x12.Append($"GE{ELEMENT_SEPARATOR}1{ELEMENT_SEPARATOR}{groupControlNumber}{SEGMENT_TERMINATOR}");

        // IEA - Interchange Control Trailer
        x12.Append($"IEA{ELEMENT_SEPARATOR}1{ELEMENT_SEPARATOR}{interchangeControlNumber}{SEGMENT_TERMINATOR}");

        _logger.LogInformation("Generated 837D transaction for claim {ClaimNumber}, {SegmentCount} segments",
            fullClaim.ClaimNumber, segmentCount);

        return x12.ToString();
    }

    private string BuildISASegment(string senderId, string receiverId, string controlNumber)
    {
        var now = DateTime.Now;
        var date = now.ToString("yyMMdd");
        var time = now.ToString("HHmm");

        return $"ISA{ELEMENT_SEPARATOR}00{ELEMENT_SEPARATOR}          {ELEMENT_SEPARATOR}00{ELEMENT_SEPARATOR}          " +
               $"{ELEMENT_SEPARATOR}ZZ{ELEMENT_SEPARATOR}{senderId.PadRight(15)}" +
               $"{ELEMENT_SEPARATOR}ZZ{ELEMENT_SEPARATOR}{receiverId.PadRight(15)}" +
               $"{ELEMENT_SEPARATOR}{date}{ELEMENT_SEPARATOR}{time}" +
               $"{ELEMENT_SEPARATOR}^{ELEMENT_SEPARATOR}00501{ELEMENT_SEPARATOR}{controlNumber.PadLeft(9, '0')}" +
               $"{ELEMENT_SEPARATOR}0{ELEMENT_SEPARATOR}P{ELEMENT_SEPARATOR}:{SEGMENT_TERMINATOR}";
    }

    private string BuildGSSegment(string senderId, string receiverId, string controlNumber)
    {
        var now = DateTime.Now;
        var date = now.ToString("yyyyMMdd");
        var time = now.ToString("HHmm");

        return $"GS{ELEMENT_SEPARATOR}HC{ELEMENT_SEPARATOR}{senderId}{ELEMENT_SEPARATOR}{receiverId}" +
               $"{ELEMENT_SEPARATOR}{date}{ELEMENT_SEPARATOR}{time}" +
               $"{ELEMENT_SEPARATOR}{controlNumber}{ELEMENT_SEPARATOR}X{ELEMENT_SEPARATOR}005010X224A2{SEGMENT_TERMINATOR}";
    }

    private string GenerateControlNumber()
    {
        // Generate a unique 9-digit control number
        return Random.Shared.Next(100000000, 999999999).ToString();
    }
}
