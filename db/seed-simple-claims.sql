-- Simple claims seed for dev tenant
-- Creates claims for patients regardless of insurance status

DO $$
DECLARE
    v_provider_id INT;
    v_patient_id INT;
    v_claim_id INT;
    v_claim_number TEXT;
    v_counter INT := 0;
BEGIN
    -- Get a provider
    SELECT "ProviderId" INTO v_provider_id 
    FROM "Providers" 
    WHERE "TenantId" = 'dev' 
    LIMIT 1;

    -- Create claims for first 10 patients
    FOR v_patient_id IN 
        SELECT "PatientId" 
        FROM "Patients" 
        WHERE "TenantId" = 'dev' 
        ORDER BY "PatientId" 
        LIMIT 10
    LOOP
        v_counter := v_counter + 1;
        v_claim_number := 'CLM-' || TO_CHAR(NOW(), 'YYYYMMDD') || '-' || LPAD(v_counter::TEXT, 4, '0');

        -- Create the claim (without patient insurance for simplicity)
        INSERT INTO "Claims" (
            "TenantId", "PatientId", "ProviderId",
            "ClaimNumber", "Status",  "ServiceDateFrom",
            "TotalChargeAmount", "CreatedDate", "ClaimType"
        ) VALUES (
            'dev', 
            v_patient_id, 
            v_provider_id,
            v_claim_number,
            CASE 
                WHEN v_counter <= 3 THEN 'Paid'
                WHEN v_counter <= 6 THEN 'Submitted'
                ELSE 'Draft'
            END,
            NOW() - INTERVAL '30 days',
            450.00,
            NOW() - INTERVAL '28 days',
            'Primary'
        ) RETURNING "ClaimId" INTO v_claim_id;

        -- Add procedures to claim
        INSERT INTO "ClaimProcedures" (
            "TenantId", "ClaimId", "CDTCode", "Description",
            "ServiceDate", "ChargeAmount", "AllowedAmount", "PaidAmount"
        ) VALUES
        (
            'dev', v_claim_id, 'D0150', 'Comprehensive oral evaluation',
            NOW() - INTERVAL '30 days', 85.00,
            CASE WHEN v_counter <= 3 THEN 68.00 ELSE NULL END,
            CASE WHEN v_counter <= 3 THEN 68.00 ELSE NULL END
        ),
        (
            'dev', v_claim_id, 'D1110', 'Prophylaxis - adult',
            NOW() - INTERVAL '30 days', 125.00,
            CASE WHEN v_counter <= 3 THEN 100.00 ELSE NULL END,
            CASE WHEN v_counter <= 3 THEN 100.00 ELSE NULL END
        ),
        (
            'dev', v_claim_id, 'D0210', 'Intraoral complete series',
            NOW() - INTERVAL '30 days', 240.00,
            CASE WHEN v_counter <= 3 THEN 192.00 ELSE NULL END,
            CASE WHEN v_counter <= 3 THEN 192.00 ELSE NULL END
        );

        -- Update paid claims with paid amounts
        IF v_counter <= 3 THEN
            UPDATE "Claims" 
            SET "PaidAmount" = 360.00, 
                "ProcessedDate" = NOW() - INTERVAL '15 days',
                "SubmittedDate" = NOW() - INTERVAL '28 days'
            WHERE "ClaimId" = v_claim_id;
        ELSIF v_counter <= 6 THEN
            UPDATE "Claims" 
            SET "SubmittedDate" = NOW() - INTERVAL '10 days'
            WHERE "ClaimId" = v_claim_id;
        END IF;
    END LOOP;

    RAISE NOTICE 'Created % claims', v_counter;
END $$;

-- Verify claims
SELECT 
    'Claims Seeded' as summary,
    COUNT(*) as total_count,
    SUM(CASE WHEN "Status" = 'Paid' THEN 1 ELSE 0 END) as paid,
    SUM(CASE WHEN "Status" = 'Submitted' THEN 1 ELSE 0 END) as submitted,
    SUM(CASE WHEN "Status" = 'Draft' THEN 1 ELSE 0 END) as draft
FROM "Claims"
WHERE "TenantId" = 'dev';
