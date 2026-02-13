-- Comprehensive Demo Data Seed Script - Part 3
-- Treatment Plans and Claims

-- ============================================
-- 6. TREATMENT PLANS & PROCEDURES
-- ============================================

DO $$
DECLARE
    v_provider_id INT;
    v_patient_id INT;
    v_tp_id INT;
BEGIN
    SELECT "ProviderId" INTO v_provider_id FROM "Providers" WHERE "TenantId" = 'demo' AND "LastName" = 'Smile' LIMIT 1;

    -- Treatment Plan 1: Crown for Marcus
    SELECT "PatientId" INTO v_patient_id FROM "Patients" WHERE "TenantId" = 'demo' AND "Email" = 'marcus.w@email.com' LIMIT 1;
    INSERT INTO "TreatmentPlans" ("TenantId", "PatientId", "ProviderId", "Status", "Description", "CreatedDate")
    VALUES ('demo', v_patient_id, v_provider_id, 'InProgress', 'Crown restoration #14', NOW() - INTERVAL '10 days')
    RETURNING "TreatmentPlanId" INTO v_tp_id;

    INSERT INTO "PlannedProcedures" ("TenantId", "TreatmentPlanId", "CDTCode", "Description", "EstimatedFee", "Status", "CreatedDate")
    VALUES 
        ('demo', v_tp_id, 'D2740', 'Crown - porcelain/ceramic', 1250.00, 'InProgress', NOW() - INTERVAL '10 days'),
        ('demo', v_tp_id, 'D0220', 'Intraoral - periapical first radiographic image', 35.00, 'Completed', NOW() - INTERVAL '10 days');

    -- Treatment Plan 2: Root Canal for Rob
    SELECT "PatientId" INTO v_patient_id FROM "Patients" WHERE "TenantId" = 'demo' AND "Email" = 'rob.t@email.com' LIMIT 1;
    INSERT INTO "TreatmentPlans" ("TenantId", "PatientId", "ProviderId", "Status", "Description", "CreatedDate")
    VALUES ('demo', v_patient_id, v_provider_id, 'Proposed', 'Root canal therapy #19', NOW() - INTERVAL '2 days')
    RETURNING "TreatmentPlanId" INTO v_tp_id;

    INSERT INTO "PlannedProcedures" ("TenantId", "TreatmentPlanId", "CDTCode", "Description", "EstimatedFee", "Status", "CreatedDate")
    VALUES 
        ('demo', v_tp_id, 'D3310', 'Endodontic therapy, anterior tooth', 850.00, 'Planned', NOW() - INTERVAL '2 days'),
        ('demo', v_tp_id, 'D2740', 'Crown - porcelain/ceramic', 1250.00, 'Planned', NOW() - INTERVAL '2 days');

    -- Treatment Plan 3: Multiple Fillings for Sarah
    SELECT "PatientId" INTO v_patient_id FROM "Patients" WHERE "TenantId" = 'demo' AND "Email" = 'sarah.c@email.com' LIMIT 1;
    INSERT INTO "TreatmentPlans" ("TenantId", "PatientId", "ProviderId", "Status", "Description", "CreatedDate")
    VALUES ('demo', v_patient_id, v_provider_id, 'Accepted', 'Composite restorations', NOW() - INTERVAL '5 days')
    RETURNING "TreatmentPlanId" INTO v_tp_id;

    INSERT INTO "PlannedProcedures" ("TenantId", "TreatmentPlanId", "CDTCode", "Description", "EstimatedFee", "Status", "CreatedDate")
    VALUES 
        ('demo', v_tp_id, 'D2391', 'Resin-based composite - one surface, posterior', 185.00, 'Planned', NOW() - INTERVAL '5 days'),
        ('demo', v_tp_id, 'D2392', 'Resin-based composite - two surfaces, posterior', 245.00, 'Planned', NOW() - INTERVAL '5 days');

    -- Treatment Plan 4: Bridge for Dan
    SELECT "PatientId" INTO v_patient_id FROM "Patients" WHERE "TenantId" = 'demo' AND "Email" = 'dan.m@email.com' LIMIT 1;
    INSERT INTO "TreatmentPlans" ("TenantId", "PatientId", "ProviderId", "Status", "Description", "CreatedDate")
    VALUES ('demo', v_patient_id, v_provider_id, 'Proposed', '3-unit bridge #13-15', NOW() - INTERVAL '1 day')
    RETURNING "TreatmentPlanId" INTO v_tp_id;

    INSERT INTO "PlannedProcedures" ("TenantId", "TreatmentPlanId", "CDTCode", "Description", "EstimatedFee", "Status", "CreatedDate")
    VALUES 
        ('demo', v_tp_id, 'D6242', 'Pontic - porcelain/ceramic', 1150.00, 'Planned', NOW() - INTERVAL '1 day'),
        ('demo', v_tp_id, 'D6740', 'Retainer crown - porcelain/ceramic', 1250.00, 'Planned', NOW() - INTERVAL '1 day'),
        ('demo', v_tp_id, 'D6750', 'Retainer crown - porcelain fused to high noble metal', 1250.00, 'Planned', NOW() - INTERVAL '1 day');

