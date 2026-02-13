-- Comprehensive Demo Data Seed Script - Part 2
-- Appointments, Claims, Treatment Plans, and Patient Insurance

-- ============================================
-- 4. PATIENT INSURANCE ASSIGNMENTS
-- ============================================

DO $$
DECLARE
    v_delta_id INT;
    v_aetna_id INT;
    v_cigna_id INT;
    v_metlife_id INT;
    v_bcbs_id INT;
    v_guardian_id INT;
    v_patient_id INT;
BEGIN
    -- Get insurance plan IDs
    SELECT "InsurancePlanId" INTO v_delta_id FROM "InsurancePlans" WHERE "TenantId" = 'demo' AND "PayerId" = '00001' LIMIT 1;
    SELECT "InsurancePlanId" INTO v_aetna_id FROM "InsurancePlans" WHERE "TenantId" = 'demo' AND "PayerId" = '60054' LIMIT 1;
    SELECT "InsurancePlanId" INTO v_cigna_id FROM "InsurancePlans" WHERE "TenantId" = 'demo' AND "PayerId" = '62308' LIMIT 1;
    SELECT "InsurancePlanId" INTO v_metlife_id FROM "InsurancePlans" WHERE "TenantId" = 'demo' AND "PayerId" = '98234' LIMIT 1;
    SELECT "InsurancePlanId" INTO v_bcbs_id FROM "InsurancePlans" WHERE "TenantId" = 'demo' AND "PayerId" = '54771' LIMIT 1;
    SELECT "InsurancePlanId" INTO v_guardian_id FROM "InsurancePlans" WHERE "TenantId" = 'demo' AND "PayerId" = '61101' LIMIT 1;

    -- Assign insurance to various patients
    SELECT "PatientId" INTO v_patient_id FROM "Patients" WHERE "TenantId" = 'demo' AND "Email" = 'emily.r@email.com' LIMIT 1;
    INSERT INTO "PatientInsurances" ("TenantId", "PatientId", "InsurancePlanId", "MemberId", "SequenceNumber", "IsActive", "RelationshipToSubscriber", "EffectiveDate", "CreatedDate")
    SELECT 'demo', v_patient_id, v_aetna_id, 'AET9876543', 1, true, 'Self', NOW() - INTERVAL '2 years', NOW()
    WHERE NOT EXISTS (SELECT 1 FROM "PatientInsurances" WHERE "PatientId" = v_patient_id);

    SELECT "PatientId" INTO v_patient_id FROM "Patients" WHERE "TenantId" = 'demo' AND "Email" = 'marcus.w@email.com' LIMIT 1;
    INSERT INTO "PatientInsurances" ("TenantId", "PatientId", "InsurancePlanId", "MemberId", "SequenceNumber", "IsActive", "RelationshipToSubscriber", "EffectiveDate", "CreatedDate")
    SELECT 'demo', v_patient_id, v_cigna_id, 'CIG12345678', 1, true, 'Self', NOW() - INTERVAL '1 year', NOW()
    WHERE NOT EXISTS (SELECT 1 FROM "PatientInsurances" WHERE "PatientId" = v_patient_id);

    SELECT "PatientId" INTO v_patient_id FROM "Patients" WHERE "TenantId" = 'demo' AND "Email" = 'sarah.c@email.com' LIMIT 1;
    INSERT INTO "PatientInsurances" ("TenantId", "PatientId", "InsurancePlanId", "MemberId", "SequenceNumber", "IsActive", "RelationshipToSubscriber", "EffectiveDate", "CreatedDate")
    SELECT 'demo', v_patient_id, v_metlife_id, 'MET55667788', 1, true, 'Self', NOW() - INTERVAL '3 years', NOW()
    WHERE NOT EXISTS (SELECT 1 FROM "PatientInsurances" WHERE "PatientId" = v_patient_id);

    SELECT "PatientId" INTO v_patient_id FROM "Patients" WHERE "TenantId" = 'demo' AND "Email" = 'david.k@email.com' LIMIT 1;
    INSERT INTO "PatientInsurances" ("TenantId", "PatientId", "InsurancePlanId", "MemberId", "SequenceNumber", "IsActive", "RelationshipToSubscriber", "EffectiveDate", "CreatedDate")
    SELECT 'demo', v_patient_id, v_bcbs_id, 'BCBS987654', 1, true, 'Self', NOW() - INTERVAL '6 months', NOW()
    WHERE NOT EXISTS (SELECT 1 FROM "PatientInsurances" WHERE "PatientId" = v_patient_id);

    SELECT "PatientId" INTO v_patient_id FROM "Patients" WHERE "TenantId" = 'demo' AND "Email" = 'jen.m@email.com' LIMIT 1;
    INSERT INTO "PatientInsurances" ("TenantId", "PatientId", "InsurancePlanId", "MemberId", "SequenceNumber", "IsActive", "RelationshipToSubscriber", "EffectiveDate", "CreatedDate")
    SELECT 'demo', v_patient_id, v_delta_id, 'DD567890123', 1, true, 'Self', NOW() - INTERVAL '1 year', NOW()
    WHERE NOT EXISTS (SELECT 1 FROM "PatientInsurances" WHERE "PatientId" = v_patient_id);

    SELECT "PatientId" INTO v_patient_id FROM "Patients" WHERE "TenantId" = 'demo' AND "Email" = 'rob.t@email.com' LIMIT 1;
    INSERT INTO "PatientInsurances" ("TenantId", "PatientId", "InsurancePlanId", "MemberId", "SequenceNumber", "IsActive", "RelationshipToSubscriber", "EffectiveDate", "CreatedDate")
    SELECT 'demo', v_patient_id, v_guardian_id, 'GRD445566', 1, true, 'Self', NOW() - INTERVAL '4 years', NOW()
    WHERE NOT EXISTS (SELECT 1 FROM "PatientInsurances" WHERE "PatientId" = v_patient_id);

    SELECT "PatientId" INTO v_patient_id FROM "Patients" WHERE "TenantId" = 'demo' AND "Email" = 'lisa.a@email.com' LIMIT 1;
    INSERT INTO "PatientInsurances" ("TenantId", "PatientId", "InsurancePlanId", "MemberId", "SequenceNumber", "IsActive", "RelationshipToSubscriber", "EffectiveDate", "CreatedDate")
    SELECT 'demo', v_patient_id, v_aetna_id, 'AET1234567', 1, true, 'Self', NOW() - INTERVAL '2 years', NOW()
    WHERE NOT EXISTS (SELECT 1 FROM "PatientInsurances" WHERE "PatientId" = v_patient_id);

    SELECT "PatientId" INTO v_patient_id FROM "Patients" WHERE "TenantId" = 'demo' AND "Email" = 'james.w@email.com' LIMIT 1;
    INSERT INTO "PatientInsurances" ("TenantId", "PatientId", "InsurancePlanId", "MemberId", "SequenceNumber", "IsActive", "RelationshipToSubscriber", "EffectiveDate", "CreatedDate")
    SELECT 'demo', v_patient_id, v_cigna_id, 'CIG9988776', 1, true, 'Self', NOW() - INTERVAL '8 months', NOW()
    WHERE NOT EXISTS (SELECT 1 FROM "PatientInsurances" WHERE "PatientId" = v_patient_id);

    SELECT "PatientId" INTO v_patient_id FROM "Patients" WHERE "TenantId" = 'demo' AND "Email" = 'maria.g@email.com' LIMIT 1;
    INSERT INTO "PatientInsurances" ("TenantId", "PatientId", "InsurancePlanId", "MemberId", "SequenceNumber", "IsActive", "RelationshipToSubscriber", "EffectiveDate", "CreatedDate")
    SELECT 'demo', v_patient_id, v_metlife_id, 'MET223344', 1, true, 'Self', NOW() - INTERVAL '5 years', NOW()
    WHERE NOT EXISTS (SELECT 1 FROM "PatientInsurances" WHERE "PatientId" = v_patient_id);

    SELECT "PatientId" INTO v_patient_id FROM "Patients" WHERE "TenantId" = 'demo' AND "Email" = 'chris.l@email.com' LIMIT 1;
    INSERT INTO "PatientInsurances" ("TenantId", "PatientId", "InsurancePlanId", "MemberId", "SequenceNumber", "IsActive", "RelationshipToSubscriber", "EffectiveDate", "CreatedDate")
    SELECT 'demo', v_patient_id, v_bcbs_id, 'BCBS556677', 1, true, 'Self', NOW() - INTERVAL '1 year', NOW()
    WHERE NOT EXISTS (SELECT 1 FROM "PatientInsurances" WHERE "PatientId" = v_patient_id);

