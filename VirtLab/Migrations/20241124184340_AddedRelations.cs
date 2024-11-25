using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VirtLab.Migrations
{
    /// <inheritdoc />
    public partial class AddedRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Students_OwnerId",
                table: "Projects");

            migrationBuilder.AddColumn<Guid>(
                name: "DeadlineId",
                table: "Projects",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Deadline",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deadline", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectParticipants",
                columns: table => new
                {
                    ParticipantsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ParticipatedProjectsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectParticipants", x => new { x.ParticipantsId, x.ParticipatedProjectsId });
                    table.ForeignKey(
                        name: "FK_ProjectParticipants_Projects_ParticipatedProjectsId",
                        column: x => x.ParticipatedProjectsId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectParticipants_Students_ParticipantsId",
                        column: x => x.ParticipantsId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Projects_DeadlineId",
                table: "Projects",
                column: "DeadlineId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectParticipants_ParticipatedProjectsId",
                table: "ProjectParticipants",
                column: "ParticipatedProjectsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Deadline_DeadlineId",
                table: "Projects",
                column: "DeadlineId",
                principalTable: "Deadline",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Students_OwnerId",
                table: "Projects",
                column: "OwnerId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Deadline_DeadlineId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Students_OwnerId",
                table: "Projects");

            migrationBuilder.DropTable(
                name: "Deadline");

            migrationBuilder.DropTable(
                name: "ProjectParticipants");

            migrationBuilder.DropIndex(
                name: "IX_Projects_DeadlineId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "DeadlineId",
                table: "Projects");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Students_OwnerId",
                table: "Projects",
                column: "OwnerId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
