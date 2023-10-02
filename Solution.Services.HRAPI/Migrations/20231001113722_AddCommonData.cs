using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Solution.Services.HRAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddCommonData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Genders_GenderId",
                table: "Employees");

            migrationBuilder.DropTable(
                name: "Genders");

            migrationBuilder.CreateTable(
                name: "CommonDatas",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    CommonName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CommonType = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommonDatas", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_CommonDatas_GenderId",
                table: "Employees",
                column: "GenderId",
                principalTable: "CommonDatas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_CommonDatas_GenderId",
                table: "Employees");

            migrationBuilder.DropTable(
                name: "CommonDatas");

            migrationBuilder.CreateTable(
                name: "Genders",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GenderName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genders", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Genders_GenderId",
                table: "Employees",
                column: "GenderId",
                principalTable: "Genders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
