-- Quick fix: Add insurance to Mark McCloud
-- This assumes Mark McCloud's PatientId is 1 and we're using the seeded insurance plans

INSERT INTO PatientInsurances (PatientId, InsurancePlanId, MemberId, GroupNumber, RelationshipToSubscriber, SequenceNumber, IsActive, EffectiveDate, CreatedDate, ModifiedDate)
VALUES 
(1, 1, 'MEM' || substr('000000' || 1, -6), 'GRP001', 'Self', 1, 1, date('now'), datetime('now'), datetime('now'));

-- Run this query in your SQLite database to add insurance to the patient
