using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicManagementAPI.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Speciality = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Experience = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "Contact", "Experience", "Name", "Speciality" },
                values: new object[] { 1, "1234567890", 10, "Dr. John Doe", "Cardiology" });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "Contact", "Experience", "Name", "Speciality" },
                values: new object[] { 2, "0987654321", 8, "Dr. Jane Smith", "Dermatology" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Doctors");
        }
    }
}
