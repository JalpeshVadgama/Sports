using Microsoft.AspNetCore.Identity;
using Sports.Models;

namespace Sports.Data
{
    public class SportDataInitializer
    {
        public static void SeedData
            (UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager)
        {
            SeedRoles(roleManager);
            SeedUsers(userManager);
        }

        public static void SeedUsers
             (UserManager<ApplicationUser> userManager)
        {
            string commonPassword = "Admin@123";
            if (userManager.FindByNameAsync("MitchelFausto").Result == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.FirstName = "Mitchel";
                user.LastName = "Fausto";
                user.Email = "Mithel.Fausto@sports.com";
                user.UserName = "MitchelFausto";
                IdentityResult result = userManager.CreateAsync(user, commonPassword).Result;
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user,
                                        "Coach").Wait();
                }
            }

            if (userManager.FindByNameAsync("QueenJacobi").Result == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.FirstName = "Queen";
                user.LastName = "Jacobi";
                user.Email = "Queen.Jacobi@sports.com";
                user.UserName = "QueenJacobi";
                IdentityResult result = userManager.CreateAsync(user, commonPassword).Result;
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user,
                                        "Athlete").Wait();
                }
            }

            if (userManager.FindByNameAsync("MagenFaye").Result == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.FirstName = "Magen";
                user.LastName = "Faye";
                user.Email = "Magen.Faye@sports.com";
                user.UserName = "Magen";
                IdentityResult result = userManager.CreateAsync(user, commonPassword).Result;
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user,
                                        "Athlete").Wait();
                }
            }
            if (userManager.FindByNameAsync("DeliciaLedonne").Result == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.FirstName = "Delicia";
                user.LastName = "Ledonne ";
                user.Email = "Delicia.Ledonne@sports.com";
                user.UserName = "DeliciaLedonne";
                IdentityResult result = userManager.CreateAsync(user, commonPassword).Result;
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user,
                                        "Athlete").Wait();
                }
            }

            if (userManager.FindByNameAsync("CamilleGrantham").Result == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.FirstName = "Camille";
                user.LastName = "Grantham";
                user.Email = "Camille.Grantham@sports.com";
                user.UserName = "CamilleGrantham";
                IdentityResult result = userManager.CreateAsync(user, commonPassword).Result;
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user,
                                        "Athlete").Wait();
                }
            }

            if (userManager.FindByNameAsync("MarcVoth").Result == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.FirstName = "Marc";
                user.LastName = "Voth ";
                user.Email = "Marc.Voth@sports.com";
                user.UserName = "MarcVoth";
                IdentityResult result = userManager.CreateAsync(user, commonPassword).Result;
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user,
                                        "Athlete").Wait();
                }
            }

            if (userManager.FindByNameAsync("RandyRondon").Result == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.FirstName = "Randy";
                user.LastName = "Rondon";
                user.Email = "Randy.Rondon@sports.com";
                user.UserName = "RandyRondon";
                IdentityResult result = userManager.CreateAsync(user, commonPassword).Result;
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user,
                                        "Athlete").Wait();
                }
            }

            if (userManager.FindByNameAsync("DeloraSaville").Result == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.FirstName = "Delora";
                user.LastName = "Saville";
                user.Email = "Delora.Saville@sports.com";
                user.UserName = "DeloraSaville";
                IdentityResult result = userManager.CreateAsync(user, commonPassword).Result;
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user,
                                        "Athlete").Wait();
                }
            }

            if (userManager.FindByNameAsync("RosarioReuben").Result == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.FirstName = "Rosario";
                user.LastName = "Reuben";
                user.Email = "Rosario.Reuben@sports.com";
                user.UserName = "RosarioReuben";
                IdentityResult result = userManager.CreateAsync(user, commonPassword).Result;
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user,
                                        "Athlete").Wait();
                }
            }

            if (userManager.FindByNameAsync("RosarioReuben").Result == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.FirstName = "Rosario";
                user.LastName = "Reuben";
                user.Email = "Rosario.Reuben@sports.com";
                user.UserName = "RosarioReuben";
                IdentityResult result = userManager.CreateAsync(user, commonPassword).Result;
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user,
                                        "Athlete").Wait();
                }
            }

            if (userManager.FindByNameAsync("LulaUhlman").Result == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.FirstName = "Lula";
                user.LastName = "Uhlman";
                user.Email = "Lula.Uhlman@sports.com";
                user.UserName = "LulaUhlman";
                IdentityResult result = userManager.CreateAsync(user, commonPassword).Result;
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user,
                                        "Athlete").Wait();
                }
            }
        }

        public static void SeedRoles
            (RoleManager<ApplicationRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync
                ("Coach").Result)
            {
                ApplicationRole role = new ApplicationRole();
                role.Name = "Coach";
                role.Description = "Coach Role";
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }

            if (!roleManager.RoleExistsAsync
               ("Athlete").Result)
            {
                ApplicationRole role = new ApplicationRole();
                role.Name = "Athlete";
                role.Description = "Athlete Role";
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }
        }
    }
}
