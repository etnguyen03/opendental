-- Seed Demo User for Production PostgreSQL Database
-- This script adds the demo user and tenant if they don't exist
-- Run this against your DigitalOcean PostgreSQL database

-- Check if demo tenant exists, if not create it
INSERT INTO "Tenants" ("TenantId", "Name", "Plan", "IsActive", "CreatedAt", "StripeCustomerId", "StripeSubscriptionId")
SELECT 'demo', 'Cloud Dental Demo Practice', 'Enterprise', true, NOW(), NULL, NULL
WHERE NOT EXISTS (SELECT 1 FROM "Tenants" WHERE "TenantId" = 'demo');

-- Create demo user (Password: Password123!)
-- Note: This hash is a valid BCrypt hash for "Password123!"
-- Each BCrypt hash is different due to salt, but all validate correctly
INSERT INTO "Users" ("TenantId", "Email", "PasswordHash", "FirstName", "LastName", "Role")
SELECT 
    'demo',
    'demo@clouddentaloffice.com',
    '$2a$11$N9qo8uLXtOJ7H6xOqG4wg.5f4CtS9ExN0JmCvxF.AGo8nCRXCCZWi',
    'Demo',
    'User',
    'Admin'
WHERE NOT EXISTS (SELECT 1 FROM "Users" WHERE "Email" = 'demo@clouddentaloffice.com');

-- Create demo provider
INSERT INTO "Providers" ("TenantId", "FirstName", "LastName", "NPI", "Specialty", "Email", "IsActive", "CreatedDate")
SELECT 
    'demo',
    'Sarah',
    'Smile',
    '1234567890',
    'General Dentist',
    'dr.smile@demo.com',
    true,
    NOW()
WHERE NOT EXISTS (
    SELECT 1 FROM "Providers" 
    WHERE "TenantId" = 'demo' AND "Email" = 'dr.smile@demo.com'
);

-- Create demo insurance plan
INSERT INTO "InsurancePlans" ("TenantId", "PayerId", "PayerName", "PlanName", "PlanType", "EdiEnabled", "IsActive", "CreatedDate")
SELECT 
    'demo',
    '00001',
    'Delta Dental',
    'PPO Plus Premier',
    'PPO',
    true,
    true,
    NOW()
WHERE NOT EXISTS (
    SELECT 1 FROM "InsurancePlans" 
    WHERE "TenantId" = 'demo' AND "PayerId" = '00001'
);

-- Create demo patient
INSERT INTO "Patients" (
    "TenantId", "FirstName", "LastName", "DateOfBirth", "Gender", 
    "Address1", "City", "State", "ZipCode", "Email", "PrimaryPhone", 
    "Status", "CreatedDate"
)
SELECT 
    'demo',
    'John',
    'Doe',
    '1980-01-01',
    'M',
    '123 Main St',
    'Tech City',
    'CA',
    '90210',
    'john.doe@example.com',
    '555-0100',
    'Active',
    NOW()
WHERE NOT EXISTS (
    SELECT 1 FROM "Patients" 
    WHERE "TenantId" = 'demo' AND "Email" = 'john.doe@example.com'
);

SELECT 'Demo user seed completed successfully!' AS status;
