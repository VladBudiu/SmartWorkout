using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartWorkout.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EXERCISE",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EXERCISE", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EXERCISELOG",
                columns: table => new
                {
                    WorkoutId = table.Column<int>(type: "int", nullable: false),
                    ExerciseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EXERCISELOG", x => new { x.WorkoutId, x.ExerciseId });
                    table.ForeignKey(
                        name: "FK_ExerciseLog_Exercise",
                        column: x => x.ExerciseId,
                        principalTable: "EXERCISE",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExerciseLog_Workout",
                        column: x => x.WorkoutId,
                        principalTable: "WORKOUT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EXERCISELOG_ExerciseId",
                table: "EXERCISELOG",
                column: "ExerciseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EXERCISELOG");

            migrationBuilder.DropTable(
                name: "EXERCISE");
        }
    }
}
