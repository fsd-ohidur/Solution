using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Solution.Services.CNFAPI.Migrations
{
    /// <inheritdoc />
    public partial class RemoveForeignKeyComId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Buyers_Company_ComId",
                table: "Buyers");

            migrationBuilder.DropForeignKey(
                name: "FK_Charges_Company_ComId",
                table: "Charges");

            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Company_ComId",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Depots_Company_ComId",
                table: "Depots");

            migrationBuilder.DropForeignKey(
                name: "FK_Exchanges_Company_ComId",
                table: "Exchanges");

            migrationBuilder.DropForeignKey(
                name: "FK_Exporters_Company_ComId",
                table: "Exporters");

            migrationBuilder.DropForeignKey(
                name: "FK_Forwarders_Company_ComId",
                table: "Forwarders");

            migrationBuilder.DropForeignKey(
                name: "FK_Importers_Company_ComId",
                table: "Importers");

            migrationBuilder.DropForeignKey(
                name: "FK_Suppliers_Company_ComId",
                table: "Suppliers");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropIndex(
                name: "IX_Suppliers_ComId",
                table: "Suppliers");

            migrationBuilder.DropIndex(
                name: "IX_Importers_ComId",
                table: "Importers");

            migrationBuilder.DropIndex(
                name: "IX_Forwarders_ComId",
                table: "Forwarders");

            migrationBuilder.DropIndex(
                name: "IX_Exporters_ComId",
                table: "Exporters");

            migrationBuilder.DropIndex(
                name: "IX_Exchanges_ComId",
                table: "Exchanges");

            migrationBuilder.DropIndex(
                name: "IX_Depots_ComId",
                table: "Depots");

            migrationBuilder.DropIndex(
                name: "IX_Clients_ComId",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Charges_ComId",
                table: "Charges");

            migrationBuilder.DropIndex(
                name: "IX_Buyers_ComId",
                table: "Buyers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    Basic = table.Column<int>(type: "int", nullable: false),
                    ComName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HRent = table.Column<int>(type: "int", nullable: false),
                    IsInactive = table.Column<bool>(type: "bit", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Medical = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_ComId",
                table: "Suppliers",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_Importers_ComId",
                table: "Importers",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_Forwarders_ComId",
                table: "Forwarders",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_Exporters_ComId",
                table: "Exporters",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_Exchanges_ComId",
                table: "Exchanges",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_Depots_ComId",
                table: "Depots",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_ComId",
                table: "Clients",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_Charges_ComId",
                table: "Charges",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_Buyers_ComId",
                table: "Buyers",
                column: "ComId");

            migrationBuilder.AddForeignKey(
                name: "FK_Buyers_Company_ComId",
                table: "Buyers",
                column: "ComId",
                principalTable: "Company",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Charges_Company_ComId",
                table: "Charges",
                column: "ComId",
                principalTable: "Company",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Company_ComId",
                table: "Clients",
                column: "ComId",
                principalTable: "Company",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Depots_Company_ComId",
                table: "Depots",
                column: "ComId",
                principalTable: "Company",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Exchanges_Company_ComId",
                table: "Exchanges",
                column: "ComId",
                principalTable: "Company",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Exporters_Company_ComId",
                table: "Exporters",
                column: "ComId",
                principalTable: "Company",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Forwarders_Company_ComId",
                table: "Forwarders",
                column: "ComId",
                principalTable: "Company",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Importers_Company_ComId",
                table: "Importers",
                column: "ComId",
                principalTable: "Company",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Suppliers_Company_ComId",
                table: "Suppliers",
                column: "ComId",
                principalTable: "Company",
                principalColumn: "Id");
        }
    }
}
