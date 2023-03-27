using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BirdWorld.DataAcess.Migrations
{
    public partial class like : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostLike_AspNetUsers_UserId",
                table: "PostLike");

            migrationBuilder.DropForeignKey(
                name: "FK_PostLike_Posts_PostID",
                table: "PostLike");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PostLike",
                table: "PostLike");

            migrationBuilder.RenameTable(
                name: "PostLike",
                newName: "PostLikes");

            migrationBuilder.RenameIndex(
                name: "IX_PostLike_UserId",
                table: "PostLikes",
                newName: "IX_PostLikes_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_PostLike_PostID",
                table: "PostLikes",
                newName: "IX_PostLikes_PostID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostLikes",
                table: "PostLikes",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0",
                column: "ConcurrencyStamp",
                value: "d7efc4e0-39ec-4c0a-811f-0f535686d63a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "994e0f69-bbab-4ec0-8196-9856f45da1d6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "706bc5cf-057e-4610-a6b3-ad2410788b85");

            migrationBuilder.AddForeignKey(
                name: "FK_PostLikes_AspNetUsers_UserId",
                table: "PostLikes",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostLikes_Posts_PostID",
                table: "PostLikes",
                column: "PostID",
                principalTable: "Posts",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostLikes_AspNetUsers_UserId",
                table: "PostLikes");

            migrationBuilder.DropForeignKey(
                name: "FK_PostLikes_Posts_PostID",
                table: "PostLikes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PostLikes",
                table: "PostLikes");

            migrationBuilder.RenameTable(
                name: "PostLikes",
                newName: "PostLike");

            migrationBuilder.RenameIndex(
                name: "IX_PostLikes_UserId",
                table: "PostLike",
                newName: "IX_PostLike_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_PostLikes_PostID",
                table: "PostLike",
                newName: "IX_PostLike_PostID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostLike",
                table: "PostLike",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0",
                column: "ConcurrencyStamp",
                value: "acc324ea-f467-4be0-8137-aa618fbb9f8f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "21841f56-b867-4b0c-b6c7-b955b3f0a2d3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "7a8a0fc3-191a-4542-9cdc-d2698b2ec401");

            migrationBuilder.AddForeignKey(
                name: "FK_PostLike_AspNetUsers_UserId",
                table: "PostLike",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostLike_Posts_PostID",
                table: "PostLike",
                column: "PostID",
                principalTable: "Posts",
                principalColumn: "Id");
        }
    }
}
