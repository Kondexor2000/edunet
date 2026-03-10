using Eduworknet.DTOs;
using Worknet.Services;
using Worknet.Data; // assuming this is where AppDbContext lives
using Eduworknet.Models;
using Microsoft.EntityFrameworkCore;

namespace Worknet.Services
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _context;

        public AuthService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<string?> LoginAsync(LoginDto dto)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == dto.Email);

            if (user == null || user.PasswordHash != dto.Password)
                return null;

            // For demo purposes, return a dummy token
            return "dummy-jwt-token";
        }

        public async Task<string?> RegisterAsync(RegisterDto dto)
        {
            var existingUser = await _context.Users
                .AnyAsync(u => u.Email == dto.Email);
            if (existingUser) return null;

            var user = new ApplicationUser
            {
                Email = dto.Email,
                PasswordHash = dto.Password
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return "dummy-jwt-token";
        }

        public Task<string?> RefreshTokenAsync(string expiredToken)
        {
            // Implement token refresh logic if needed
            return Task.FromResult<string?>("new-dummy-token");
        }

        public Task LogoutAsync(string username)
        {
            // Implement logout logic if needed
            return Task.CompletedTask;
        }
    }
}
