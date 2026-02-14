-- Create missing tables from bypassed migrations

-- Create ProcedureCodes table
CREATE TABLE IF NOT EXISTS "ProcedureCodes" (
    "ProcedureCodeId" SERIAL PRIMARY KEY,
    "Code" VARCHAR(10) NOT NULL,
    "Description" VARCHAR(500) NOT NULL,
    "AbbrDesc" VARCHAR(100),
    "DefaultFee" DECIMAL(10,2) NOT NULL,
    "Category" VARCHAR(50),
    "IsActive" BOOLEAN NOT NULL DEFAULT true,
    "CreatedDate" TIMESTAMP NOT NULL DEFAULT NOW(),
    "ModifiedDate" TIMESTAMP
);

-- Create Procedures table
CREATE TABLE IF NOT EXISTS "Procedures" (
    "ProcedureId" SERIAL PRIMARY KEY,
    "TenantId" VARCHAR(64) NOT NULL DEFAULT 'demo',
    "PatientId" INTEGER NOT NULL,
    "ProviderId" INTEGER NOT NULL,
    "AppointmentId" INTEGER,
    "CDTCode" VARCHAR(10) NOT NULL,
    "Description" VARCHAR(500) NOT NULL,
    "ToothNumber" VARCHAR(3),
    "Surface" VARCHAR(10),
    "ServiceDate" TIMESTAMP NOT NULL,
    "ChargeAmount" DECIMAL(10,2) NOT NULL,
    "InsuranceEstimate" DECIMAL(10,2),
    "PatientPortion" DECIMAL(10,2),
    "Status" VARCHAR(20) NOT NULL DEFAULT 'Completed',
    "Notes" VARCHAR(2000),
    "CreatedDate" TIMESTAMP NOT NULL DEFAULT NOW(),
    "ModifiedDate" TIMESTAMP,
    CONSTRAINT "FK_Procedures_Patients_PatientId" FOREIGN KEY ("PatientId") 
        REFERENCES "Patients"("PatientId") ON DELETE RESTRICT,
    CONSTRAINT "FK_Procedures_Providers_ProviderId" FOREIGN KEY ("ProviderId") 
        REFERENCES "Providers"("ProviderId") ON DELETE RESTRICT,
    CONSTRAINT "FK_Procedures_Appointments_AppointmentId" FOREIGN KEY ("AppointmentId") 
        REFERENCES "Appointments"("AppointmentId") ON DELETE SET NULL
);

-- Create ClinicalNotes table
CREATE TABLE IF NOT EXISTS "ClinicalNotes" (
    "ClinicalNoteId" SERIAL PRIMARY KEY,
    "TenantId" VARCHAR(64) NOT NULL DEFAULT 'demo',
    "PatientId" INTEGER NOT NULL,
    "ProviderId" INTEGER,
    "NoteDate" TIMESTAMP NOT NULL,
    "NoteType" VARCHAR(50) NOT NULL DEFAULT 'Clinical',
    "NoteText" VARCHAR(5000) NOT NULL,
    "CreatedBy" VARCHAR(100),
    "IsConfidential" BOOLEAN NOT NULL DEFAULT false,
    "CreatedDate" TIMESTAMP NOT NULL DEFAULT NOW(),
    "ModifiedDate" TIMESTAMP,
    CONSTRAINT "FK_ClinicalNotes_Patients_PatientId" FOREIGN KEY ("PatientId") 
        REFERENCES "Patients"("PatientId") ON DELETE CASCADE,
    CONSTRAINT "FK_ClinicalNotes_Providers_ProviderId" FOREIGN KEY ("ProviderId") 
        REFERENCES "Providers"("ProviderId") ON DELETE SET NULL
);

-- Create indexes
CREATE INDEX IF NOT EXISTS "IX_Procedures_TenantId" ON "Procedures"("TenantId");
CREATE INDEX IF NOT EXISTS "IX_Procedures_PatientId" ON "Procedures"("PatientId");
CREATE INDEX IF NOT EXISTS "IX_Procedures_ProviderId" ON "Procedures"("ProviderId");
CREATE INDEX IF NOT EXISTS "IX_Procedures_AppointmentId" ON "Procedures"("AppointmentId");
CREATE INDEX IF NOT EXISTS "IX_ClinicalNotes_TenantId" ON "ClinicalNotes"("TenantId");
CREATE INDEX IF NOT EXISTS "IX_ClinicalNotes_PatientId" ON "ClinicalNotes"("PatientId");
CREATE INDEX IF NOT EXISTS "IX_ClinicalNotes_ProviderId" ON "ClinicalNotes"("ProviderId");
