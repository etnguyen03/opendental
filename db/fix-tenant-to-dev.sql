-- Update all demo data from tenant 'demo' to 'dev'
-- This allows data to be visible with the current HttpContextTenantProvider default

UPDATE "Users" 
SET "TenantId" = 'dev' 
WHERE "Email" = 'demo@clouddentaloffice.com';

UPDATE "Tenants" 
SET "TenantId" = 'dev', "Name" = 'Development Tenant' 
WHERE "TenantId" = 'demo';

UPDATE "Patients" 
SET "TenantId" = 'dev' 
WHERE "TenantId" = 'demo';

UPDATE "Appointments" 
SET "TenantId" = 'dev' 
WHERE "TenantId" = 'demo';

UPDATE "Providers" 
SET "TenantId" = 'dev' 
WHERE "TenantId" = 'demo';

UPDATE "InsurancePlans" 
SET "TenantId" = 'dev' 
WHERE "TenantId" = 'demo';

UPDATE "PatientInsurances" 
SET "TenantId" = 'dev' 
WHERE "TenantId" = 'demo';

UPDATE "Claims" 
SET "TenantId" = 'dev' 
WHERE "TenantId" = 'demo';

UPDATE "ClaimProcedures" 
SET "TenantId" = 'dev' 
WHERE "TenantId" = 'demo';

UPDATE "TreatmentPlans" 
SET "TenantId" = 'dev' 
WHERE "TenantId" = 'demo';

UPDATE "Procedures" 
SET "TenantId" = 'dev' 
WHERE "TenantId" = 'demo';

-- Verify the migration
SELECT 'Demo User' as entity, "Email", "TenantId" 
FROM "Users" 
WHERE "Email" = 'demo@clouddentaloffice.com';

SELECT 'Patients (dev)' as entity, COUNT(*)::text as count, 'dev' as tenant
FROM "Patients" 
WHERE "TenantId" = 'dev';

SELECT 'Appointments (dev)' as entity, COUNT(*)::text as count, 'dev' as tenant
FROM "Appointments" 
WHERE "TenantId" = 'dev';

SELECT 'Providers (dev)' as entity, COUNT(*)::text as count, 'dev' as tenant
FROM "Providers" 
WHERE "TenantId" = 'dev';
