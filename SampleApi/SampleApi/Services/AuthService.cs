using Microsoft.EntityFrameworkCore;
using SampleApi.Data;
using SampleApi.Data.Entities;
using SampleApi.Models.Request;
using SampleApi.Security;

namespace SampleApi.Services
{
    public interface IAuthService
    {
        Task<User> RegisterUser(RegisterUserRequest request);
    }
    public class AuthService(AppDbContext appDbContext, IPasswordHasher passwordHasher) : IAuthService
    {
        public async Task<User> RegisterUser(RegisterUserRequest request)
        {
            // Check if the user already exists
            var existingUser = await appDbContext.Users.FirstOrDefaultAsync(u => u.Email == request.Email);
            if (existingUser != null) throw new Exception("User already exists");

            User user = new()
            {
                Id = Guid.NewGuid(),
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PasswordHash = passwordHasher.Hash(request.Password),
                CreatedAt = DateTime.UtcNow
            };
            appDbContext.Users.Add(user);
            await appDbContext.SaveChangesAsync();
            return user;
        }
    }
}
