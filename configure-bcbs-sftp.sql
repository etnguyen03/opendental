-- Configure Blue Cross Blue Shield for CloudHealthOffice SFTP
-- This enables EDI submission via SFTP to CloudHealthOffice production server

UPDATE InsurancePlans
SET 
    EdiEnabled = 1,
    EdiSubmissionType = 'SFTP',
    SftpHost = '20.115.193.245',
    SftpPort = 22,
    SftpUsername = 'clouddentaloffice',
    SftpPasswordEncrypted = 'YOUR_BASE64_ENCODED_PASSWORD_HERE',  -- Base64 encoded SFTP password
    SftpRemotePath = '/tenants/clouddentaloffice/dental-claims/inbound/837/',
    SftpUseSshKey = 0,
    ModifiedDate = CURRENT_TIMESTAMP
WHERE PayerName = 'Blue Cross Blue Shield';

-- Verify the configuration:
SELECT 
    PayerId,
    PayerName,
    EdiEnabled,
    EdiSubmissionType AS 'Submission Type',
    SftpHost AS 'SFTP Host',
    SftpPort AS 'Port',
    SftpUsername AS 'Username',
    SftpRemotePath AS 'Remote Path'
FROM InsurancePlans
WHERE PayerName = 'Blue Cross Blue Shield';
