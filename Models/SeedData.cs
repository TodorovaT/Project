using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Project.Areas.Identity.Data;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public class SeedData
    {
        public static async Task CreateUserRoles(IServiceProvider serviceProvider)
        {
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var UserManager = serviceProvider.GetRequiredService<UserManager<ProjectUser>>();
            IdentityResult roleResult;
            //Add Admin Role
            var roleCheck = await RoleManager.RoleExistsAsync("Admin");
            if (!roleCheck) { roleResult = await RoleManager.CreateAsync(new IdentityRole("Admin")); }
            ProjectUser user = await UserManager.FindByEmailAsync("admin@lefeit.com");
            if (user == null)
            {
                var User = new ProjectUser();
                User.Email = "admin@lefeit.com";
                User.UserName = "admin@lefeit.com";
                string userPWD = "Admin123";
                IdentityResult chkUser = await UserManager.CreateAsync(User, userPWD);
                //Add default User to Role Admin
                if (chkUser.Succeeded) { var result1 = await UserManager.AddToRoleAsync(User, "Admin"); }
            }
        }

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ProjectContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ProjectContext>>()))
            {
                CreateUserRoles(serviceProvider).Wait();
                //check if DB has been seeded
                if (context.Guest.Any() || context.Table.Any() || context.Waiter.Any() || context.Reservation.Any())
                {
                    return;
                }

                //adding a base of guests
                context.Guest.AddRange(
                    new Guest { Id = 1, FirstName = "Amy", LastName = "Geller", PhoneNumber = "071111111", Points = 100},
                    new Guest { Id = 2, FirstName = "Leo", LastName = "George", PhoneNumber = "072222222", Points = 0 },
                    new Guest { Id = 3, FirstName = "John", LastName = "Gino", PhoneNumber = "073333333", Points = 50 }
                );
                context.SaveChanges();

                //adding a base of tables
                context.Table.AddRange(
                    new Table { Id = 1, TableNumber = 10, PlacementTable = "inside", SeatsNumber = 4 },
                    new Table { Id = 2, TableNumber = 20, PlacementTable = "garden", SeatsNumber = 6 },
                    new Table { Id = 3, TableNumber = 30, PlacementTable = "balcony", SeatsNumber = 2 }
                );
                context.SaveChanges();

                //adding a base of waiters
                context.Waiter.AddRange(
                    new Waiter { Id = 1, FirstName = "Rory", LastName = "West", HireDate = DateTime.Parse("2020-1-9"), ServingPosition = "inside" },
                    new Waiter { Id = 2, FirstName = "Alex", LastName = "Wallie", HireDate = DateTime.Parse("2015-1-1"), ServingPosition = "garden" },
                    new Waiter { Id = 3, FirstName = "Oscar", LastName = "Wild", HireDate = DateTime.Parse("2021-3-15"), ServingPosition = "balcony" }
                );
                context.SaveChanges();

                //adding a base of reservations 
                context.Reservation.AddRange(
                    new Reservation { Id = 1, NameReservation = "Amy", DateReservation = DateTime.Parse("2022-1-1"), DurationReservation = "5", TableFor = 6, Status = "finished, paid for", GuestId = 1, TableId = 2},
                    new Reservation { Id = 2, NameReservation = "John", DateReservation = DateTime.Parse("2022-2-14"), DurationReservation = "3", TableFor = 2, Status = "future", GuestId = 3, TableId = 3},
                    new Reservation { Id = 3, NameReservation = "Leo", DateReservation = DateTime.Parse("2022-2-11"), DurationReservation = "1.5", TableFor = 4, Status = "ongoing", GuestId = 2, TableId = 1 }
                );
                context.SaveChanges();
            }
        }

    }
}
