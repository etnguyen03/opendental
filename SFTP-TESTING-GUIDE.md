# CloudHealthOffice SFTP EDI Testing Guide

## ✅ Configuration Complete

Blue Cross Blue Shield has been configured with your CloudHealthOffice SFTP credentials:
- **Host:** sftp.cloudhealthoffice.com
- **Username:** clouddentaloffice
- **Remote Path:** /tenants/clouddentaloffice/dental-claims/inbound/837/
- **Status:** ✅ Ready for testing

## 🧪 Testing Steps

### 1. Verify Configuration in UI
Navigate to: http://localhost:5001/payers

You should see:
- **Blue Cross Blue Shield** listed
- **EDI Status:** ✅ Enabled (green badge)
- **Submission Type:** 🔵 SFTP chip

**Test Connection:**
1. Click the settings icon ⚙️ next to Blue Cross Blue Shield
2. Review the SFTP Settings tab (credentials should be pre-filled)
3. Click the **Cable icon** 🔌 to test connection
4. Should see: "Successfully connected to Blue Cross Blue Shield!"

### 2. Submit a Test Claim

**Option A: Submit Existing Claim (CLM-2026-0001)**
1. Navigate to **EDI & Claims → Claims (837D)**
2. Find claim **CLM-2026-0001** (Status: Submitted or Draft)
3. Click the green **Submit** arrow ➡️
4. System will:
   - Generate X12 837D transaction
   - Upload to: `/tenants/clouddentaloffice/dental-claims/inbound/837/837D_CLM-2026-0001_YYYYMMDD_HHMMSS.x12`
   - Update status to "Submitted"
   - Display success notification

**Option B: Create New Claim**
1. Go to **Claims** page
2. Click **Create New Claim**
3. Follow the 4-step wizard:
   - **Step 1:** Select patient (Mark McCloud)
   - **Step 2:** Select provider (Dr. Sarah Johnson or Dr. Michael Chen)
   - **Step 3:** Add procedures (use quick-add chips: D0120-Exam, D1110-Cleaning, etc.)
   - **Step 4:** Review and Submit
4. Click **Submit to EDI**

### 3. Verify SFTP Upload

**Connect to CloudHealthOffice SFTP:**
```bash
sftp clouddentaloffice@sftp.cloudhealthoffice.com
# Password: $SFTP_PASSWORD (stored in Azure Key Vault)
```

**Check for uploaded file:**
```bash
cd dental-claims/inbound/837/
ls -lh
```

You should see files like:
```
837D_CLM-2026-0001_20260210_143052.x12
837D_CLM-2026-0002_20260210_143215.x12
```

**Download and inspect X12 file:**
```bash
get 837D_CLM-2026-0001_*.x12 /tmp/
exit
```

**View X12 content:**
```bash
cat /tmp/837D_CLM-2026-0001_*.x12
```

You should see HIPAA 5010 X12 837D format:
```
ISA*00*          *00*          *ZZ*123456789      *ZZ*BCBS001        *...
GS*HC*123456789*BCBS001*...
ST*837*...
BHT*0019*00*CLM-2026-0001*...
...
```

### 4. Monitor CloudHealthOffice Processing

CloudHealthOffice Argo workflows will:
1. **Detect** new file in `inbound/837/` (within 30 seconds)
2. **Scrub** the X12 for validation errors
3. **Adjudicate** the claim
4. **Generate** 835 remittance advice
5. **Place** response in `outbound/835/`

**Check for responses:**
```bash
sftp clouddentaloffice@sftp.cloudhealthoffice.com
cd dental-claims/outbound/835/
ls -lh
get remittance-*.x12
```

### 5. Expected X12 Output

