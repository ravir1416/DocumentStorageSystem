using System.Collections.Concurrent;
using System.Security.Cryptography;
using System.Text;
using DocumentStorage.Core.Services;

namespace DocumentStorage.Core.Services;

public class AuthService : IAuthService
{
    private readonly ConcurrentDictionary<string, string> _users = new();

    public string Register(string username, string password)
    {
        var hash = Hash(password);
        _users[username] = hash;
        return GenerateToken(username);
    }

    public string Login(string username, string password)
    {
        if (!_users.TryGetValue(username, out var storedHash) || storedHash != Hash(password))
            throw new UnauthorizedAccessException("Invalid credentials.");

        return GenerateToken(username);
    }

    private static string Hash(string input) =>
        Convert.ToBase64String(SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(input)));

    private static string GenerateToken(string username) =>
        $"fake-jwt-token-for-{username}"; // Placeholder for now
}
