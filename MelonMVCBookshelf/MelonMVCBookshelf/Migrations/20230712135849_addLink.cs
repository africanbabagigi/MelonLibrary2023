using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MelonMVCBookshelf.Migrations
{
    public partial class addLink : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WantedResources");

            migrationBuilder.DropColumn(
                name: "NumberOfUsers",
                table: "Request");

            migrationBuilder.AlterColumn<int>(
                name: "ResourceType",
                table: "Resources",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Link",
                table: "Resources",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Request",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Link",
                table: "Request",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Request",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Link",
                table: "Resources");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Request");

            migrationBuilder.DropColumn(
                name: "Link",
                table: "Request");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Request");

            migrationBuilder.AlterColumn<string>(
                name: "ResourceType",
                table: "Resources",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "NumberOfUsers",
                table: "Request",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "WantedResources",
                columns: table => new
                {
                    WantedBookId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    DateOfAdding = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumberOfUsers = table.Column<int>(type: "int", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WantedResources", x => x.WantedBookId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WantedResources_CategoryId",
                table: "WantedResources",
                column: "CategoryId");
        }
    }
}
