﻿using ITDeskServer.Context;
using ITDeskServer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ITDeskServer.Middleware;

public static class ExtensionsMiddleware
{
    public static void AutoMigration(WebApplication app)
    {
        using (var scoped = app.Services.CreateScope())
        {
            var context = scoped.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();
        }
    }

    public static void CreateFirstUser(WebApplication app)
    {
        using (var scoped = app.Services.CreateScope())
        {
            var userManager = scoped.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
            if (!userManager.Users.Any())
            {
                userManager.CreateAsync(new AppUser()
                {
                    Email = "test@test.com",
                    UserName = "test",
                    FirstName = "Elif",
                    LastName = "Korkmaz",
                    EmailConfirmed = true
                }, "Password12*").Wait();
            }
        }
    }
}
