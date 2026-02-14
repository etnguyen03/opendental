using System;

// Generate BCrypt hash for "Password123!"
var hash = BCrypt.Net.BCrypt.HashPassword("Password123!");
Console.WriteLine(hash);

// Verify it works
var isValid = BCrypt.Net.BCrypt.Verify("Password123!", hash);
Console.WriteLine($"Verification: {isValid}");
