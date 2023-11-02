using Interdisciplinar2023.Data;
using Microsoft.AspNetCore.Identity;

namespace Interdisciplinar2023.Extensions;

public static class SeedData
{
    public static WebApplication Seed(this WebApplication app)
    {
        using (var scope = app.Services.CreateScope())
        {
            using var context = scope.ServiceProvider.GetRequiredService<DataContext>();
            try
            {
                context.Database.EnsureCreated();

                var users = context.Users.FirstOrDefault();

                if (users == null)
                {
                    var user = new User
                    {
                        UserName = "Administrador",
                        Email = "admin@example.com",
                        NormalizedEmail = "ADMIN@EXAMPLE.COM",
                        EmailConfirmed = true,
                        Phone = "11999999999",
                        Celphone = "1133333333",
                        SecurityStamp = Guid.NewGuid().ToString("D")
                    };

                    context.Users.Add(user);
                    var passwordHasher = new PasswordHasher<User>();
                    user.PasswordHash = passwordHasher.HashPassword(user, "Password1!");

                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return app;
        }
    }
}
