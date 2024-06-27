using Microsoft.EntityFrameworkCore;
using SmartWorkout.DataAccess.Configurations;
using SmartWorkout.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartWorkout.DataAccess
{
    public class SmartWorkoutContext : DbContext
    {

        public SmartWorkoutContext() { }   
        public SmartWorkoutContext(DbContextOptions<SmartWorkoutContext> options) : base (options)
        {
            
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Workout>   Workouts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if (!optionsBuilder.IsConfigured) {
                var connectionString =
                    "Data Source=DESKTOP-TD0N13I\\SQLEXPRESS;Initial Catalog=SmartWorkout;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            new UserConfiguration().Configure(modelBuilder.Entity<Users>());
            new WorkoutConfiguration().Configure(modelBuilder.Entity<Workout>());
        }

    }
}
