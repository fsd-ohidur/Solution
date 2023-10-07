using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Solution.Services.HRAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDesignation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DesigNameShort",
                table: "Designations",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DesigNameShort",
                table: "Designations");
        }
    }
}
