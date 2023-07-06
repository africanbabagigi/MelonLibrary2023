using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Mail;
using System.Net;
using System.Threading.Tasks;
using System;

namespace MelonMVCBookshelf.Extensions
{
    public static class AppBuilderExtension
    {
        public static IApplicationBuilder SeedRoles(this IApplicationBuilder app)
        {
            using IServiceScope scopedServices = app.ApplicationServices.CreateScope();

            IServiceProvider services = scopedServices.ServiceProvider;

            UserManager<IdentityUser> userManager = services.GetRequiredService<UserManager<IdentityUser>>();
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

                IdentityUser admin = await userManager.FindByNameAsync("adminname");
                await userManager.AddToRoleAsync(admin, "Admin");

                IdentityUser testingUser = await userManager.FindByNameAsync("username");
                await userManager.AddToRoleAsync(admin, "User");
            })
            .GetAwaiter()
            .GetResult();

            return app;
        }
    }
}
