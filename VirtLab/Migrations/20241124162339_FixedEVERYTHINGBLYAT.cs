using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VirtLab.Migrations
{
    /// <inheritdoc />
    public partial class FixedEVERYTHINGBLYAT : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "GroupId",
                table: "Students",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Students",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "GroupId",
                table: "Course",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Group",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_GroupId",
                table: "Students",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_UserId",
                table: "Students",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Course_GroupId",
                table: "Course",
                column: "GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Group_GroupId",
                table: "Course",
                column: "GroupId",
                principalTable: "Group",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Group_GroupId",
                table: "Students",
                column: "GroupId",
                principalTable: "Group",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_User_UserId",
                table: "Students",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_Group_GroupId",
                table: "Course");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Group_GroupId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_User_UserId",
                table: "Students");

            migrationBuilder.DropTable(
                name: "Group");

            migrationBuilder.DropIndex(
                name: "IX_Students_GroupId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_UserId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Course_GroupId",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "Course");
        }
    }
}
