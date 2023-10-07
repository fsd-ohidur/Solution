using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Solution.Services.HRAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDepartment1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DeptNameShort",
                table: "Departments",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeptNameShort",
                table: "Departments");
        }
    }
}
