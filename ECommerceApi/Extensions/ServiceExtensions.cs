using ECommerceApi.Infrastructure.Data;
using ECommerceApi.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;

namespace ECommerceApi.Extensions
{
    public static class ServiceExtensions
    {
        public static async Task SeedDatabaseAsync(this WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<ApplicationDbContext>();
                var userManager = services.GetRequiredService<UserManager<IdentityUser>>();
                var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

                // Create roles if they don't exist
                if (!await roleManager.RoleExistsAsync(Roles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(Roles.Admin));

                if (!await roleManager.RoleExistsAsync(Roles.Manager))
                    await roleManager.CreateAsync(new IdentityRole(Roles.Manager));

                if (!await roleManager.RoleExistsAsync(Roles.Customer))
                    await roleManager.CreateAsync(new IdentityRole(Roles.Customer));

                // Create admin user if it doesn't exist
                var adminUser = await userManager.FindByEmailAsync("admin@example.com");
                if (adminUser == null)
                {
                    adminUser = new IdentityUser
                    {
                        UserName = "admin@example.com",
                        Email = "admin@example.com",
                        EmailConfirmed = true
                    };

                    await userManager.CreateAsync(adminUser, "Admin123!");
                    await userManager.AddToRoleAsync(adminUser, Roles.Admin);
                }

                // Create manager user if it doesn't exist
                var managerUser = await userManager.FindByEmailAsync("manager@example.com");
                if (managerUser == null)
                {
                    managerUser = new IdentityUser
                    {
                        UserName = "manager@example.com",
                        Email = "manager@example.com",
                        EmailConfirmed = true
                    };

                    await userManager.CreateAsync(managerUser, "Manager123!");
                    await userManager.AddToRoleAsync(managerUser, Roles.Manager);
                }

                // Seed some categories and products if the database is empty
                if (!context.Categories.Any())
                {
                    context.Categories.AddRange(
                        new Domain.Entities.Category { Name = "Electronics", Description = "Electronic items and gadgets" },
                        new Domain.Entities.Category { Name = "Clothing", Description = "Clothing and apparel" },
                        new Domain.Entities.Category { Name = "Books", Description = "Books and literature" }
                    );
                    await context.SaveChangesAsync();
                }

                if (!context.Products.Any())
                {
                    context.Products.AddRange(
                        new Domain.Entities.Product
                        {
                            Name = "Laptop",
                            Description = "High-performance laptop with 16GB RAM",
                            Price = 999.99m,
                            StockQuantity = 10,
                            CategoryId = 1,
                            ImageUrl = "/images/laptop.jpg"
                        },
                        new Domain.Entities.Product
                        {
                            Name = "T-Shirt",
                            Description = "Cotton T-Shirt, available in multiple colors",
                            Price = 19.99m,
                            StockQuantity = 100,
                            CategoryId = 2,
                            ImageUrl = "/images/tshirt.jpg"
                        },
                        new Domain.Entities.Product
                        {
                            Name = "Programming C#",
                            Description = "Learn C# programming from basics to advanced",
                            Price = 39.99m,
                            StockQuantity = 50,
                            CategoryId = 3,
                            ImageUrl = "/images/csharp-book.jpg"
                        }
                    );
                    await context.SaveChangesAsync();
                }
            }
        }
    }
}
