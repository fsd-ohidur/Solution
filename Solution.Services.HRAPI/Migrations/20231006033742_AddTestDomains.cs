using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Solution.Services.HRAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddTestDomains : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TestParents",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    ParentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ComId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestParents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestParents_Companies_ComId",
                        column: x => x.ComId,
                        principalTable: "Companies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TestChilds",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    ChildName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TestParentId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentId = table.Column<string>(type: "nvarchar(36)", nullable: true),
                    ComId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestChilds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestChilds_Companies_ComId",
                        column: x => x.ComId,
                        principalTable: "Companies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TestChilds_TestParents_ParentId",
                        column: x => x.ParentId,
                        principalTable: "TestParents",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TestChilds_ComId",
                table: "TestChilds",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_TestChilds_ParentId",
                table: "TestChilds",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_TestParents_ComId",
                table: "TestParents",
                column: "ComId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TestChilds");

            migrationBuilder.DropTable(
                name: "TestParents");
        }
    }
}
