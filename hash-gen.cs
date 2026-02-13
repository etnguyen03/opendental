using System;

class Program {
    static void Main() {
        var hash = BCrypt.Net.BCrypt.HashPassword("Password123!");
        Console.WriteLine(hash);
    }
}
