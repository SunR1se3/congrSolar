using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace congr.Migrations
{
    public partial class AddImgField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Photo",
                table: "Birthday",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Birthday");
        }
    }
}
