using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VirtLab.Migrations
{
    /// <inheritdoc />
    public partial class Finallyyy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_File_Projects_ProjectId",
                table: "File");

            migrationBuilder.DropForeignKey(
                name: "FK_FileVersion_File_FileId",
                table: "FileVersion");

            migrationBuilder.DropForeignKey(
                name: "FK_UserPermission_Projects_ProjectId",
                table: "UserPermission");

            migrationBuilder.DropForeignKey(
                name: "FK_UserPermission_Student_StudentId",
                table: "UserPermission");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserPermission",
                table: "UserPermission");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FileVersion",
                table: "FileVersion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_File",
                table: "File");

            migrationBuilder.RenameTable(
                name: "UserPermission",
                newName: "Permissions");

            migrationBuilder.RenameTable(
                name: "FileVersion",
                newName: "FileVersions");

            migrationBuilder.RenameTable(
                name: "File",
                newName: "Files");

            migrationBuilder.RenameIndex(
                name: "IX_UserPermission_StudentId",
                table: "Permissions",
                newName: "IX_Permissions_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_UserPermission_ProjectId",
                table: "Permissions",
                newName: "IX_Permissions_ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_FileVersion_FileId",
                table: "FileVersions",
                newName: "IX_FileVersions_FileId");

            migrationBuilder.RenameIndex(
                name: "IX_File_ProjectId",
                table: "Files",
                newName: "IX_Files_ProjectId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Permissions",
                table: "Permissions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FileVersions",
                table: "FileVersions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Files",
                table: "Files",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Projects_ProjectId",
                table: "Files",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FileVersions_Files_FileId",
                table: "FileVersions",
                column: "FileId",
                principalTable: "Files",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Permissions_Projects_ProjectId",
                table: "Permissions",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Permissions_Student_StudentId",
                table: "Permissions",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_Projects_ProjectId",
                table: "Files");

            migrationBuilder.DropForeignKey(
                name: "FK_FileVersions_Files_FileId",
                table: "FileVersions");

            migrationBuilder.DropForeignKey(
                name: "FK_Permissions_Projects_ProjectId",
                table: "Permissions");

            migrationBuilder.DropForeignKey(
                name: "FK_Permissions_Student_StudentId",
                table: "Permissions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Permissions",
                table: "Permissions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FileVersions",
                table: "FileVersions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Files",
                table: "Files");

            migrationBuilder.RenameTable(
                name: "Permissions",
                newName: "UserPermission");

            migrationBuilder.RenameTable(
                name: "FileVersions",
                newName: "FileVersion");

            migrationBuilder.RenameTable(
                name: "Files",
                newName: "File");

            migrationBuilder.RenameIndex(
                name: "IX_Permissions_StudentId",
                table: "UserPermission",
                newName: "IX_UserPermission_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_Permissions_ProjectId",
                table: "UserPermission",
                newName: "IX_UserPermission_ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_FileVersions_FileId",
                table: "FileVersion",
                newName: "IX_FileVersion_FileId");

            migrationBuilder.RenameIndex(
                name: "IX_Files_ProjectId",
                table: "File",
                newName: "IX_File_ProjectId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserPermission",
                table: "UserPermission",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FileVersion",
                table: "FileVersion",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_File",
                table: "File",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_File_Projects_ProjectId",
                table: "File",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FileVersion_File_FileId",
                table: "FileVersion",
                column: "FileId",
                principalTable: "File",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserPermission_Projects_ProjectId",
                table: "UserPermission",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserPermission_Student_StudentId",
                table: "UserPermission",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
