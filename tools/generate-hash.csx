#!/usr/bin/env dotnet-script
#r "nuget: BCrypt.Net-Next, 4.0.3"

using BCrypt.Net;

var password = "Password123!";
var hash = BCrypt.Net.BCrypt.HashPassword(password);

Console.WriteLine($"Password: {password}");
Console.WriteLine($"Hash: {hash}");
