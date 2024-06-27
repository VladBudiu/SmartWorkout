﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SmartWorkout.DataAccess;

#nullable disable

namespace SmartWorkout.DataAccess.Migrations
{
    [DbContext(typeof(SmartWorkoutContext))]
    partial class SmartWorkoutContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SmartWorkout.DataAccess.Entities.Exercise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("EXERCISE", (string)null);
                });

            modelBuilder.Entity("SmartWorkout.DataAccess.Entities.ExerciseLog", b =>
                {
                    b.Property<int>("WorkoutId")
                        .HasColumnType("int");

                    b.Property<int>("ExerciseId")
                        .HasColumnType("int");

                    b.HasKey("WorkoutId", "ExerciseId");

                    b.HasIndex("ExerciseId");

                    b.ToTable("EXERCISELOG", (string)null);
                });

            modelBuilder.Entity("SmartWorkout.DataAccess.Entities.Users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("Weight")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("USERS", (string)null);
                });

            modelBuilder.Entity("SmartWorkout.DataAccess.Entities.Workout", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Duration")
                        .HasColumnType("int");

                    b.Property<int>("User_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("User_Id");

                    b.ToTable("WORKOUT", (string)null);
                });

            modelBuilder.Entity("SmartWorkout.DataAccess.Entities.ExerciseLog", b =>
                {
                    b.HasOne("SmartWorkout.DataAccess.Entities.Exercise", "Exercise")
                        .WithMany("ExerciseLogs")
                        .HasForeignKey("ExerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_ExerciseLog_Exercise");

                    b.HasOne("SmartWorkout.DataAccess.Entities.Workout", "Workout")
                        .WithMany("ExerciseLogs")
                        .HasForeignKey("WorkoutId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_ExerciseLog_Workout");

                    b.Navigation("Exercise");

                    b.Navigation("Workout");
                });

            modelBuilder.Entity("SmartWorkout.DataAccess.Entities.Workout", b =>
                {
                    b.HasOne("SmartWorkout.DataAccess.Entities.Users", "User")
                        .WithMany("Workouts")
                        .HasForeignKey("User_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Workout_User");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SmartWorkout.DataAccess.Entities.Exercise", b =>
                {
                    b.Navigation("ExerciseLogs");
                });

            modelBuilder.Entity("SmartWorkout.DataAccess.Entities.Users", b =>
                {
                    b.Navigation("Workouts");
                });

            modelBuilder.Entity("SmartWorkout.DataAccess.Entities.Workout", b =>
                {
                    b.Navigation("ExerciseLogs");
                });
#pragma warning restore 612, 618
        }
    }
}
