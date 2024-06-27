using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SmartWorkout.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartWorkout.DataAccess.Configurations
{
    public class WorkoutConfiguration : IEntityTypeConfiguration<Workout>
    {
        public void Configure(EntityTypeBuilder<Workout> builder)
        {
            builder.ToTable("WORKOUT").HasKey(w => w.Id);

            builder.Property(w => w.Date).IsRequired();

            builder.HasOne(w => w.User)
                .WithMany(u => u.Workouts).HasForeignKey(w => w.User_Id).HasConstraintName("FK_Workout_User");

        }
    }
}