END $$;

-- ============================================
-- 7. CLAIMS (10 claims in various statuses)
-- ============================================

DO $$
DECLARE
    v_provider_id INT;
    v_patient_id INT;
    v_insurance_id INT;
    v_claim_id INT;
    v_delta_id INT;
    v_aetna_id INT;
    v_cigna_id INT;
    v_metlife_id INT;
    v_bcbs_id INT;
BEGIN
    SELECT "ProviderId" INTO v_provider_id FROM "Providers" WHERE "TenantId" = 'demo' AND "LastName" = 'Smile' LIMIT 1;
    SELECT "InsurancePlanId" INTO v_delta_id FROM "InsurancePlans" WHERE "TenantId" = 'demo' AND "PayerId" = '00001' LIMIT 1;
    SELECT "InsurancePlanId" INTO v_aetna_id FROM "InsurancePlans" WHERE "TenantId" = 'demo' AND "PayerId" = '60054' LIMIT 1;
    SELECT "InsurancePlanId" INTO v_cigna_id FROM "InsurancePlans" WHERE "TenantId" = 'demo' AND "PayerId" = '62308' LIMIT 1;
    SELECT "InsurancePlanId" INTO v_metlife_id FROM "InsurancePlans" WHERE "TenantId" = 'demo' AND "PayerId" = '98234' LIMIT 1;
    SELECT "InsurancePlanId" INTO v_bcbs_id FROM "InsurancePlans" WHERE "TenantId" = 'demo' AND "PayerId" = '54771' LIMIT 1;

    -- Claim 1: APPROVED - Emily's cleaning
    SELECT "PatientId" INTO v_patient_id FROM "Patients" WHERE "TenantId" = 'demo' AND "Email" = 'emily.r@email.com' LIMIT 1;
    INSERT INTO "Claims" ("TenantId", "PatientId", "ProviderId", "InsurancePlanId", "ClaimNumber", "ServiceDate", "TotalFee", "Status", "SubmittedDate", "CreatedDate")
    VALUES ('demo', v_patient_id, v_provider_id, v_aetna_id, 'CLM-2024-0384', NOW() - INTERVAL '15 days', 245.00, 'Approved', NOW() - INTERVAL '15 days', NOW() - INTERVAL '15 days')
    RETURNING "ClaimId" INTO v_claim_id;

    INSERT INTO "ClaimProcedures" ("TenantId", "ClaimId", "CDTCode", "Description", "Fee", "ToothNumber", "CreatedDate")
    VALUES 
        ('demo', v_claim_id, 'D0120', 'Periodic oral evaluation', 50.00, NULL, NOW() - INTERVAL '15 days'),
        ('demo', v_claim_id, 'D1110', 'Prophylaxis - adult', 95.00, NULL, NOW() - INTERVAL '15 days'),
        ('demo', v_claim_id, 'D0274', 'Bitewings - four radiographic images', 100.00, NULL, NOW() - INTERVAL '15 days');

    -- Claim 2: SUBMITTED - Marcus's crown prep
    SELECT "PatientId" INTO v_patient_id FROM "Patients" WHERE "TenantId" = 'demo' AND "Email" = 'marcus.w@email.com' LIMIT 1;
    INSERT INTO "Claims" ("TenantId", "PatientId", "ProviderId", "InsurancePlanId", "ClaimNumber", "ServiceDate", "TotalFee", "Status", "SubmittedDate", "CreatedDate")
    VALUES ('demo', v_patient_id, v_provider_id, v_cigna_id, 'CLM-2024-0421', NOW() - INTERVAL '5 days', 1285.00, 'Submitted', NOW() - INTERVAL '5 days', NOW() - INTERVAL '5 days')
    RETURNING "ClaimId" INTO v_claim_id;

    INSERT INTO "ClaimProcedures" ("TenantId", "ClaimId", "CDTCode", "Description", "Fee", "ToothNumber", "CreatedDate")
    VALUES 
        ('demo', v_claim_id, 'D2740', 'Crown - porcelain/ceramic', 1250.00, '14', NOW() - INTERVAL '5 days'),
        ('demo', v_claim_id, 'D0220', 'Intraoral - periapical', 35.00, '14', NOW() - INTERVAL '5 days');

    -- Claim 3: PENDING - Sarah's fillings
    SELECT "PatientId" INTO v_patient_id FROM "Patients" WHERE "TenantId" = 'demo' AND "Email" = 'sarah.c@email.com' LIMIT 1;
    INSERT INTO "Claims" ("TenantId", "PatientId", "ProviderId", "InsurancePlanId", "ClaimNumber", "ServiceDate", "TotalFee", "Status", "SubmittedDate", "CreatedDate")
    VALUES ('demo', v_patient_id, v_provider_id, v_metlife_id, 'CLM-2024-0445', NOW() - INTERVAL '12 days', 430.00, 'Pending', NOW() - INTERVAL '12 days', NOW() - INTERVAL '12 days')
    RETURNING "ClaimId" INTO v_claim_id;

    INSERT INTO "ClaimProcedures" ("TenantId", "ClaimId", "CDTCode", "Description", "Fee", "ToothNumber", "CreatedDate")
    VALUES 
        ('demo', v_claim_id, 'D2391', 'Resin composite - one surface', 185.00, '12', NOW() - INTERVAL '12 days'),
        ('demo', v_claim_id, 'D2392', 'Resin composite - two surfaces', 245.00, '13', NOW() - INTERVAL '12 days');

    -- Claim 4: APPROVED - Jennifer's cleaning
    SELECT "PatientId" INTO v_patient_id FROM "Patients" WHERE "TenantId" = 'demo' AND "Email" = 'jen.m@email.com' LIMIT 1;
    INSERT INTO "Claims" ("TenantId", "PatientId", "ProviderId", "InsurancePlanId", "ClaimNumber", "ServiceDate", "TotalFee", "Status", "SubmittedDate", "CreatedDate")
    VALUES ('demo', v_patient_id, v_provider_id, v_delta_id, 'CLM-2024-0412', NOW() - INTERVAL '20 days', 195.00, 'Approved', NOW() - INTERVAL '20 days', NOW() - INTERVAL '20 days')
    RETURNING "ClaimId" INTO v_claim_id;

    INSERT INTO "ClaimProcedures" ("TenantId", "ClaimId", "CDTCode", "Description", "Fee", "ToothNumber", "CreatedDate")
    VALUES 
        ('demo', v_claim_id, 'D0120', 'Periodic oral evaluation', 50.00, NULL, NOW() - INTERVAL '20 days'),
        ('demo', v_claim_id, 'D1110', 'Prophylaxis - adult', 95.00, NULL, NOW() - INTERVAL '20 days'),
        ('demo', v_claim_id, 'D0272', 'Bitewings - two images', 50.00, NULL, NOW() - INTERVAL '20 days');

    -- Claim 5: DENIED - Lisa's procedure
    SELECT "PatientId" INTO v_patient_id FROM "Patients" WHERE "TenantId" = 'demo' AND "Email" = 'lisa.a@email.com' LIMIT 1;
    INSERT INTO "Claims" ("TenantId", "PatientId", "ProviderId", "InsurancePlanId", "ClaimNumber", "ServiceDate", "TotalFee", "Status", "SubmittedDate", "CreatedDate")
    VALUES ('demo', v_patient_id, v_provider_id, v_aetna_id, 'CLM-2024-0398', NOW() - INTERVAL '25 days', 245.00, 'Denied', NOW() - INTERVAL '25 days', NOW() - INTERVAL '25 days')
    RETURNING "ClaimId" INTO v_claim_id;

    INSERT INTO "ClaimProcedures" ("TenantId", "ClaimId", "CDTCode", "Description", "Fee", "ToothNumber", "CreatedDate")
    VALUES 
        ('demo', v_claim_id, 'D2391', 'Resin composite - one surface', 185.00, '18', NOW() - INTERVAL '25 days'),
        ('demo', v_claim_id, 'D0230', 'Intraoral radiograph', 60.00, NULL, NOW() - INTERVAL '25 days');

    -- Claim 6: SUBMITTED - James's exam
    SELECT "PatientId" INTO v_patient_id FROM "Patients" WHERE "TenantId" = 'demo' AND "Email" = 'james.w@email.com' LIMIT 1;
    INSERT INTO "Claims" ("TenantId", "PatientId", "ProviderId", "InsurancePlanId", "ClaimNumber", "ServiceDate", "TotalFee", "Status", "SubmittedDate", "CreatedDate")
    VALUES ('demo', v_patient_id, v_provider_id, v_cigna_id, 'CLM-2024-0456', NOW() - INTERVAL '3 days', 150.00, 'Submitted', NOW() - INTERVAL '3 days', NOW() - INTERVAL '3 days')
    RETURNING "ClaimId" INTO v_claim_id;

    INSERT INTO "ClaimProcedures" ("TenantId", "ClaimId", "CDTCode", "Description", "Fee", "ToothNumber", "CreatedDate")
    VALUES 
        ('demo', v_claim_id, 'D0150', 'Comprehensive oral evaluation', 100.00, NULL, NOW() - INTERVAL '3 days'),
        ('demo', v_claim_id, 'D0210', 'Complete radiographic series', 150.00, NULL, NOW() - INTERVAL '3 days');

    -- Claim 7: PENDING - Maria's crown
    SELECT "PatientId" INTO v_patient_id FROM "Patients" WHERE "TenantId" = 'demo' AND "Email" = 'maria.g@email.com' LIMIT 1;
    INSERT INTO "Claims" ("TenantId", "PatientId", "ProviderId", "InsurancePlanId", "ClaimNumber", "ServiceDate", "TotalFee", "Status", "SubmittedDate", "CreatedDate")
    VALUES ('demo', v_patient_id, v_provider_id, v_metlife_id, 'CLM-2024-0467', NOW() - INTERVAL '8 days', 1350.00, 'Pending', NOW() - INTERVAL '8 days', NOW() - INTERVAL '8 days')
    RETURNING "ClaimId" INTO v_claim_id;

    INSERT INTO "ClaimProcedures" ("TenantId", "ClaimId", "CDTCode", "Description", "Fee", "ToothNumber", "CreatedDate")
    VALUES 
        ('demo', v_claim_id, 'D2750', 'Crown - porcelain fused to high noble metal', 1350.00, '30', NOW() - INTERVAL '8 days');

    -- Claim 8: APPROVED - Christopher's cleaning
    SELECT "PatientId" INTO v_patient_id FROM "Patients" WHERE "TenantId" = 'demo' AND "Email" = 'chris.l@email.com' LIMIT 1;
    INSERT INTO "Claims" ("TenantId", "PatientId", "ProviderId", "InsurancePlanId", "ClaimNumber", "ServiceDate", "TotalFee", "Status", "SubmittedDate", "CreatedDate")
    VALUES ('demo', v_patient_id, v_provider_id, v_bcbs_id, 'CLM-2024-0434', NOW() - INTERVAL '18 days', 195.00, 'Approved', NOW() - INTERVAL '18 days', NOW() - INTERVAL '18 days')
    RETURNING "ClaimId" INTO v_claim_id;

    INSERT INTO "ClaimProcedures" ("TenantId", "ClaimId", "CDTCode", "Description", "Fee", "ToothNumber", "CreatedDate")
    VALUES 
        ('demo', v_claim_id, 'D0120', 'Periodic oral evaluation', 50.00, NULL, NOW() - INTERVAL '18 days'),
        ('demo', v_claim_id, 'D1110', 'Prophylaxis - adult', 95.00, NULL, NOW() - INTERVAL '18 days'),
        ('demo', v_claim_id, 'D0272', 'Bitewings - two images', 50.00, NULL, NOW() - INTERVAL '18 days');

    -- Claim 9: SUBMITTED - Kevin's crown prep (from completed appointment)
    SELECT "PatientId" INTO v_patient_id FROM "Patients" WHERE "TenantId" = 'demo' AND "Email" = 'kevin.t@email.com' LIMIT 1;
    INSERT INTO "Claims" ("TenantId", "PatientId", "ProviderId", "InsurancePlanId", "ClaimNumber", "ServiceDate", "TotalFee", "Status", "SubmittedDate", "CreatedDate")
    VALUES ('demo', v_patient_id, v_provider_id, v_delta_id, 'CLM-2024-0478', NOW() - INTERVAL '1 day', 1285.00, 'Submitted', NOW() - INTERVAL '1 day', NOW() - INTERVAL '1 day')
    RETURNING "ClaimId" INTO v_claim_id;

    INSERT INTO "ClaimProcedures" ("TenantId", "ClaimId", "CDTCode", "Description", "Fee", "ToothNumber", "CreatedDate")
    VALUES 
        ('demo', v_claim_id, 'D2740', 'Crown - porcelain/ceramic', 1250.00, '30', NOW() - INTERVAL '1 day'),
        ('demo', v_claim_id, 'D0220', 'Intraoral - periapical', 35.00, '30', NOW() - INTERVAL '1 day');

    -- Claim 10: PENDING - Michelle's filling (from completed appointment)
    SELECT "PatientId" INTO v_patient_id FROM "Patients" WHERE "TenantId" = 'demo' AND "Email" = 'michelle.w@email.com' LIMIT 1;
    INSERT INTO "Claims" ("TenantId", "PatientId", "ProviderId", "InsurancePlanId", "ClaimNumber", "ServiceDate", "TotalFee", "Status", "SubmittedDate", "CreatedDate")
    VALUES ('demo', v_patient_id, v_provider_id, v_aetna_id, 'CLM-2024-0489', NOW() - INTERVAL '2 days', 185.00, 'Pending', NOW() - INTERVAL '2 days', NOW() - INTERVAL '2 days')
    RETURNING "ClaimId" INTO v_claim_id;

    INSERT INTO "ClaimProcedures" ("TenantId", "ClaimId", "CDTCode", "Description", "Fee", "ToothNumber", "CreatedDate")
    VALUES 
        ('demo', v_claim_id, 'D2391', 'Resin composite - one surface', 185.00, '14', NOW() - INTERVAL '2 days');

END $$;

SELECT '✅ Demo Data Seeding Complete!' AS status,
       (SELECT COUNT(*) FROM "Patients" WHERE "TenantId" = 'demo') AS patients,
       (SELECT COUNT(*) FROM "Appointments" WHERE "TenantId" = 'demo') AS appointments,
       (SELECT COUNT(*) FROM "Claims" WHERE "TenantId" = 'demo') AS claims,
       (SELECT COUNT(*) FROM "InsurancePlans" WHERE "TenantId" = 'demo') AS payers,
       (SELECT COUNT(*) FROM "TreatmentPlans" WHERE "TenantId" = 'demo') AS treatment_plans;
