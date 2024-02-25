using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Capi_Library_Api.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Book_Table",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "NVARCHAR(250)", maxLength: 250, nullable: false),
                    Sinopsis = table.Column<string>(type: "TEXT", nullable: false),
                    Pages = table.Column<short>(type: "SMALLINT", nullable: false),
                    GeneralAud = table.Column<string>(type: "NVARCHAR(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book_Table", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category_Table",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "NVARCHAR(180)", maxLength: 180, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category_Table", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role_Table",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "NVARCHAR(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role_Table", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Writer_Table",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "NVARCHAR(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Writer_Table", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BookCategory",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookCategory", x => new { x.BookId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_BookCategory_BookId",
                        column: x => x.BookId,
                        principalTable: "Book_Table",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookCategory_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category_Table",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User_Table",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR(200)", maxLength: 200, nullable: false),
                    PasswordHash = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    Cpf = table.Column<string>(type: "VARCHAR(11)", maxLength: 11, nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Table", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Role",
                        column: x => x.RoleId,
                        principalTable: "Role_Table",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookWriter",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false),
                    WriterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookWriter", x => new { x.BookId, x.WriterId });
                    table.ForeignKey(
                        name: "FK_BookWriter_BookId",
                        column: x => x.BookId,
                        principalTable: "Book_Table",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookWriter_WriterId",
                        column: x => x.WriterId,
                        principalTable: "Writer_Table",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Address_Table",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Street = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false),
                    District = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false),
                    State = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false),
                    Number = table.Column<int>(type: "INT", nullable: false),
                    Complement = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false, defaultValue: "Nenhum"),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address_Table", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Address",
                        column: x => x.UserId,
                        principalTable: "User_Table",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Phone_Table",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhoneNumber = table.Column<string>(type: "VARCHAR(11)", maxLength: 11, nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phone_Table", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Phone",
                        column: x => x.UserId,
                        principalTable: "User_Table",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rental_Table",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    GetDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "DATETIME", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rental_Table", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RentalBook",
                        column: x => x.BookId,
                        principalTable: "Book_Table",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RentalUser",
                        column: x => x.UserId,
                        principalTable: "User_Table",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_Table_UserId",
                table: "Address_Table",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BookCategory_CategoryId",
                table: "BookCategory",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_BookWriter_WriterId",
                table: "BookWriter",
                column: "WriterId");

            migrationBuilder.CreateIndex(
                name: "IX_Phone_Table_UserId",
                table: "Phone_Table",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Rental_Table_BookId",
                table: "Rental_Table",
                column: "BookId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rental_Table_UserId",
                table: "Rental_Table",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_Cpf",
                table: "User_Table",
                column: "Cpf",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_Email",
                table: "User_Table",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_Table_RoleId",
                table: "User_Table",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address_Table");

            migrationBuilder.DropTable(
                name: "BookCategory");

            migrationBuilder.DropTable(
                name: "BookWriter");

            migrationBuilder.DropTable(
                name: "Phone_Table");

            migrationBuilder.DropTable(
                name: "Rental_Table");

            migrationBuilder.DropTable(
                name: "Category_Table");

            migrationBuilder.DropTable(
                name: "Writer_Table");

            migrationBuilder.DropTable(
                name: "Book_Table");

            migrationBuilder.DropTable(
                name: "User_Table");

            migrationBuilder.DropTable(
                name: "Role_Table");
        }
    }
}
