using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VirtLab.Migrations
{
    /// <inheritdoc />
    public partial class PrayingThatThisShitWillHelp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProgrammingLanguageProject_ProgrammingLanguages_ProgrammingLanguagesId",
                table: "ProgrammingLanguageProject");

            migrationBuilder.DropForeignKey(
                name: "FK_ProgrammingLanguageProject_Projects_ProjectsId",
                table: "ProgrammingLanguageProject");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTechnology_Projects_ProjectsId",
                table: "ProjectTechnology");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTechnology_Technologies_TechnologiesId",
                table: "ProjectTechnology");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectTechnology",
                table: "ProjectTechnology");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProgrammingLanguageProject",
                table: "ProgrammingLanguageProject");

            migrationBuilder.RenameTable(
                name: "ProjectTechnology",
                newName: "ProjectTechnologies");

            migrationBuilder.RenameTable(
                name: "ProgrammingLanguageProject",
                newName: "ProjectProgrammingLanguages");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectTechnology_TechnologiesId",
                table: "ProjectTechnologies",
                newName: "IX_ProjectTechnologies_TechnologiesId");

            migrationBuilder.RenameIndex(
                name: "IX_ProgrammingLanguageProject_ProjectsId",
                table: "ProjectProgrammingLanguages",
                newName: "IX_ProjectProgrammingLanguages_ProjectsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectTechnologies",
                table: "ProjectTechnologies",
                columns: new[] { "ProjectsId", "TechnologiesId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectProgrammingLanguages",
                table: "ProjectProgrammingLanguages",
                columns: new[] { "ProgrammingLanguagesId", "ProjectsId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectProgrammingLanguages_ProgrammingLanguages_ProgrammingLanguagesId",
                table: "ProjectProgrammingLanguages",
                column: "ProgrammingLanguagesId",
                principalTable: "ProgrammingLanguages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectProgrammingLanguages_Projects_ProjectsId",
                table: "ProjectProgrammingLanguages",
                column: "ProjectsId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectTechnologies_Projects_ProjectsId",
                table: "ProjectTechnologies",
                column: "ProjectsId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectTechnologies_Technologies_TechnologiesId",
                table: "ProjectTechnologies",
                column: "TechnologiesId",
                principalTable: "Technologies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectProgrammingLanguages_ProgrammingLanguages_ProgrammingLanguagesId",
                table: "ProjectProgrammingLanguages");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectProgrammingLanguages_Projects_ProjectsId",
                table: "ProjectProgrammingLanguages");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTechnologies_Projects_ProjectsId",
                table: "ProjectTechnologies");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTechnologies_Technologies_TechnologiesId",
                table: "ProjectTechnologies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectTechnologies",
                table: "ProjectTechnologies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectProgrammingLanguages",
                table: "ProjectProgrammingLanguages");

            migrationBuilder.RenameTable(
                name: "ProjectTechnologies",
                newName: "ProjectTechnology");

            migrationBuilder.RenameTable(
                name: "ProjectProgrammingLanguages",
                newName: "ProgrammingLanguageProject");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectTechnologies_TechnologiesId",
                table: "ProjectTechnology",
                newName: "IX_ProjectTechnology_TechnologiesId");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectProgrammingLanguages_ProjectsId",
                table: "ProgrammingLanguageProject",
                newName: "IX_ProgrammingLanguageProject_ProjectsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectTechnology",
                table: "ProjectTechnology",
                columns: new[] { "ProjectsId", "TechnologiesId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProgrammingLanguageProject",
                table: "ProgrammingLanguageProject",
                columns: new[] { "ProgrammingLanguagesId", "ProjectsId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ProgrammingLanguageProject_ProgrammingLanguages_ProgrammingLanguagesId",
                table: "ProgrammingLanguageProject",
                column: "ProgrammingLanguagesId",
                principalTable: "ProgrammingLanguages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProgrammingLanguageProject_Projects_ProjectsId",
                table: "ProgrammingLanguageProject",
                column: "ProjectsId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectTechnology_Projects_ProjectsId",
                table: "ProjectTechnology",
                column: "ProjectsId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectTechnology_Technologies_TechnologiesId",
                table: "ProjectTechnology",
                column: "TechnologiesId",
                principalTable: "Technologies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
