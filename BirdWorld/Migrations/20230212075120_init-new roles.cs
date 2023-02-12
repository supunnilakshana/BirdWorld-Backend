using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BirdWorld.Migrations
{
    public partial class initnewroles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "profileUrl",
                table: "AspNetUsers",
                newName: "ProfileUrl");

            migrationBuilder.AddColumn<string>(
                name: "DisplayName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0",
                column: "ConcurrencyStamp",
                value: "26eeec2f-2a03-49ff-b1b7-f0dbb761c9fe");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "ec0c2dbb-e5da-4260-a84a-181706260fcc");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "c97fff96-0a76-41ea-bfec-945dcf956a1a");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DisplayName",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "ProfileUrl",
                table: "AspNetUsers",
                newName: "profileUrl");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0",
                column: "ConcurrencyStamp",
                value: "41bb6fcf-bcde-42d8-ba21-e3c7fd2749e1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "a5436372-8dad-499a-9dc1-f05ba7b6a93f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "686b94aa-165d-429a-ba7e-308a3ac2a9e0");
        }
    }
}
