using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartWorkout.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartWorkout.DataAccess.Configurations
{
    public class ExerciseLogConfiguration : IEntityTypeConfiguration<ExerciseLog>
    {
        public void Configure(EntityTypeBuilder<ExerciseLog> builder)
        {
            builder.ToTable("EXERCISELOG");

            builder.HasKey(e => new { e.WorkoutId, e.ExerciseId });

            builder.HasOne(el => el.Workout)
              .WithMany(w => w.ExerciseLogs)
              .HasForeignKey(el => el.WorkoutId)
              .HasConstraintName("FK_ExerciseLog_Workout");

            builder.HasOne(el => el.Exercise)
                .WithMany(e => e.ExerciseLogs)
                .HasForeignKey(el => el.ExerciseId)
                .HasConstraintName("FK_ExerciseLog_Exercise");
        }
    }
}
