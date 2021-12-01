using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ContactManager.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    ContactId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Organization = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CategoryId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.ContactId);
                    table.ForeignKey(
                        name: "FK_Contacts_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[] { "1", "Friend" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[] { "2", "Work" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[] { "3", "Family" });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "ContactId", "CategoryId", "DateAdded", "Email", "FirstName", "LastName", "Organization", "PhoneNumber" },
                values: new object[] { 1, "1", new DateTime(2021, 11, 25, 21, 25, 44, 454, DateTimeKind.Local).AddTicks(2465), "delores@hotmail.com", "Delores", "Del Rio", null, "555-987-6543" });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "ContactId", "CategoryId", "DateAdded", "Email", "FirstName", "LastName", "Organization", "PhoneNumber" },
                values: new object[] { 2, "2", new DateTime(2008, 11, 30, 21, 25, 44, 456, DateTimeKind.Local).AddTicks(1787), "efren@aol.com", "Efren", "Herrera", null, "555-456-7890" });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "ContactId", "CategoryId", "DateAdded", "Email", "FirstName", "LastName", "Organization", "PhoneNumber" },
                values: new object[] { 3, "3", new DateTime(2021, 11, 30, 21, 25, 44, 456, DateTimeKind.Local).AddTicks(1860), "MaryEllen@yahoo.com", "Mary", "Ellen", null, "555-123-4567" });

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_CategoryId",
                table: "Contacts",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
