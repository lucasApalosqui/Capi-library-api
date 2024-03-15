using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Capi_Library_Api.Migrations
{
    public partial class Alter_Cascade_fk_user_address : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Address",
                table: "Address_Table");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Address",
                table: "Address_Table",
                column: "UserId",
                principalTable: "User_Table",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Address",
                table: "Address_Table");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Address",
                table: "Address_Table",
                column: "UserId",
                principalTable: "User_Table",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
