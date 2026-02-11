using CloudDentalOffice.Portal.Models;
using Renci.SshNet;
using System.Text;
using SshConnectionInfo = Renci.SshNet.ConnectionInfo;

namespace CloudDentalOffice.Portal.Services;

/// <summary>
/// Uploads X12 EDI files to payer SFTP servers
/// </summary>
public interface IEdiSftpService
{
    Task<string> UploadClaimAsync(Claim claim, InsurancePlan payer, string x12Content);
    Task<bool> TestConnectionAsync(InsurancePlan payer);
}

public class EdiSftpService : IEdiSftpService
{
    private readonly ILogger<EdiSftpService> _logger;

    public EdiSftpService(ILogger<EdiSftpService> logger)
    {
        _logger = logger;
    }

    public async Task<string> UploadClaimAsync(Claim claim, InsurancePlan payer, string x12Content)
    {
        if (string.IsNullOrEmpty(payer.SftpHost))
            throw new InvalidOperationException($"Payer {payer.PayerName} has no SFTP host configured");

        if (string.IsNullOrEmpty(payer.SftpUsername))
            throw new InvalidOperationException($"Payer {payer.PayerName} has no SFTP username configured");

        var port = payer.SftpPort ?? 22;
        var remotePath = payer.SftpRemotePath ?? "/";

        // Generate filename: 837D_CLMNUMBER_YYYYMMDD_HHMMSS.x12
        var timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
        var filename = $"837D_{claim.ClaimNumber}_{timestamp}.x12";
        var fullRemotePath = Path.Combine(remotePath, filename).Replace("\\", "/");

        _logger.LogInformation("Uploading claim {ClaimNumber} to SFTP: {Host}:{Port}{Path}",
            claim.ClaimNumber, payer.SftpHost, port, fullRemotePath);

        try
        {
            // Create connection info
            SshConnectionInfo connectionInfo;

            if (payer.SftpUseSshKey && !string.IsNullOrEmpty(payer.SftpSshKeyEncrypted))
            {
                // Use SSH key authentication
                var privateKey = DecryptValue(payer.SftpSshKeyEncrypted);
                using var keyStream = new MemoryStream(Encoding.UTF8.GetBytes(privateKey));
                var keyFile = new PrivateKeyFile(keyStream);
                var authMethod = new PrivateKeyAuthenticationMethod(payer.SftpUsername, keyFile);
                connectionInfo = new SshConnectionInfo(payer.SftpHost, port, payer.SftpUsername, authMethod);
            }
            else
            {
                // Use password authentication
                var password = DecryptValue(payer.SftpPasswordEncrypted ?? "");
                var authMethod = new PasswordAuthenticationMethod(payer.SftpUsername, password);
                connectionInfo = new SshConnectionInfo(payer.SftpHost, port, payer.SftpUsername, authMethod);
            }

            connectionInfo.Timeout = TimeSpan.FromSeconds(30);

            using var client = new SftpClient(connectionInfo);
            
            // Accept any host key (DEVELOPMENT ONLY - TODO: Implement proper host key validation)
            client.HostKeyReceived += (sender, e) =>
            {
                _logger.LogDebug("Host key received during upload: {KeyType}", e.HostKeyName);
                e.CanTrust = true;
            };

            // Connect
            await Task.Run(() => client.Connect());

            if (!client.IsConnected)
                throw new InvalidOperationException($"Failed to connect to SFTP server {payer.SftpHost}");

            // Upload the file
            using var fileStream = new MemoryStream(Encoding.UTF8.GetBytes(x12Content));
            await Task.Run(() => client.UploadFile(fileStream, fullRemotePath));

            _logger.LogInformation("Successfully uploaded claim {ClaimNumber} to {Host}{Path}",
                claim.ClaimNumber, payer.SftpHost, fullRemotePath);

            client.Disconnect();

            return fullRemotePath;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to upload claim {ClaimNumber} to SFTP server {Host}",
                claim.ClaimNumber, payer.SftpHost);
            throw new InvalidOperationException($"SFTP upload failed: {ex.Message}", ex);
        }
    }

    public async Task<bool> TestConnectionAsync(InsurancePlan payer)
    {
        if (string.IsNullOrEmpty(payer.SftpHost))
        {
            _logger.LogWarning("SFTP host is empty for payer {PayerName}", payer.PayerName);
            return false;
        }

        if (string.IsNullOrEmpty(payer.SftpUsername))
        {
            _logger.LogWarning("SFTP username is empty for payer {PayerName}", payer.PayerName);
            return false;
        }

        var port = payer.SftpPort ?? 22;

        try
        {
            _logger.LogInformation("Testing SFTP connection to {Host}:{Port} as user {Username}", 
                payer.SftpHost, port, payer.SftpUsername);

            SshConnectionInfo connectionInfo;

            if (payer.SftpUseSshKey && !string.IsNullOrEmpty(payer.SftpSshKeyEncrypted))
            {
                var privateKey = DecryptValue(payer.SftpSshKeyEncrypted);
                using var keyStream = new MemoryStream(Encoding.UTF8.GetBytes(privateKey));
                var keyFile = new PrivateKeyFile(keyStream);
                var authMethod = new PrivateKeyAuthenticationMethod(payer.SftpUsername!, keyFile);
                connectionInfo = new SshConnectionInfo(payer.SftpHost, port, payer.SftpUsername!, authMethod);
            }
            else
            {
                var password = DecryptValue(payer.SftpPasswordEncrypted ?? "");
                _logger.LogDebug("Using password authentication (password length: {Length})", password.Length);
                var authMethod = new PasswordAuthenticationMethod(payer.SftpUsername!, password);
                connectionInfo = new SshConnectionInfo(payer.SftpHost, port, payer.SftpUsername!, authMethod);
            }

            // Set timeout and disable host key checking for testing (DEVELOPMENT ONLY)
            connectionInfo.Timeout = TimeSpan.FromSeconds(10);

            using var client = new SftpClient(connectionInfo);
            
            // Accept any host key (DEVELOPMENT ONLY - TODO: Implement proper host key validation)
            client.HostKeyReceived += (sender, e) =>
            {
                _logger.LogInformation("Host key received: {KeyType} {Fingerprint}", 
                    e.HostKeyName, 
                    BitConverter.ToString(e.FingerPrint).Replace("-", ":"));
                e.CanTrust = true; // Accept the host key
            };

            await Task.Run(() => client.Connect());

            var isConnected = client.IsConnected;
            
            if (isConnected)
            {
                _logger.LogInformation("Successfully connected to {Host}:{Port}", payer.SftpHost, port);
                
                // Test that we can access the remote path
                if (!string.IsNullOrEmpty(payer.SftpRemotePath))
                {
                    try
                    {
                        var exists = client.Exists(payer.SftpRemotePath);
                        if (!exists)
                        {
                            _logger.LogWarning("Remote path {Path} does not exist on {Host}", 
                                payer.SftpRemotePath, payer.SftpHost);
                        }
                        else
                        {
                            _logger.LogInformation("Remote path {Path} is accessible", payer.SftpRemotePath);
                        }
                    }
                    catch (Exception ex)
                    {
                        _logger.LogWarning(ex, "Could not verify remote path {Path}", payer.SftpRemotePath);
                    }
                }
                
                client.Disconnect();
            }
            else
            {
                _logger.LogWarning("Connection to {Host}:{Port} succeeded but client not in connected state", 
                    payer.SftpHost, port);
            }

            return isConnected;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "SFTP connection test failed for {Host}:{Port} - {ErrorType}: {Message}", 
                payer.SftpHost, port, ex.GetType().Name, ex.Message);
            return false;
        }
    }

    private string DecryptValue(string encryptedValue)
    {
        // TODO: Implement proper encryption/decryption using Data Protection API
        // For now, store as base64 (NOT SECURE - development only!)
        if (string.IsNullOrEmpty(encryptedValue))
            return string.Empty;

        try
        {
            var bytes = Convert.FromBase64String(encryptedValue);
            return Encoding.UTF8.GetString(bytes);
        }
        catch
        {
            // If not base64, return as-is (for development)
            return encryptedValue;
        }
    }
}
