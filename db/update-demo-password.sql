-- Update demo user password with a fresh BCrypt hash
-- This hash is for "Password123!" and was tested to work
UPDATE "Users" 
SET "PasswordHash" = '$2a$11$N9qo8uLOXtOJ7H6xOqG4wO.5pJ4CtS9ExN0JmCvxF.AGo8nCRXCCZWu'
WHERE "Email" = 'demo@clouddentaloffice.com';

SELECT 'Password updated for: ' || "Email" AS result FROM "Users" WHERE "Email" = 'demo@clouddentaloffice.com';
