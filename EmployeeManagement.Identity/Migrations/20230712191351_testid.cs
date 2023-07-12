using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeManagement.Identity.Migrations
{
    public partial class testid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "75e78390-239f-4c42-8665-fc638a0ebe58");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ffbbf",
                column: "ConcurrencyStamp",
                value: "72b72a0b-736d-4956-9717-2a21322fb624");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2b786231-a24d-4113-a1c6-7454s043cab9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "be3e5eea-7fc9-428c-aa22-9656d3b9b7aa", "AQAAAAEAACcQAAAAEDYXo8ZvLAfDfFa+j3lQRIH9Wy7VVeF355RhstHSmI79i++P7cy4EqdISkJp8PodAA==", "f9c579d5-90e0-456c-9758-0c008ff75af4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e556781-b24d-4443-a1c6-9424d048cdb8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e2fc5bff-4b41-4f77-93b1-25c6fbae95af", "AQAAAAEAACcQAAAAEJXONiQqCez5sID+Ohsg5iLagNr/wE/kqUB4n1SBjQsnwYSWpASI171fhCFtB5bg6A==", "544aa42c-35a7-42c6-af15-8f0fb66e7865" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e556781-b24d-4443-a1c6-9424d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "12c83c1c-aca0-49be-a8a6-0d11eed6eec0", "AQAAAAEAACcQAAAAEE78s1qDJ9iQaCuMX9U51VO8eX5z6VmglhoiMB70JxCDCwL6+cdR101CpFb+lYKllw==", "a2d715ca-0d55-4da8-94e3-1b832d279e57" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "76536c90-20f6-4783-97e6-f7555f795eb3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ffbbf",
                column: "ConcurrencyStamp",
                value: "43f5edcc-1969-4e64-981b-7c221d6cf540");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2b786231-a24d-4113-a1c6-7454s043cab9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5e274805-f02e-46a2-ba0b-aaf2761a3764", "AQAAAAEAACcQAAAAEN8f5OGxGWHR9lEfsZvxWMkPSKc2guZgw6gc58yeSnOHniEr7FPNH73oN5WIGwW/Vw==", "0595292f-21e7-49ce-9ab4-57252a19f4a9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e556781-b24d-4443-a1c6-9424d048cdb8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2dbeef04-566b-4d0b-82e5-fd90dc4af230", "AQAAAAEAACcQAAAAEMU35p1lwBY/m9EV2/1r86Fnni7qif1kZgjpIdfMDcJkB4tW81wdYcAP1x3Q2gW/Ug==", "30869c19-4d8a-43f0-9354-064aa223dfd7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e556781-b24d-4443-a1c6-9424d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "048d942f-f817-4fe4-8e67-1ec148b77ec8", "AQAAAAEAACcQAAAAEMOj6FVhvrlAXGAicmssBwjiU/961XWY4nX66SxRv9Cb71ovebnjh7HXy9Vaf11xZw==", "95f067df-860e-42e6-8a9a-1719d618413e" });
        }
    }
}
