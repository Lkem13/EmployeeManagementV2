using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeManagement.Identity.Migrations
{
    public partial class Admin1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                keyValue: "8e556781-b24d-4443-a1c6-9424d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "048d942f-f817-4fe4-8e67-1ec148b77ec8", "AQAAAAEAACcQAAAAEMOj6FVhvrlAXGAicmssBwjiU/961XWY4nX66SxRv9Cb71ovebnjh7HXy9Vaf11xZw==", "95f067df-860e-42e6-8a9a-1719d618413e" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "8e556781-b24d-4443-a1c6-9424d048cdb8", 0, "2dbeef04-566b-4d0b-82e5-fd90dc4af230", "admin1@localhost.com", true, "System1", "Admin1", false, null, "ADMIN1@LOCALHOST.COM", "ADMIN1@LOCALHOST.COM", "AQAAAAEAACcQAAAAEMU35p1lwBY/m9EV2/1r86Fnni7qif1kZgjpIdfMDcJkB4tW81wdYcAP1x3Q2gW/Ug==", null, false, "30869c19-4d8a-43f0-9354-064aa223dfd7", false, "admin1@localhost.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "cac43a6e-f7bb-4448-baaf-1add431ffbbf", "8e556781-b24d-4443-a1c6-9424d048cdb8" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "cac43a6e-f7bb-4448-baaf-1add431ffbbf", "8e556781-b24d-4443-a1c6-9424d048cdb8" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e556781-b24d-4443-a1c6-9424d048cdb8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "6eaa315e-6ff5-40bd-b6a9-5ffecd799746");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ffbbf",
                column: "ConcurrencyStamp",
                value: "a75ae218-72de-41e7-bc9e-dcf2cf25dc49");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2b786231-a24d-4113-a1c6-7454s043cab9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "224555e5-778c-4f70-98a0-394582b25937", "AQAAAAEAACcQAAAAEC1wB8uAQRH6Xn0//I5r9mFqXtahva5pY1DX6QIc0Ce8G4OKU5QIeJRPDB+2BTMJ/g==", "3951b7bc-a557-4a55-af88-0749823fea79" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e556781-b24d-4443-a1c6-9424d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ec5c2c6d-2c98-4d1d-bf5c-bb559c2c43e9", "AQAAAAEAACcQAAAAEEZMvMfqgU016dqom+snBItG02VnBkwqtjUMfoHW/Vc/wRPopjt7hh7Qmd5RQmlMzA==", "4b074c42-5765-45c6-b334-8794653f04b0" });
        }
    }
}
