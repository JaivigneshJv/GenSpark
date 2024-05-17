using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaOrderingAPI.Migrations
{
    public partial class RoleBasedAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "PasswordHash", "PasswordSalt", "Role", "Username" },
                values: new object[] { 1, new byte[] { 58, 31, 152, 74, 166, 148, 112, 220, 91, 227, 92, 173, 199, 120, 227, 2, 188, 42, 191, 204, 232, 155, 91, 109, 44, 169, 53, 75, 47, 7, 40, 210, 19, 25, 97, 14, 117, 200, 164, 245, 70, 245, 189, 251, 250, 110, 178, 121, 217, 122, 61, 248, 81, 146, 200, 78, 58, 64, 135, 118, 223, 92, 223, 80 }, new byte[] { 91, 121, 156, 174, 6, 45, 45, 188, 196, 184, 16, 72, 35, 121, 94, 63, 162, 39, 168, 144, 11, 28, 12, 91, 129, 71, 27, 44, 9, 66, 78, 11, 85, 95, 246, 135, 138, 50, 155, 201, 5, 180, 212, 186, 178, 220, 194, 40, 223, 121, 138, 9, 247, 36, 253, 213, 18, 7, 190, 25, 22, 241, 148, 15, 48, 212, 13, 232, 132, 113, 151, 156, 45, 9, 67, 38, 146, 223, 253, 33, 159, 206, 232, 153, 65, 83, 155, 146, 27, 193, 56, 187, 228, 197, 237, 140, 36, 146, 164, 62, 87, 37, 242, 92, 176, 34, 156, 214, 62, 246, 144, 41, 67, 101, 60, 61, 202, 159, 124, 206, 171, 234, 107, 120, 71, 255, 224, 220 }, "Admin", "admin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "PasswordHash", "PasswordSalt", "Role", "Username" },
                values: new object[] { 2, new byte[] { 58, 31, 152, 74, 166, 148, 112, 220, 91, 227, 92, 173, 199, 120, 227, 2, 188, 42, 191, 204, 232, 155, 91, 109, 44, 169, 53, 75, 47, 7, 40, 210, 19, 25, 97, 14, 117, 200, 164, 245, 70, 245, 189, 251, 250, 110, 178, 121, 217, 122, 61, 248, 81, 146, 200, 78, 58, 64, 135, 118, 223, 92, 223, 80 }, new byte[] { 91, 121, 156, 174, 6, 45, 45, 188, 196, 184, 16, 72, 35, 121, 94, 63, 162, 39, 168, 144, 11, 28, 12, 91, 129, 71, 27, 44, 9, 66, 78, 11, 85, 95, 246, 135, 138, 50, 155, 201, 5, 180, 212, 186, 178, 220, 194, 40, 223, 121, 138, 9, 247, 36, 253, 213, 18, 7, 190, 25, 22, 241, 148, 15, 48, 212, 13, 232, 132, 113, 151, 156, 45, 9, 67, 38, 146, 223, 253, 33, 159, 206, 232, 153, 65, 83, 155, 146, 27, 193, 56, 187, 228, 197, 237, 140, 36, 146, 164, 62, 87, 37, 242, 92, 176, 34, 156, 214, 62, 246, 144, 41, 67, 101, 60, 61, 202, 159, 124, 206, 171, 234, 107, 120, 71, 255, 224, 220 }, "Admin", "store1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Users");
        }
    }
}
