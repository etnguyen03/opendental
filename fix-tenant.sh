#!/bin/bash

# Fix tenant mismatch -change demo data from 'demo' to 'dev' tenant

echo "🔧 Getting database credentials..."
DB_PASS=$(kubectl get secret clouddental-secrets -n clouddental -o jsonpath='{.data.Database__Password}' | base64 -d)
DB_HOST="clouddental-db-do-user-33268551-0.d.db.ondigitalocean.com"
DB_PORT="25060"
DB_USER="doadmin"
DB_NAME="defaultdb"

echo "📝 Updating tenant data..."
export PGPASSWORD="$DB_PASS"

psql -h "$DB_HOST" -p "$DB_PORT" -U "$DB_USER" -d "$DB_NAME" <<EOF
UPDATE "Users" SET "TenantId" = 'dev' WHERE "Email" = 'demo@clouddentaloffice.com';
UPDATE "Tenants" SET "TenantId" = 'dev', "Name" = 'Development Tenant' WHERE "TenantId" = 'demo';
UPDATE "Patients" SET "TenantId" = 'dev' WHERE "TenantId" = 'demo';
UPDATE "Appointments" SET "TenantId" = 'dev' WHERE "TenantId" = 'demo';
UPDATE "Providers" SET "TenantId" = 'dev' WHERE "TenantId" = 'demo';
UPDATE "InsurancePlans" SET "TenantId" = 'dev' WHERE "TenantId" = 'demo';
UPDATE "PatientInsurances" SET "TenantId" = 'dev' WHERE "TenantId" = 'demo';
UPDATE "Claims" SET "TenantId" = 'dev' WHERE "TenantId" = 'demo';
UPDATE "ClaimProcedures" SET "TenantId" = 'dev' WHERE "TenantId" = 'demo';
UPDATE "TreatmentPlans" SET "TenantId" = 'dev' WHERE "TenantId" = 'demo';
UPDATE "Procedures" SET "TenantId" = 'dev' WHERE "TenantId" = 'demo';

SELECT 'Demo User' as entity, "Email", "TenantId" FROM "Users" WHERE "Email" = 'demo@clouddentaloffice.com';
SELECT 'Patients in dev' as metric, COUNT(*)::text as count FROM "Patients" WHERE "TenantId" = 'dev';
SELECT 'Appointments in dev' as metric, COUNT(*)::text as count FROM "Appointments" WHERE "TenantId" = 'dev';
SELECT 'Providers in dev' as metric, COUNT(*)::text as count FROM "Providers" WHERE "TenantId" = 'dev';
EOF

echo "✅ Tenant migration complete!"
echo ""
echo "Next step: Log out and log back in at https://clouddentaloffice.com"
