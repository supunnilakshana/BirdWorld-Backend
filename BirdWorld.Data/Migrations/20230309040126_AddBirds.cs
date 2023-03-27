using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BirdWorld.DataAcess.Migrations
{
    public partial class AddBirds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0",
                column: "ConcurrencyStamp",
                value: "82fd560b-893c-480b-8df5-c4e31a5f3a6e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "e182d232-df7a-47f8-a22e-a7d381e3c603");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "93135238-7cc3-42de-aaad-ac50f1f600e9");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0",
                column: "ConcurrencyStamp",
                value: "cea68a19-58b0-4500-9ce5-a5b8189b33ab");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "df0358f3-be1f-44d8-8bdd-b90f45683992");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "ad2426b4-0016-4ab2-8135-0e638d762dc8");
        }
    }
}