END $$;

-- ============================================
-- 5. APPOINTMENTS (15 appointments)
-- ============================================

DO $$
DECLARE
    v_provider_id INT;
    v_ortho_id INT;
    v_endo_id INT;
    v_patient_id INT;
    today_date TIMESTAMP := CURRENT_DATE;
BEGIN
    SELECT "ProviderId" INTO v_provider_id FROM "Providers" WHERE "TenantId" = 'demo' AND "LastName" = 'Smile' LIMIT 1;
    SELECT "ProviderId" INTO v_ortho_id FROM "Providers" WHERE "TenantId" = 'demo' AND "LastName" = 'Chen' LIMIT 1;
    SELECT "ProviderId" INTO v_endo_id FROM "Providers" WHERE "TenantId" = 'demo' AND "LastName" = 'Martinez' LIMIT 1;

    -- Today's Appointments
    SELECT "PatientId" INTO v_patient_id FROM "Patients" WHERE "TenantId" = 'demo' AND "Email" = 'emily.r@email.com' LIMIT 1;
    INSERT INTO "Appointments" ("TenantId", "PatientId", "ProviderId", "AppointmentDateTime", "DurationMinutes", "AppointmentType", "Status", "ReasonForVisit", "CreatedDate")
    SELECT 'demo', v_patient_id, v_provider_id, today_date + INTERVAL '9 hours', 60, 'Exam/Cleaning', 'Scheduled', 'Routine Cleaning', NOW()
    WHERE NOT EXISTS (SELECT 1 FROM "Appointments" WHERE "PatientId" = v_patient_id AND "AppointmentDateTime" = today_date + INTERVAL '9 hours');

    SELECT "PatientId" INTO v_patient_id FROM "Patients" WHERE "TenantId" = 'demo' AND "Email" = 'marcus.w@email.com' LIMIT 1;
    INSERT INTO "Appointments" ("TenantId", "PatientId", "ProviderId", "AppointmentDateTime", "DurationMinutes", "AppointmentType", "Status", "ReasonForVisit", "CreatedDate")
    SELECT 'demo', v_patient_id, v_provider_id, today_date + INTERVAL '10 hours', 90, 'Crown Prep', 'Scheduled', 'Crown on #14', NOW()
    WHERE NOT EXISTS (SELECT 1 FROM "Appointments" WHERE "PatientId" = v_patient_id AND "AppointmentDateTime" = today_date + INTERVAL '10 hours');

    SELECT "PatientId" INTO v_patient_id FROM "Patients" WHERE "TenantId" = 'demo' AND "Email" = 'sarah.c@email.com' LIMIT 1;
    INSERT INTO "Appointments" ("TenantId", "PatientId", "ProviderId", "AppointmentDateTime", "DurationMinutes", "AppointmentType", "Status", "ReasonForVisit", "CreatedDate")
    SELECT 'demo', v_patient_id, v_provider_id, today_date + INTERVAL '13 hours 30 minutes', 60, 'Exam/Cleaning', 'Scheduled', 'Periodic Exam', NOW()
    WHERE NOT EXISTS (SELECT 1 FROM "Appointments" WHERE "PatientId" = v_patient_id AND "AppointmentDateTime" = today_date + INTERVAL '13 hours 30 minutes');

    SELECT "PatientId" INTO v_patient_id FROM "Patients" WHERE "TenantId" = 'demo' AND "Email" = 'david.k@email.com' LIMIT 1;
    INSERT INTO "Appointments" ("TenantId", "PatientId", "ProviderId", "AppointmentDateTime", "DurationMinutes", "AppointmentType", "Status", "ReasonForVisit", "CreatedDate")
    SELECT 'demo', v_patient_id, v_provider_id, today_date + INTERVAL '15 hours', 30, 'Follow-up', 'Scheduled', 'Post-op Check', NOW()
    WHERE NOT EXISTS (SELECT 1 FROM "Appointments" WHERE "PatientId" = v_patient_id AND "AppointmentDateTime" = today_date + INTERVAL '15 hours');

    -- Tomorrow's Appointments
    SELECT "PatientId" INTO v_patient_id FROM "Patients" WHERE "TenantId" = 'demo' AND "Email" = 'jen.m@email.com' LIMIT 1;
    INSERT INTO "Appointments" ("TenantId", "PatientId", "ProviderId", "AppointmentDateTime", "DurationMinutes", "AppointmentType", "Status", "ReasonForVisit", "CreatedDate")
    SELECT 'demo', v_patient_id, v_provider_id, today_date + INTERVAL '1 day 9 hours', 60, 'Exam/Cleaning', 'Scheduled', 'Annual Checkup', NOW()
    WHERE NOT EXISTS (SELECT 1 FROM "Appointments" WHERE "PatientId" = v_patient_id);

    SELECT "PatientId" INTO v_patient_id FROM "Patients" WHERE "TenantId" = 'demo' AND "Email" = 'rob.t@email.com' LIMIT 1;
    INSERT INTO "Appointments" ("TenantId", "PatientId", "ProviderId", "AppointmentDateTime", "DurationMinutes", "AppointmentType", "Status", "ReasonForVisit", "CreatedDate")
    SELECT 'demo', v_patient_id, v_endo_id, today_date + INTERVAL '1 day 11 hours', 120, 'Root Canal', 'Scheduled', 'Root canal #19', NOW()
    WHERE NOT EXISTS (SELECT 1 FROM "Appointments" WHERE "PatientId" = v_patient_id);

    SELECT "PatientId" INTO v_patient_id FROM "Patients" WHERE "TenantId" = 'demo' AND "Email" = 'lisa.a@email.com' LIMIT 1;
    INSERT INTO "Appointments" ("TenantId", "PatientId", "ProviderId", "AppointmentDateTime", "DurationMinutes", "AppointmentType", "Status", "ReasonForVisit", "CreatedDate")
    SELECT 'demo', v_patient_id, v_provider_id, today_date + INTERVAL '1 day 14 hours', 60, 'Filling', 'Scheduled', 'Composite filling #12', NOW()
    WHERE NOT EXISTS (SELECT 1 FROM "Appointments" WHERE "PatientId" = v_patient_id);

    -- Next Week Appointments
    SELECT "PatientId" INTO v_patient_id FROM "Patients" WHERE "TenantId" = 'demo' AND "Email" = 'james.w@email.com' LIMIT 1;
    INSERT INTO "Appointments" ("TenantId", "PatientId", "ProviderId", "AppointmentDateTime", "DurationMinutes", "AppointmentType", "Status", "ReasonForVisit", "CreatedDate")
    SELECT 'demo', v_patient_id, v_ortho_id, today_date + INTERVAL '3 days 10 hours', 45, 'Ortho Consult', 'Scheduled', 'Orthodontic consultation', NOW()
    WHERE NOT EXISTS (SELECT 1 FROM "Appointments" WHERE "PatientId" = v_patient_id);

    SELECT "PatientId" INTO v_patient_id FROM "Patients" WHERE "TenantId" = 'demo' AND "Email" = 'maria.g@email.com' LIMIT 1;
    INSERT INTO "Appointments" ("TenantId", "PatientId", "ProviderId", "AppointmentDateTime", "DurationMinutes", "AppointmentType", "Status", "ReasonForVisit", "CreatedDate")
    SELECT 'demo', v_patient_id, v_provider_id, today_date + INTERVAL '4 days 9 hours', 60, 'Exam/Cleaning', 'Scheduled', '6-month recall', NOW()
    WHERE NOT EXISTS (SELECT 1 FROM "Appointments" WHERE "PatientId" = v_patient_id);

    SELECT "PatientId" INTO v_patient_id FROM "Patients" WHERE "TenantId" = 'demo' AND "Email" = 'chris.l@email.com' LIMIT 1;
    INSERT INTO "Appointments" ("TenantId", "PatientId", "ProviderId", "AppointmentDateTime", "DurationMinutes", "AppointmentType", "Status", "ReasonForVisit", "CreatedDate")
    SELECT 'demo', v_patient_id, v_provider_id, today_date + INTERVAL '5 days 13 hours', 90, 'Crown Seat', 'Scheduled', 'Seat crown #14', NOW()
    WHERE NOT EXISTS (SELECT 1 FROM "Appointments" WHERE "PatientId" = v_patient_id);

    SELECT "PatientId" INTO v_patient_id FROM "Patients" WHERE "TenantId" = 'demo' AND "Email" = 'amanda.b@email.com' LIMIT 1;
    INSERT INTO "Appointments" ("TenantId", "PatientId", "ProviderId", "AppointmentDateTime", "DurationMinutes", "AppointmentType", "Status", "ReasonForVisit", "CreatedDate")
    SELECT 'demo', v_patient_id, v_provider_id, today_date + INTERVAL '6 days 10 hours', 60, 'Exam/Cleaning', 'Scheduled', 'New patient exam', NOW()
    WHERE NOT EXISTS (SELECT 1 FROM "Appointments" WHERE "PatientId" = v_patient_id);

    SELECT "PatientId" INTO v_patient_id FROM "Patients" WHERE "TenantId" = 'demo' AND "Email" = 'dan.m@email.com' LIMIT 1;
    INSERT INTO "Appointments" ("TenantId", "PatientId", "ProviderId", "AppointmentDateTime", "DurationMinutes", "AppointmentType", "Status", "ReasonForVisit", "CreatedDate")
    SELECT 'demo', v_patient_id, v_provider_id, today_date + INTERVAL '7 days 14 hours', 120, 'Bridge Prep', 'Scheduled', 'Bridge prep #13-15', NOW()
    WHERE NOT EXISTS (SELECT 1 FROM "Appointments" WHERE "PatientId" = v_patient_id);

    -- Add some completed appointments (last week)
    SELECT "PatientId" INTO v_patient_id FROM "Patients" WHERE "TenantId" = 'demo' AND "Email" = 'pat.d@email.com' LIMIT 1;
    INSERT INTO "Appointments" ("TenantId", "PatientId", "ProviderId", "AppointmentDateTime", "DurationMinutes", "AppointmentType", "Status", "ReasonForVisit", "CreatedDate")
    SELECT 'demo', v_patient_id, v_provider_id, today_date - INTERVAL '3 days' + INTERVAL '10 hours', 60, 'Exam/Cleaning', 'Completed', 'Recall exam', NOW() - INTERVAL '3 days'
    WHERE NOT EXISTS (SELECT 1 FROM "Appointments" WHERE "PatientId" = v_patient_id);

    SELECT "PatientId" INTO v_patient_id FROM "Patients" WHERE "TenantId" = 'demo' AND "Email" = 'kevin.t@email.com' LIMIT 1;
    INSERT INTO "Appointments" ("TenantId", "PatientId", "ProviderId", "AppointmentDateTime", "DurationMinutes", "AppointmentType", "Status", "ReasonForVisit", "CreatedDate")
    SELECT 'demo', v_patient_id, v_provider_id, today_date - INTERVAL '5 days' + INTERVAL '14 hours', 90, 'Crown Prep', 'Completed', 'Crown prep #30', NOW() - INTERVAL '5 days'
    WHERE NOT EXISTS (SELECT 1 FROM "Appointments" WHERE "PatientId" = v_patient_id);

    SELECT "PatientId" INTO v_patient_id FROM "Patients" WHERE "TenantId" = 'demo' AND "Email" = 'michelle.w@email.com' LIMIT 1;
    INSERT INTO "Appointments" ("TenantId", "PatientId", "ProviderId", "AppointmentDateTime", "DurationMinutes", "AppointmentType", "Status", "ReasonForVisit", "CreatedDate")
    SELECT 'demo', v_patient_id, v_provider_id, today_date - INTERVAL '7 days' + INTERVAL '9 hours', 60, 'Filling', 'Completed', 'Restoration #14', NOW() - INTERVAL '7 days'
    WHERE NOT EXISTS (SELECT 1 FROM "Appointments" WHERE "PatientId" = v_patient_id);

END $$;

SELECT 'Part 2 Complete: Patient insurance and appointments seeded' AS status;
