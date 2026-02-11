using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CloudDentalOffice.Portal.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InsurancePlans",
                columns: table => new
                {
                    InsurancePlanId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PayerId = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false),
                    PayerName = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    PlanName = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    PlanType = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    Phone = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true),
                    Address1 = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    Address2 = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    City = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    State = table.Column<string>(type: "TEXT", maxLength: 2, nullable: true),
                    ZipCode = table.Column<string>(type: "TEXT", maxLength: 10, nullable: true),
                    EdiPayerId = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsurancePlans", x => x.InsurancePlanId);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    PatientId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    MiddleName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    PreferredName = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Gender = table.Column<string>(type: "TEXT", maxLength: 1, nullable: false),
                    SSN = table.Column<string>(type: "TEXT", maxLength: 11, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    PrimaryPhone = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true),
                    SecondaryPhone = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true),
                    Address1 = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    Address2 = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    City = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    State = table.Column<string>(type: "TEXT", maxLength: 2, nullable: true),
                    ZipCode = table.Column<string>(type: "TEXT", maxLength: 10, nullable: true),
                    Status = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CreatedBy = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    ModifiedBy = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.PatientId);
                });

            migrationBuilder.CreateTable(
                name: "Providers",
                columns: table => new
                {
                    ProviderId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NPI = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    MiddleName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    Suffix = table.Column<string>(type: "TEXT", maxLength: 10, nullable: true),
                    Specialty = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    LicenseNumber = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    LicenseState = table.Column<string>(type: "TEXT", maxLength: 2, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    Phone = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true),
                    TaxId = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Providers", x => x.ProviderId);
                });

            migrationBuilder.CreateTable(
                name: "PatientInsurances",
                columns: table => new
                {
                    PatientInsuranceId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PatientId = table.Column<int>(type: "INTEGER", nullable: false),
                    InsurancePlanId = table.Column<int>(type: "INTEGER", nullable: false),
                    MemberId = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    GroupNumber = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    SequenceNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    EffectiveDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TerminationDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    RelationshipToSubscriber = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true),
                    SubscriberFirstName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    SubscriberLastName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    SubscriberSSN = table.Column<string>(type: "TEXT", maxLength: 11, nullable: true),
                    SubscriberDateOfBirth = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientInsurances", x => x.PatientInsuranceId);
                    table.ForeignKey(
                        name: "FK_PatientInsurances_InsurancePlans_InsurancePlanId",
                        column: x => x.InsurancePlanId,
                        principalTable: "InsurancePlans",
                        principalColumn: "InsurancePlanId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PatientInsurances_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    AppointmentId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PatientId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProviderId = table.Column<int>(type: "INTEGER", nullable: false),
                    AppointmentDateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DurationMinutes = table.Column<int>(type: "INTEGER", nullable: false),
                    AppointmentType = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Status = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Notes = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: true),
                    ReasonForVisit = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.AppointmentId);
                    table.ForeignKey(
                        name: "FK_Appointments_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointments_Providers_ProviderId",
                        column: x => x.ProviderId,
                        principalTable: "Providers",
                        principalColumn: "ProviderId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TreatmentPlans",
                columns: table => new
                {
                    TreatmentPlanId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PatientId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProviderId = table.Column<int>(type: "INTEGER", nullable: false),
                    Status = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Title = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    Description = table.Column<string>(type: "TEXT", maxLength: 2000, nullable: true),
                    PresentedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    AcceptedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CompletedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreatmentPlans", x => x.TreatmentPlanId);
                    table.ForeignKey(
                        name: "FK_TreatmentPlans_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TreatmentPlans_Providers_ProviderId",
                        column: x => x.ProviderId,
                        principalTable: "Providers",
                        principalColumn: "ProviderId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Claims",
                columns: table => new
                {
                    ClaimId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClaimNumber = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    PatientId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProviderId = table.Column<int>(type: "INTEGER", nullable: false),
                    PatientInsuranceId = table.Column<int>(type: "INTEGER", nullable: false),
                    ServiceDateFrom = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ServiceDateTo = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ClaimType = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Status = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    TotalChargeAmount = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    PaidAmount = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    PatientResponsibility = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    EdiControlNumber = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    SubmittedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    SubmittedBy = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    ProcessedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ResponseNotes = table.Column<string>(type: "TEXT", maxLength: 2000, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CreatedBy = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    ModifiedBy = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Claims", x => x.ClaimId);
                    table.ForeignKey(
                        name: "FK_Claims_PatientInsurances_PatientInsuranceId",
                        column: x => x.PatientInsuranceId,
                        principalTable: "PatientInsurances",
                        principalColumn: "PatientInsuranceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Claims_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Claims_Providers_ProviderId",
                        column: x => x.ProviderId,
                        principalTable: "Providers",
                        principalColumn: "ProviderId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClaimProcedures",
                columns: table => new
                {
                    ClaimProcedureId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClaimId = table.Column<int>(type: "INTEGER", nullable: false),
                    CDTCode = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    ServiceDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ToothNumber = table.Column<string>(type: "TEXT", maxLength: 10, nullable: true),
                    Surface = table.Column<string>(type: "TEXT", maxLength: 10, nullable: true),
                    ChargeAmount = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    AllowedAmount = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    PaidAmount = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    Deductible = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    Copay = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    Coinsurance = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    LineNumber = table.Column<int>(type: "INTEGER", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClaimProcedures", x => x.ClaimProcedureId);
                    table.ForeignKey(
                        name: "FK_ClaimProcedures_Claims_ClaimId",
                        column: x => x.ClaimId,
                        principalTable: "Claims",
                        principalColumn: "ClaimId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlannedProcedures",
                columns: table => new
                {
                    PlannedProcedureId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TreatmentPlanId = table.Column<int>(type: "INTEGER", nullable: false),
                    CDTCode = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    ToothNumber = table.Column<string>(type: "TEXT", maxLength: 10, nullable: true),
                    Surface = table.Column<string>(type: "TEXT", maxLength: 10, nullable: true),
                    EstimatedFee = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Status = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    SequenceNumber = table.Column<int>(type: "INTEGER", nullable: true),
                    CompletedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ClaimProcedureId = table.Column<int>(type: "INTEGER", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlannedProcedures", x => x.PlannedProcedureId);
                    table.ForeignKey(
                        name: "FK_PlannedProcedures_ClaimProcedures_ClaimProcedureId",
                        column: x => x.ClaimProcedureId,
                        principalTable: "ClaimProcedures",
                        principalColumn: "ClaimProcedureId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_PlannedProcedures_TreatmentPlans_TreatmentPlanId",
                        column: x => x.TreatmentPlanId,
                        principalTable: "TreatmentPlans",
                        principalColumn: "TreatmentPlanId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "InsurancePlans",
                columns: new[] { "InsurancePlanId", "Address1", "Address2", "City", "CreatedDate", "EdiPayerId", "IsActive", "ModifiedDate", "PayerId", "PayerName", "Phone", "PlanName", "PlanType", "State", "ZipCode" },
                values: new object[,]
                {
                    { 1, "123 Insurance Way", null, "San Francisco", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "BCBS001", true, null, "BCBS", "Blue Cross Blue Shield", "1-800-123-4567", "PPO Standard", "PPO", "CA", "94102" },
                    { 2, "456 Dental Plaza", null, "Los Angeles", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "DELTA001", true, null, "DELTA", "Delta Dental", "1-800-765-4321", "Delta Premier", "PPO", "CA", "90001" }
                });

            migrationBuilder.InsertData(
                table: "Providers",
                columns: new[] { "ProviderId", "CreatedDate", "Email", "FirstName", "IsActive", "LastName", "LicenseNumber", "LicenseState", "MiddleName", "ModifiedDate", "NPI", "Phone", "Specialty", "Suffix", "TaxId" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "dr.johnson@clouddental.com", "Sarah", true, "Johnson", "DDS-12345", "CA", null, null, "1234567890", "555-123-4567", "General Dentistry", "DDS", "12-3456789" },
                    { 2, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "dr.chen@clouddental.com", "Michael", true, "Chen", "DMD-54321", "CA", null, null, "0987654321", "555-987-6543", "Orthodontics", "DMD", "98-7654321" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_AppointmentDateTime",
                table: "Appointments",
                column: "AppointmentDateTime");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_AppointmentDateTime_ProviderId",
                table: "Appointments",
                columns: new[] { "AppointmentDateTime", "ProviderId" });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_PatientId",
                table: "Appointments",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_ProviderId",
                table: "Appointments",
                column: "ProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_ClaimProcedures_CDTCode",
                table: "ClaimProcedures",
                column: "CDTCode");

            migrationBuilder.CreateIndex(
                name: "IX_ClaimProcedures_ClaimId",
                table: "ClaimProcedures",
                column: "ClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_Claims_ClaimNumber",
                table: "Claims",
                column: "ClaimNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Claims_PatientId",
                table: "Claims",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Claims_PatientInsuranceId",
                table: "Claims",
                column: "PatientInsuranceId");

            migrationBuilder.CreateIndex(
                name: "IX_Claims_ProviderId",
                table: "Claims",
                column: "ProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_Claims_Status",
                table: "Claims",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_Claims_SubmittedDate",
                table: "Claims",
                column: "SubmittedDate");

            migrationBuilder.CreateIndex(
                name: "IX_InsurancePlans_PayerId",
                table: "InsurancePlans",
                column: "PayerId");

            migrationBuilder.CreateIndex(
                name: "IX_InsurancePlans_PayerName",
                table: "InsurancePlans",
                column: "PayerName");

            migrationBuilder.CreateIndex(
                name: "IX_PatientInsurances_InsurancePlanId",
                table: "PatientInsurances",
                column: "InsurancePlanId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientInsurances_MemberId",
                table: "PatientInsurances",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientInsurances_PatientId",
                table: "PatientInsurances",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_Email",
                table: "Patients",
                column: "Email");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_LastName",
                table: "Patients",
                column: "LastName");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_LastName_FirstName",
                table: "Patients",
                columns: new[] { "LastName", "FirstName" });

            migrationBuilder.CreateIndex(
                name: "IX_PlannedProcedures_ClaimProcedureId",
                table: "PlannedProcedures",
                column: "ClaimProcedureId");

            migrationBuilder.CreateIndex(
                name: "IX_PlannedProcedures_TreatmentPlanId",
                table: "PlannedProcedures",
                column: "TreatmentPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_Providers_LastName_FirstName",
                table: "Providers",
                columns: new[] { "LastName", "FirstName" });

            migrationBuilder.CreateIndex(
                name: "IX_Providers_NPI",
                table: "Providers",
                column: "NPI",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TreatmentPlans_PatientId",
                table: "TreatmentPlans",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_TreatmentPlans_ProviderId",
                table: "TreatmentPlans",
                column: "ProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_TreatmentPlans_Status",
                table: "TreatmentPlans",
                column: "Status");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "PlannedProcedures");

            migrationBuilder.DropTable(
                name: "ClaimProcedures");

            migrationBuilder.DropTable(
                name: "TreatmentPlans");

            migrationBuilder.DropTable(
                name: "Claims");

            migrationBuilder.DropTable(
                name: "PatientInsurances");

            migrationBuilder.DropTable(
                name: "Providers");

            migrationBuilder.DropTable(
                name: "InsurancePlans");

            migrationBuilder.DropTable(
                name: "Patients");
        }
    }
}
