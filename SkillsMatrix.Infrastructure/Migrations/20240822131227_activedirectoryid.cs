using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkillsMatrix.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class activedirectoryid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ActiveDirectoryId",
                table: "Users",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActiveDirectoryId",
                table: "Users");
        }
    }
}
