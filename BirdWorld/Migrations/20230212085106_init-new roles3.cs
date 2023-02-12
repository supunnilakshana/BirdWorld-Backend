using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BirdWorld.Migrations
{
    public partial class initnewroles3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0",
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "339f1d54-4f31-4f10-ab77-21aa396a8930", "ADMIN" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "47c9c539-8db7-45c6-a721-e34bd492ded3", "GUSER" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "1b00b9e4-21ea-4098-8ec4-4e92e7debea0", "SELLER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0",
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "26eeec2f-2a03-49ff-b1b7-f0dbb761c9fe", null });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "ec0c2dbb-e5da-4260-a84a-181706260fcc", null });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "c97fff96-0a76-41ea-bfec-945dcf956a1a", null });
        }
    }
}
