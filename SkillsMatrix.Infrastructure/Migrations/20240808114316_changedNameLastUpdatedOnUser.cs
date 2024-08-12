using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkillsMatrix.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class changedNameLastUpdatedOnUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastUpdated",
                table: "Users",
                newName: "LastSurvey");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastSurvey",
                table: "Users",
                newName: "LastUpdated");
        }
    }
}
