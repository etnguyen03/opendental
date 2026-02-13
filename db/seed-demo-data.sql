-- Comprehensive Demo Data Seed Script
-- This script adds realistic demo data for the Cloud Dental Office portal
-- Run this against your production database after initial setup

-- ============================================
-- 1. INSURANCE PAYERS
-- ============================================

-- Delta Dental (already exists, but let's add more plans)
INSERT INTO "InsurancePlans" ("TenantId", "PayerId", "PayerName", "PlanName", "PlanType", "EdiEnabled", "IsActive", "CreatedDate", 
    "SftpHost", "SftpPort", "SftpUsername", "SftpPassword", "SftpUseSshKey", "SftpRemotePath", "SubmissionType")
SELECT 'demo', '87726', 'Delta Dental', 'DeltaCare USA DHMO', 'DHMO', true, true, NOW(),
    'ftp.deltadentalins.com', 22, 'demo_user', 'encrypted_pwd', false, '/outbound', 'SFTP'
WHERE NOT EXISTS (SELECT 1 FROM "InsurancePlans" WHERE "TenantId" = 'demo' AND "PayerId" = '87726');

-- Aetna
INSERT INTO "InsurancePlans" ("TenantId", "PayerId", "PayerName", "PlanName", "PlanType", "EdiEnabled", "IsActive", "CreatedDate",
    "SftpHost", "SftpPort", "SftpUsername", "SftpPassword", "SftpUseSshKey", "SftpRemotePath", "SubmissionType")
SELECT 'demo', '60054', 'Aetna', 'Aetna Dental PPO', 'PPO', true, true, NOW(),
    'edi.aetna.com', 22, 'demo_user', 'encrypted_pwd', false, '/claims', 'API'
WHERE NOT EXISTS (SELECT 1 FROM "InsurancePlans" WHERE "TenantId" = 'demo' AND "PayerId" = '60054');

-- Cigna
INSERT INTO "InsurancePlans" ("TenantId", "PayerId", "PayerName", "PlanName", "PlanType", "EdiEnabled", "IsActive", "CreatedDate",
    "SftpHost", "SftpPort", "SftpUsername", "SftpPassword", "SftpUseSshKey", "SftpRemotePath", "SubmissionType")
SELECT 'demo', '62308', 'Cigna Dental', 'Cigna DPPO', 'PPO', true, true, NOW(),
    'gateway.cigna.com', 22, 'demo_user', 'encrypted_pwd', false, '/claims', 'API'
WHERE NOT EXISTS (SELECT 1 FROM "InsurancePlans" WHERE "TenantId" = 'demo' AND "PayerId" = '62308');

-- MetLife
INSERT INTO "InsurancePlans" ("TenantId", "PayerId", "PayerName", "PlanName", "PlanType", "EdiEnabled", "IsActive", "CreatedDate",
    "SftpHost", "SftpPort", "SftpUsername", "SftpPassword", "SftpUseSshKey", "SftpRemotePath", "SubmissionType")
SELECT 'demo', '98234', 'MetLife', 'MetLife Preferred Dentist', 'PPO', true, true, NOW(),
    'edi.metlife.com', 22, 'demo_user', 'encrypted_pwd', false, '/outbound', 'SFTP'
WHERE NOT EXISTS (SELECT 1 FROM "InsurancePlans" WHERE "TenantId" = 'demo' AND "PayerId" = '98234');

-- Blue Cross Blue Shield
INSERT INTO "InsurancePlans" ("TenantId", "PayerId", "PayerName", "PlanName", "PlanType", "EdiEnabled", "IsActive", "CreatedDate",
    "SftpHost", "SftpPort", "SftpUsername", "SftpPassword", "SftpUseSshKey", "SftpRemotePath", "SubmissionType")
SELECT 'demo', '54771', 'Blue Cross Blue Shield', 'BCBS Dental Blue', 'PPO', true, true, NOW(),
    'claims.bcbs.com', 22, 'demo_user', 'encrypted_pwd', false, '/dental', 'API'
WHERE NOT EXISTS (SELECT 1 FROM "InsurancePlans" WHERE "TenantId" = 'demo' AND "PayerId" = '54771');

-- Guardian
INSERT INTO "InsurancePlans" ("TenantId", "PayerId", "PayerName", "PlanName", "PlanType", "EdiEnabled", "IsActive", "CreatedDate",
    "SftpHost", "SftpPort", "SftpUsername", "SftpPassword", "SftpUseSshKey", "SftpRemotePath", "SubmissionType")
SELECT 'demo', '61101', 'Guardian', 'Guardian DentalGuard', 'PPO', true, true, NOW(),
    'edi.guardianlife.com', 22, 'demo_user', 'encrypted_pwd', false, '/claims', 'SFTP'
WHERE NOT EXISTS (SELECT 1 FROM "InsurancePlans" WHERE "TenantId" = 'demo' AND "PayerId" = '61101');

-- ============================================
-- 2. ADDITIONAL PROVIDERS
-- ============================================

INSERT INTO "Providers" ("TenantId", "FirstName", "LastName", "NPI", "Specialty", "Email", "IsActive", "CreatedDate")
SELECT 'demo', 'Michael', 'Chen', '1982654321', 'Orthodontist', 'dr.chen@demo.com', true, NOW()
WHERE NOT EXISTS (SELECT 1 FROM "Providers" WHERE "TenantId" = 'demo' AND "NPI" = '1982654321');

INSERT INTO "Providers" ("TenantId", "FirstName", "LastName", "NPI", "Specialty", "Email", "IsActive", "CreatedDate")
SELECT 'demo', 'Jennifer', 'Martinez', '1928374650', 'Endodontist', 'dr.martinez@demo.com', true, NOW()
WHERE NOT EXISTS (SELECT 1 FROM "Providers" WHERE "TenantId" = 'demo' AND "NPI" = '1928374650');

INSERT INTO "Providers" ("TenantId", "FirstName", "LastName", "NPI", "Specialty", "Email", "IsActive", "CreatedDate")
SELECT 'demo', 'Robert', 'Johnson', '1564738291', 'Oral Surgeon', 'dr.johnson@demo.com', true, NOW()
WHERE NOT EXISTS (SELECT 1 FROM "Providers" WHERE "TenantId" = 'demo' AND "NPI" = '1564738291');

-- ============================================
-- 3. DEMO PATIENTS (25 patients)
-- ============================================

-- Get provider IDs for appointments
DO $$
DECLARE
    v_provider_id INT;
    v_ortho_id INT;
    v_endo_id INT;
    v_surgeon_id INT;
    v_delta_id INT;
    v_aetna_id INT;
    v_cigna_id INT;
    v_metlife_id INT;
    v_bcbs_id INT;
BEGIN
    SELECT "ProviderId" INTO v_provider_id FROM "Providers" WHERE "TenantId" = 'demo' AND "LastName" = 'Smile' LIMIT 1;
    SELECT "ProviderId" INTO v_ortho_id FROM "Providers" WHERE "TenantId" = 'demo' AND "LastName" = 'Chen' LIMIT 1;
    SELECT "ProviderId" INTO v_endo_id FROM "Providers" WHERE "TenantId" = 'demo' AND "LastName" = 'Martinez' LIMIT 1;
    SELECT "ProviderId" INTO v_surgeon_id FROM "Providers" WHERE "TenantId" = 'demo' AND "LastName" = 'Johnson' LIMIT 1;
    
    SELECT "InsurancePlanId" INTO v_delta_id FROM "InsurancePlans" WHERE "TenantId" = 'demo' AND "PayerId" = '00001' LIMIT 1;
    SELECT "InsurancePlanId" INTO v_aetna_id FROM "InsurancePlans" WHERE "TenantId" = 'demo' AND "PayerId" = '60054' LIMIT 1;
    SELECT "InsurancePlanId" INTO v_cigna_id FROM "InsurancePlans" WHERE "TenantId" = 'demo' AND "PayerId" = '62308' LIMIT 1;
    SELECT "InsurancePlanId" INTO v_metlife_id FROM "InsurancePlans" WHERE "TenantId" = 'demo' AND "PayerId" = '98234' LIMIT 1;
    SELECT "InsurancePlanId" INTO v_bcbs_id FROM "InsurancePlans" WHERE "TenantId" = 'demo' AND "PayerId" = '54771' LIMIT 1;

    -- Patient 1: Emily Rodriguez
    INSERT INTO "Patients" ("TenantId", "FirstName", "LastName", "DateOfBirth", "Gender", "Address1", "City", "State", "ZipCode", "Email", "PrimaryPhone", "Status", "CreatedDate")
    SELECT 'demo', 'Emily', 'Rodriguez', '1992-05-15', 'F', '456 Oak Avenue', 'San Francisco', 'CA', '94105', 'emily.r@email.com', '415-555-0201', 'Active', NOW()
    WHERE NOT EXISTS (SELECT 1 FROM "Patients" WHERE "TenantId" = 'demo' AND "Email" = 'emily.r@email.com');

    -- Patient 2: Marcus Washington
    INSERT INTO "Patients" ("TenantId", "FirstName", "LastName", "DateOfBirth", "Gender", "Address1", "City", "State", "ZipCode", "Email", "PrimaryPhone", "Status", "CreatedDate")
    SELECT 'demo', 'Marcus', 'Washington', '1985-11-22', 'M', '789 Maple Street', 'Oakland', 'CA', '94612', 'marcus.w@email.com', '510-555-0345', 'Active', NOW()
    WHERE NOT EXISTS (SELECT 1 FROM "Patients" WHERE "TenantId" = 'demo' AND "Email" = 'marcus.w@email.com');

    -- Patient 3: Sarah Chen
    INSERT INTO "Patients" ("TenantId", "FirstName", "LastName", "DateOfBirth", "Gender", "Address1", "City", "State", "ZipCode", "Email", "PrimaryPhone", "Status", "CreatedDate")
    SELECT 'demo', 'Sarah', 'Chen', '1978-03-10', 'F', '321 Pine Road', 'Berkeley', 'CA', '94704', 'sarah.c@email.com', '510-555-0789', 'Active', NOW()
    WHERE NOT EXISTS (SELECT 1 FROM "Patients" WHERE "TenantId" = 'demo' AND "Email" = 'sarah.c@email.com');

    -- Patient 4: David Kim
    INSERT INTO "Patients" ("TenantId", "FirstName", "LastName", "DateOfBirth", "Gender", "Address1", "City", "State", "ZipCode", "Email", "PrimaryPhone", "Status", "CreatedDate")
    SELECT 'demo', 'David', 'Kim', '1995-07-28', 'M', '654 Birch Lane', 'San Jose', 'CA', '95112', 'david.k@email.com', '408-555-0123', 'Active', NOW()
    WHERE NOT EXISTS (SELECT 1 FROM "Patients" WHERE "TenantId" = 'demo' AND "Email" = 'david.k@email.com');

    -- Patient 5: Jennifer Martinez
    INSERT INTO "Patients" ("TenantId", "FirstName", "LastName", "DateOfBirth", "Gender", "Address1", "City", "State", "ZipCode", "Email", "PrimaryPhone", "Status", "CreatedDate")
    SELECT 'demo', 'Jennifer', 'Martinez', '1988-12-05', 'F', '987 Cedar Court', 'Palo Alto', 'CA', '94301', 'jen.m@email.com', '650-555-0456', 'Active', NOW()
    WHERE NOT EXISTS (SELECT 1 FROM "Patients" WHERE "TenantId" = 'demo' AND "Email" = 'jen.m@email.com');

    -- Patient 6: Robert Taylor
    INSERT INTO "Patients" ("TenantId", "FirstName", "LastName", "DateOfBirth", "Gender", "Address1", "City", "State", "ZipCode", "Email", "PrimaryPhone", "Status", "CreatedDate")
    SELECT 'demo', 'Robert', 'Taylor', '1970-09-18', 'M', '147 Elm Street', 'Mountain View', 'CA', '94040', 'rob.t@email.com', '650-555-0678', 'Active', NOW()
    WHERE NOT EXISTS (SELECT 1 FROM "Patients" WHERE "TenantId" = 'demo' AND "Email" = 'rob.t@email.com');

    -- Patient 7: Lisa Anderson
    INSERT INTO "Patients" ("TenantId", "FirstName", "LastName", "DateOfBirth", "Gender", "Address1", "City", "State", "ZipCode", "Email", "PrimaryPhone", "Status", "CreatedDate")
    SELECT 'demo', 'Lisa', 'Anderson', '1983-04-25', 'F', '258 Sycamore Drive', 'Sunnyvale', 'CA', '94086', 'lisa.a@email.com', '408-555-0890', 'Active', NOW()
    WHERE NOT EXISTS (SELECT 1 FROM "Patients" WHERE "TenantId" = 'demo' AND "Email" = 'lisa.a@email.com');

    -- Patient 8: James Wilson
    INSERT INTO "Patients" ("TenantId", "FirstName", "LastName", "DateOfBirth", "Gender", "Address1", "City", "State", "ZipCode", "Email", "PrimaryPhone", "Status", "CreatedDate")
    SELECT 'demo', 'James', 'Wilson', '1991-08-14', 'M', '369 Willow Way', 'Santa Clara', 'CA', '95050', 'james.w@email.com', '408-555-01234', 'Active', NOW()
    WHERE NOT EXISTS (SELECT 1 FROM "Patients" WHERE "TenantId" = 'demo' AND "Email" = 'james.w@email.com');

    -- Patient 9: Maria Garcia
    INSERT INTO "Patients" ("TenantId", "FirstName", "LastName", "DateOfBirth", "Gender", "Address1", "City", "State", "ZipCode", "Email", "PrimaryPhone", "Status", "CreatedDate")
    SELECT 'demo', 'Maria', 'Garcia', '1976-06-30', 'F', '741 Redwood Place', 'Fremont', 'CA', '94536', 'maria.g@email.com', '510-555-0345', 'Active', NOW()
    WHERE NOT EXISTS (SELECT 1 FROM "Patients" WHERE "TenantId" = 'demo' AND "Email" = 'maria.g@email.com');

    -- Patient 10: Christopher Lee
    INSERT INTO "Patients" ("TenantId", "FirstName", "LastName", "DateOfBirth", "Gender", "Address1", "City", "State", "ZipCode", "Email", "PrimaryPhone", "Status", "CreatedDate")
    SELECT 'demo', 'Christopher', 'Lee', '1998-01-12', 'M', '852 Poplar Avenue', 'Hayward', 'CA', '94541', 'chris.l@email.com', '510-555-0567', 'Active', NOW()
    WHERE NOT EXISTS (SELECT 1 FROM "Patients" WHERE "TenantId" = 'demo' AND "Email" = 'chris.l@email.com');

    -- Patient 11-25: Additional patients for volume
    INSERT INTO "Patients" ("TenantId", "FirstName", "LastName", "DateOfBirth", "Gender", "Address1", "City", "State", "ZipCode", "Email", "PrimaryPhone", "Status", "CreatedDate")
    SELECT 'demo', 'Amanda', 'Brown', '1987-02-20', 'F', '963 Ash Street', 'San Mateo', 'CA', '94402', 'amanda.b@email.com', '650-555-0789', 'Active', NOW()
    WHERE NOT EXISTS (SELECT 1 FROM "Patients" WHERE "TenantId" = 'demo' AND "Email" = 'amanda.b@email.com');

    INSERT INTO "Patients" ("TenantId", "FirstName", "LastName", "DateOfBirth", "Gender", "Address1", "City", "State", "ZipCode", "Email", "PrimaryPhone", "Status", "CreatedDate")
    SELECT 'demo', 'Daniel', 'Miller', '1993-10-08', 'M', '159 Spruce Road', 'Daly City', 'CA', '94014', 'dan.m@email.com', '415-555-0901', 'Active', NOW()
    WHERE NOT EXISTS (SELECT 1 FROM "Patients" WHERE "TenantId" = 'demo' AND "Email" = 'dan.m@email.com');

    INSERT INTO "Patients" ("TenantId", "FirstName", "LastName", "DateOfBirth", "Gender", "Address1", "City", "State", "ZipCode", "Email", "PrimaryPhone", "Status", "CreatedDate")
    SELECT 'demo', 'Patricia', 'Davis', '1972-05-17', 'F', '753 Walnut Circle', 'Redwood City', 'CA', '94062', 'pat.d@email.com', '650-555-0123', 'Active', NOW()
    WHERE NOT EXISTS (SELECT 1 FROM "Patients" WHERE "TenantId" = 'demo' AND "Email" = 'pat.d@email.com');

    INSERT INTO "Patients" ("TenantId", "FirstName", "LastName", "DateOfBirth", "Gender", "Address1", "City", "State", "ZipCode", "Email", "PrimaryPhone", "Status", "CreatedDate")
    SELECT 'demo', 'Kevin', 'Thompson', '1989-09-03', 'M', '357 Magnolia Lane', 'Milpitas', 'CA', '95035', 'kevin.t@email.com', '408-555-0234', 'Active', NOW()
    WHERE NOT EXISTS (SELECT 1 FROM "Patients" WHERE "TenantId" = 'demo' AND "Email" = 'kevin.t@email.com');

    INSERT INTO "Patients" ("TenantId", "FirstName", "LastName", "DateOfBirth", "Gender", "Address1", "City", "State", "ZipCode", "Email", "PrimaryPhone", "Status", "CreatedDate")
    SELECT 'demo', 'Michelle', 'White', '1996-11-29', 'F', '951 Cypress Street', 'Cupertino', 'CA', '95014', 'michelle.w@email.com', '408-555-0345', 'Active', NOW()
    WHERE NOT EXISTS (SELECT 1 FROM "Patients" WHERE "TenantId" = 'demo' AND "Email" = 'michelle.w@email.com');

    INSERT INTO "Patients" ("TenantId", "FirstName", "LastName", "DateOfBirth", "Gender", "Address1", "City", "State", "ZipCode", "Email", "PrimaryPhone", "Status", "CreatedDate")
    SELECT 'demo', 'Brian', 'Harris', '1981-07-21', 'M', '246 Hickory Drive', 'Campbell', 'CA', '95008', 'brian.h@email.com', '408-555-0456', 'Active', NOW()
    WHERE NOT EXISTS (SELECT 1 FROM "Patients" WHERE "TenantId" = 'demo' AND "Email" = 'brian.h@email.com');

    INSERT INTO "Patients" ("TenantId", "FirstName", "LastName", "DateOfBirth", "Gender", "Address1", "City", "State", "ZipCode", "Email", "PrimaryPhone", "Status", "CreatedDate")
    SELECT 'demo', 'Nancy', 'Clark', '1975-03-06', 'F', '468 Beech Avenue', 'Los Gatos', 'CA', '95032', 'nancy.c@email.com', '408-555-0567', 'Active', NOW()
    WHERE NOT EXISTS (SELECT 1 FROM "Patients" WHERE "TenantId" = 'demo' AND "Email" = 'nancy.c@email.com');

    INSERT INTO "Patients" ("TenantId", "FirstName", "LastName", "DateOfBirth", "Gender", "Address1", "City", "State", "ZipCode", "Email", "PrimaryPhone", "Status", "CreatedDate")
    SELECT 'demo', 'Thomas', 'Lewis', '1990-12-16', 'M', '579 Juniper Court', 'Saratoga', 'CA', '95070', 'tom.l@email.com', '408-555-0678', 'Active', NOW()
    WHERE NOT EXISTS (SELECT 1 FROM "Patients" WHERE "TenantId" = 'demo' AND "Email" = 'tom.l@email.com');

    INSERT INTO "Patients" ("TenantId", "FirstName", "LastName", "DateOfBirth", "Gender", "Address1", "City", "State", "ZipCode", "Email", "PrimaryPhone", "Status", "CreatedDate")
    SELECT 'demo', 'Karen', 'Young', '1984-08-11', 'F', '680 Fir Lane', 'Los Altos', 'CA', '94022', 'karen.y@email.com', '650-555-0789', 'Active', NOW()
    WHERE NOT EXISTS (SELECT 1 FROM "Patients" WHERE "TenantId" = 'demo' AND "Email" = 'karen.y@email.com');

    INSERT INTO "Patients" ("TenantId", "FirstName", "LastName", "DateOfBirth", "Gender", "Address1", "City", "State", "ZipCode", "Email", "PrimaryPhone", "Status", "CreatedDate")
    SELECT 'demo', 'Steven', 'Hall', '1979-04-27', 'M', '791 Cherry Road', 'Menlo Park', 'CA', '94025', 'steve.h@email.com', '650-555-0890', 'Active', NOW()
    WHERE NOT EXISTS (SELECT 1 FROM "Patients" WHERE "TenantId" = 'demo' AND "Email" = 'steve.h@email.com');

    INSERT INTO "Patients" ("TenantId", "FirstName", "LastName", "DateOfBirth", "Gender", "Address1", "City", "State", "ZipCode", "Email", "PrimaryPhone", "Status", "CreatedDate")
    SELECT 'demo', 'Betty', 'Allen', '1968-01-09', 'F', '802 Laurel Way', 'Atherton', 'CA', '94027', 'betty.a@email.com', '650-555-0901', 'Active', NOW()
    WHERE NOT EXISTS (SELECT 1 FROM "Patients" WHERE "TenantId" = 'demo' AND "Email" = 'betty.a@email.com');

    INSERT INTO "Patients" ("TenantId", "FirstName", "LastName", "DateOfBirth", "Gender", "Address1", "City", "State", "ZipCode", "Email", "PrimaryPhone", "Status", "CreatedDate")
    SELECT 'demo', 'George', 'King', '1994-06-13', 'M', '913 Dogwood Place', 'Burlingame', 'CA', '94010', 'george.k@email.com', '650-555-0012', 'Active', NOW()
    WHERE NOT EXISTS (SELECT 1 FROM "Patients" WHERE "TenantId" = 'demo' AND "Email" = 'george.k@email.com');

    INSERT INTO "Patients" ("TenantId", "FirstName", "LastName", "DateOfBirth", "Gender", "Address1", "City", "State", "ZipCode", "Email", "PrimaryPhone", "Status", "CreatedDate")
    SELECT 'demo', 'Helen', 'Wright', '1986-11-24', 'F', '124 Sequoia Drive', 'San Carlos', 'CA', '94070', 'helen.w@email.com', '650-555-0123', 'Active', NOW()
    WHERE NOT EXISTS (SELECT 1 FROM "Patients" WHERE "TenantId" = 'demo' AND "Email" = 'helen.w@email.com');

    INSERT INTO "Patients" ("TenantId", "FirstName", "LastName", "DateOfBirth", "Gender", "Address1", "City", "State", "ZipCode", "Email", "PrimaryPhone", "Status", "CreatedDate")
    SELECT 'demo', 'Paul', 'Lopez', '1974-02-19', 'M', '235 Cottonwood Court', 'Foster City', 'CA', '94404', 'paul.l@email.com', '650-555-0234', 'Active', NOW()
    WHERE NOT EXISTS (SELECT 1 FROM "Patients" WHERE "TenantId" = 'demo' AND "Email" = 'paul.l@email.com');

    INSERT INTO "Patients" ("TenantId", "FirstName", "LastName", "DateOfBirth", "Gender", "Address1", "City", "State", "ZipCode", "Email", "PrimaryPhone", "Status", "CreatedDate")
    SELECT 'demo', 'Dorothy', 'Hill', '1997-09-02', 'F', '346 Mesquite Lane', 'Belmont', 'CA', '94002', 'dorothy.h@email.com', '650-555-0345', 'Active', NOW()
    WHERE NOT EXISTS (SELECT 1 FROM "Patients" WHERE "TenantId" = 'demo' AND "Email" = 'dorothy.h@email.com');

END $$;

-- Continue in next file (Part 2) due to length...
SELECT 'Part 1 Complete: Insurance plans, providers, and patients seeded' AS status;
