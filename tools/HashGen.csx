#r "nuget: BCrypt.Net-Next, 4.0.3"
using BCrypt.Net;
var hash = BCrypt.HashPassword("Password123!");
Console.WriteLine(hash);
