using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Mail;
using System.Net;
using System.Threading.Tasks;
using System;
using MelonMVCBookshelf.Models;

namespace MelonMVCBookshelf.Extensions
{
    public static class AppBuilderExtension
    {
        public static IApplicationBuilder SeedRoles(this IApplicationBuilder app)
        {
            using IServiceScope scopedServices = app.ApplicationServices.CreateScope();

            IServiceProvider services = scopedServices.ServiceProvider;

            UserManager<User> userManager = services.GetRequiredService<UserManager<User>>();
            RoleManager<IdentityRole> roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

            Task.Run(async () =>
            {
                if (!await roleManager.RoleExistsAsync("Admin"))
                {
                    IdentityRole adminRole = new IdentityRole("Admin");
                    await roleManager.CreateAsync(adminRole);
                }

                if (!await roleManager.RoleExistsAsync("User"))
                {
                    IdentityRole userRole = new IdentityRole("User");
                    await roleManager.CreateAsync(userRole);
                }

                User admin = await userManager.FindByNameAsync("adminname");
                await userManager.AddToRoleAsync(admin, "Admin");

                User testingUser = await userManager.FindByNameAsync("username");
                await userManager.AddToRoleAsync(admin, "User");
            })
            .GetAwaiter()
            .GetResult();

            return app;
        }
    }
}
