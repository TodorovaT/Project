using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Project.Areas.Identity.Data;
using Project.Models;

namespace Project.Models
{
    public class ProjectContext : IdentityDbContext<ProjectUser>
    {
        public ProjectContext (DbContextOptions<ProjectContext> options)
            : base(options)
        {
        }

        public DbSet<Project.Models.Guest> Guest { get; set; }

        public DbSet<Project.Models.Reservation> Reservation { get; set; }

        public DbSet<Project.Models.Table> Table { get; set; }

        public DbSet<Project.Models.Waiter> Waiter { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        /*protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Reservation>()
                .HasOne<Guest>(p => p.Guest)
                .WithMany(p => p.Reservations)
                .HasForeignKey(p => p.GuestId);

            builder.Entity<Reservation>()
                .HasOne<Table>(p => p.Table)
                .WithMany(p => p.Reservations)
                .HasForeignKey(p => p.TableId);

            builder.Entity<Table>()
                .HasOne<Waiter>(p => p.Waiter)
                .WithMany(p => p.Tables)
                .HasForeignKey(p => p.WaiterId);
        }*/

    }
}