**Sample 837D structure CloudDentalOffice generates:**
```
ISA*00*          *00*          *ZZ*123456789      *ZZ*BCBS001        *260210*1430*^*00501*000000001*0*P*:~
GS*HC*123456789*BCBS001*20260210*1430*1*X*005010X224A2~
ST*837*0001*005010X224A2~
BHT*0019*00*CLM-2026-0001*20260210*1430*CH~
NM1*41*2*CLOUD DENTAL OFFICE*****46*123456789~
PER*IC*BILLING DEPT*TE*5555551234~
NM1*40*2*Blue Cross Blue Shield*****46*BCBS001~
HL*1**20*1~
NM1*85*1*Johnson*Sarah*****XX*1234567890~
N3*123 DENTAL PLAZA~
N4*ANYTOWN*CA*90210~
REF*EI*123456789~
HL*2*1*22*0~
SBR*P*18******MB~
NM1*IL*1*McCloud*Mark*****MI*1~
N3*123 MAIN ST~
N4*SAN FRANCISCO*CA*94102~
DMG*D8*19800115*M~
NM1*PR*2*Blue Cross Blue Shield*****PI*BCBS001~
CLM*CLM-2026-0001*150.00***11:B:1*Y*A*Y*Y~
DTP*472*RD8*20260210-20260210~
NM1*82*1*Johnson*Sarah*****XX*1234567890~
LX*1~
SV3*AD:D0120*50.00*UN*1****~
DTP*472*D8*20260210~
LX*2~
SV3*AD:D1110*100.00*UN*1****~
DTP*472*D8*20260210~
SE*24*0001~
GE*1*1~
IEA*1*000000001~
```

## 📊 Testing Checklist

- [ ] Configuration applied to database
- [ ] UI shows SFTP enabled for Blue Cross Blue Shield
- [ ] Test connection succeeds (🔌 cable icon)
- [ ] Claim submission works (green arrow)
- [ ] X12 file appears in SFTP `/inbound/837/`
- [ ] X12 format validates (ISA/GS/ST/BHT segments present)
- [ ] CloudHealthOffice workflow processes claim
- [ ] 835 remittance appears in `/outbound/835/`

## 🔍 Troubleshooting

### Connection Test Fails
```
Error: Failed to connect to Blue Cross Blue Shield. Check configuration.
```
**Solutions:**
1. Verify SFTP host is reachable: `ping sftp.cloudhealthoffice.com`
2. Test SSH connection: `ssh clouddentaloffice@sftp.cloudhealthoffice.com`
3. Check firewall/network settings
4. Verify credentials in Azure Key Vault:
   ```bash
   az keyvault secret show --vault-name aurelianws7530713286 \
     --name sftp-clouddentaloffice-password --query value -o tsv
   ```

### Claim Submission Fails
```
Error: SFTP upload failed: Permission denied
```
**Solutions:**
1. Check directory permissions: SFTP user should have write access to `/inbound/837/`
2. Verify remote path is correct (no typos)
3. Test manual upload via `sftp` CLI
4. Check SFTP server logs on CloudHealthOffice side

### Invalid X12 Generated
```
Error: Missing required segments
```
**Solutions:**
1. Ensure patient has insurance configured
2. Verify provider has NPI number
3. Check claim has at least one procedure
4. Review ClaimProcedure table for procedure codes (should use CDTCode field)

## 🚀 Next Steps

Once testing is successful:
1. Configure additional payers (Delta Dental, Aetna, etc.)
2. Set up automated claim submission workflows
3. Implement 835 remittance import/parsing
4. Add claim status tracking (276/277 transactions)
5. Enable eligibility verification (270/271 transactions)

## 📝 Notes

- **Password Storage:** Currently using base64 encoding (development only). For production, implement Azure Data Protection API or Key Vault integration.
- **X12 Validation:** Consider adding pre-flight validation before SFTP upload
- **Retry Logic:** Implement exponential backoff for transient SFTP failures
- **Audit Trail:** All EDI submissions are logged with timestamps and control numbers
- **CloudHealthOffice Processing:** Typical turnaround is 1-5 minutes for scrubbing + adjudication

## 🎯 Success Criteria

✅ **Test passes when:**
1. Claim submits without errors
2. X12 file appears in CloudHealthOffice SFTP within 10 seconds
3. CloudHealthOffice workflow picks up and processes the claim
4. 835 remittance is generated and available in `/outbound/835/`
5. Claim status updates to "Submitted" in CloudDentalOffice UI
