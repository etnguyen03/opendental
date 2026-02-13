-- Seed Claims and Treatment Plans for 'dev' tenant
-- This script creates sample claims data for demo purposes

DO $$
DECLARE
    v_provider_id INT;
    v_patient_id INT;
    v_patient_insurance_id INT;
    v_claim_id INT;
    v_claim_number TEXT;
BEGIN
    -- Get a provider
    SELECT "ProviderId" INTO v_provider_id 
    FROM "Providers" 
    WHERE "TenantId" = 'dev' 
    LIMIT 1;

    -- Create claims for first 5 patients with insurance
    FOR v_patient_id IN 
        SELECT DISTINCT p."PatientId"
        FROM "Patients" p
        INNER JOIN "PatientInsurances" pi ON p."PatientId" = pi."PatientId"
        WHERE p."TenantId" = 'dev'
        ORDER BY p."PatientId" 
        LIMIT 5
    LOOP
        -- Get patient insurance
        SELECT "PatientInsuranceId" INTO v_patient_insurance_id
        FROM "PatientInsurances"
        WHERE "PatientId" = v_patient_id AND "TenantId" = 'dev'
        LIMIT 1;

        -- Generate claim number
        v_claim_number := 'CLM-' || TO_CHAR(NOW(), 'YYYYMMDD') || '-' || LPAD(v_patient_id::TEXT, 4, '0');

        -- Create a submitted claim
        INSERT INTO "Claims" (
            "TenantId", "PatientId", "ProviderId", "PatientInsuranceId",
            "ClaimNumber", "Status", "ServiceDateFrom", "SubmittedDate", 
            "TotalChargeAmount", "CreatedDate", "ClaimType"
        ) VALUES (
            'dev', 
            v_patient_id, 
            v_provider_id, 
            v_patient_insurance_id,
            v_claim_number,
            'Submitted',
            NOW() - INTERVAL '30 days',
            NOW() - INTERVAL '28 days',
            450.00,
            NOW() - INTERVAL '28 days',
            'Primary'
        ) RETURNING "ClaimId" INTO v_claim_id;

        -- Add claim procedures
        INSERT INTO "ClaimProcedures" (
            "TenantId", "ClaimId", "CDTCode", "Description",
            "ServiceDate", "ChargeAmount"
        ) VALUES
        (
            'dev', v_claim_id, 'D0150', 'Comprehensive oral evaluation',
            NOW() - INTERVAL '30 days', 85.00
        ),
        (
            'dev', v_claim_id, 'D1110', 'Prophylaxis - adult',
            NOW() - INTERVAL '30 days', 125.00
        ),
        (
            'dev', v_claim_id, 'D0210', 'Intraoral - complete series',
            NOW() - INTERVAL '30 days', 240.00
        );
    END LOOP;

    -- Add a few paid claims
    FOR v_patient_id IN 
        SELECT DISTINCT p."PatientId"
        FROM "Patients" p
        INNER JOIN "PatientInsurances" pi ON p."PatientId" = pi."PatientId"
        WHERE p."TenantId" = 'dev'
        ORDER BY p."PatientId" 
        OFFSET 5
        LIMIT 3
    LOOP
        SELECT "PatientInsuranceId" INTO v_patient_insurance_id
        FROM "PatientInsurances"
        WHERE "PatientId" = v_patient_id AND "TenantId" = 'dev'
        LIMIT 1;

        v_claim_number := 'CLM-' || TO_CHAR(NOW() - INTERVAL '60 days', 'YYYYMMDD') || '-' || LPAD(v_patient_id::TEXT, 4, '0');

        INSERT INTO "Claims" (
            "TenantId", "PatientId", "ProviderId", "PatientInsuranceId",
            "ClaimNumber", "Status", "ServiceDateFrom", "SubmittedDate", "ProcessedDate",
            "TotalChargeAmount", "PaidAmount", "PatientResponsibility",
            "CreatedDate", "ClaimType"
        ) VALUES (
            'dev', 
            v_patient_id, 
            v_provider_id, 
            v_patient_insurance_id,
            v_claim_number,
            'Paid',
            NOW() - INTERVAL '60 days',
            NOW() - INTERVAL '58 days',
            NOW() - INTERVAL '30 days',
            320.00,
            256.00,
            64.00,
            NOW() - INTERVAL '58 days',
            'Primary'
        ) RETURNING "ClaimId" INTO v_claim_id;

        INSERT INTO "ClaimProcedures" (
            "TenantId", "ClaimId", "CDTCode", "Description",
            "ServiceDate", "ChargeAmount", "AllowedAmount", "PaidAmount"
        ) VALUES
        (
            'dev', v_claim_id, 'D0150', 'Comprehensive oral evaluation',
            NOW() - INTERVAL '60 days', 85.00, 68.00, 68.00
        ),
        (
            'dev', v_claim_id, 'D1110', 'Prophylaxis - adult',
            NOW() - INTERVAL '60 days', 125.00, 100.00, 100.00
        ),
        (
            'dev', v_claim_id, 'D0274', 'Bitewings - four radiographic images',
            NOW() - INTERVAL '60 days', 110.00, 88.00, 88.00
        );
    END LOOP;

    -- Add draft/pending claims
    FOR v_patient_id IN 
        SELECT DISTINCT p."PatientId"
        FROM "Patients" p
        INNER JOIN "PatientInsurances" pi ON p."PatientId" = pi."PatientId"
        WHERE p."TenantId" = 'dev'
        ORDER BY p."PatientId" DESC
        LIMIT 2
    LOOP
        SELECT "PatientInsuranceId" INTO v_patient_insurance_id
        FROM "PatientInsurances"
        WHERE "PatientId" = v_patient_id AND "TenantId" = 'dev'
        LIMIT 1;

        v_claim_number := 'CLM-' || TO_CHAR(NOW(), 'YYYYMMDD') || '-P-' || LPAD(v_patient_id::TEXT, 4, '0');

        INSERT INTO "Claims" (
            "TenantId", "PatientId", "ProviderId", "PatientInsuranceId",
            "ClaimNumber", "Status", "ServiceDateFrom",
            "TotalChargeAmount", "CreatedDate", "ClaimType"
        ) VALUES (
            'dev', 
            v_patient_id, 
            v_provider_id, 
            v_patient_insurance_id,
            v_claim_number,
            'Draft',
            NOW() - INTERVAL '7 days',
            595.00,
            NOW() - INTERVAL '5 days',
            'Primary'
        ) RETURNING "ClaimId" INTO v_claim_id;

        INSERT INTO "ClaimProcedures" (
            "TenantId", "ClaimId", "CDTCode", "Description",
            "ServiceDate", "ChargeAmount"
        ) VALUES
        (
            'dev', v_claim_id, 'D2391', 'Resin composite - one surface, posterior',
            NOW() - INTERVAL '7 days', 185.00
        ),
        (
            'dev', v_claim_id, 'D2392', 'Resin composite - two surfaces, posterior',
            NOW() - INTERVAL '7 days', 245.00
        ),
        (
            'dev', v_claim_id, 'D0220', 'Intraoral periapical first film',
            NOW() - INTERVAL '7 days', 35.00
        ),
        (
            'dev', v_claim_id, 'D1110', 'Prophylaxis - adult',
            NOW() - INTERVAL '7 days', 130.00
        );
    END LOOP;

END $$;

-- Verify claims
SELECT 
    'Claims Created' as summary,
    COUNT(*) as total_count,
    SUM(CASE WHEN "Status" = 'Paid' THEN 1 ELSE 0 END) as paid_count,
    SUM(CASE WHEN "Status" = 'Submitted' THEN 1 ELSE 0 END) as submitted_count,
    SUM(CASE WHEN "Status" = 'Draft' THEN 1 ELSE 0 END) as draft_count
FROM "Claims"
WHERE "TenantId" = 'dev';
