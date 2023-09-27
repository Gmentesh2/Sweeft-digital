using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TeachersAndPupils.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pupils",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    Class = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pupils", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TeacherPupils",
                columns: table => new
                {
                    TeacherId = table.Column<int>(type: "int", nullable: false),
                    PupilId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherPupils", x => new { x.TeacherId, x.PupilId });
                    table.ForeignKey(
                        name: "FK_TeacherPupils_Pupils_PupilId",
                        column: x => x.PupilId,
                        principalTable: "Pupils",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeacherPupils_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Pupils",
                columns: new[] { "Id", "Class", "FirstName", "Gender", "LastName" },
                values: new object[,]
                {
                    { 1, "30-A", "დავით", "M", "დავითაშვილი" },
                    { 2, "30-B", "ელენე", "F", "ელენიძე" },
                    { 3, "30-A", "ანა", "F", "ანანიაშვილი" },
                    { 4, "30-B", "გიორგი", "M", "ჩხარტიშვილი" }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "FirstName", "Gender", "LastName", "Subject" },
                values: new object[,]
                {
                    { 1, "გიორგი", "M", "გიორგაძე", "ბიოლოგია" },
                    { 2, "ზურაბ", "M", "ზურაბიანი", "მათემატიკა" }
                });

            migrationBuilder.InsertData(
                table: "TeacherPupils",
                columns: new[] { "PupilId", "TeacherId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 4, 1 },
                    { 3, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TeacherPupils_PupilId",
                table: "TeacherPupils",
                column: "PupilId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TeacherPupils");

            migrationBuilder.DropTable(
                name: "Pupils");

            migrationBuilder.DropTable(
                name: "Teachers");
        }
    }
}
