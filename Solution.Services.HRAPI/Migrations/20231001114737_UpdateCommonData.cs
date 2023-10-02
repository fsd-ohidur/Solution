using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Solution.Services.HRAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCommonData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ComId",
                table: "CommonDatas",
                type: "nvarchar(36)",
                maxLength: 36,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CommonDatas_ComId",
                table: "CommonDatas",
                column: "ComId");

            migrationBuilder.AddForeignKey(
                name: "FK_CommonDatas_Companies_ComId",
                table: "CommonDatas",
                column: "ComId",
                principalTable: "Companies",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommonDatas_Companies_ComId",
                table: "CommonDatas");

            migrationBuilder.DropIndex(
                name: "IX_CommonDatas_ComId",
                table: "CommonDatas");

            migrationBuilder.DropColumn(
                name: "ComId",
                table: "CommonDatas");
        }
    }
}
