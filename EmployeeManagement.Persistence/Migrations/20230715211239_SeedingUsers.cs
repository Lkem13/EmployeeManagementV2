using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeManagement.Persistence.Migrations
{
    public partial class SeedingUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "LocationId", "Name", "PositionId", "Surname" },
                values: new object[] { 1, 1, "Roman", 1, "Romanowicz" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "LocationId", "Name", "PositionId", "Surname" },
                values: new object[] { 2, 1, "Marcin", 2, "Gujer" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "LocationId", "Name", "PositionId", "Surname" },
                values: new object[] { 3, 3, "Pawel", 3, "Bak" });
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

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
