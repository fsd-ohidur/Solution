using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Solution.Services.CNFAPI.Migrations
{
    /// <inheritdoc />
    public partial class dbInitCNF : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    ComName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Basic = table.Column<int>(type: "int", nullable: false),
                    HRent = table.Column<int>(type: "int", nullable: false),
                    Medical = table.Column<int>(type: "int", nullable: false),
                    IsInactive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Buyers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    NameFull = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NameShort = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ContName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ContNo = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ContEmail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsDisabled = table.Column<byte>(type: "tinyint", nullable: false),
                    ComId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buyers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Buyers_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Charges",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    NameFull = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Rate = table.Column<double>(type: "float", nullable: false),
                    Flag = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Department = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    IsDisabled = table.Column<byte>(type: "tinyint", nullable: false),
                    ComId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Charges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Charges_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    NameFull = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NameShort = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BillTo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ContName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ContNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ContEmail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsDisabled = table.Column<byte>(type: "tinyint", nullable: false),
                    Flag = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    ComCountFrom = table.Column<long>(type: "bigint", nullable: false),
                    Com300 = table.Column<long>(type: "bigint", nullable: false),
                    Com300Min = table.Column<long>(type: "bigint", nullable: false),
                    Com300Max = table.Column<long>(type: "bigint", nullable: false),
                    Com301 = table.Column<long>(type: "bigint", nullable: false),
                    Com301Min = table.Column<long>(type: "bigint", nullable: false),
                    Com301Max = table.Column<long>(type: "bigint", nullable: false),
                    ComId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clients_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Depots",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    NameFull = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NameShort = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ContName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ContNo = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ContEmail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsDisabled = table.Column<byte>(type: "tinyint", nullable: false),
                    ComId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Depots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Depots_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Exchanges",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    dtExchange = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FromCurrency = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ToCurrency = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Rate = table.Column<double>(type: "float", nullable: false),
                    Flag = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    ComId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exchanges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exchanges_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Exporters",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    NameFull = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NameShort = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ContName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ContNo = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ContEmail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsDisabled = table.Column<byte>(type: "tinyint", nullable: false),
                    ComId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exporters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exporters_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Forwarders",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    NameFull = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NameShort = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ContName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ContNo = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ContEmail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsDisabled = table.Column<byte>(type: "tinyint", nullable: false),
                    ComId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forwarders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Forwarders_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Importers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    NameFull = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NameShort = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ContName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ContNo = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ContEmail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsDisabled = table.Column<byte>(type: "tinyint", nullable: false),
                    BillAddTo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ComRate = table.Column<double>(type: "float", maxLength: 100, nullable: false),
                    ComId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Importers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Importers_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    NameFull = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NameShort = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ContName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ContNo = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ContEmail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsDisabled = table.Column<byte>(type: "tinyint", nullable: false),
                    ComId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Suppliers_Company_ComId",
                        column: x => x.ComId,
                        principalTable: "Company",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Buyers_ComId",
                table: "Buyers",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_Charges_ComId",
                table: "Charges",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_ComId",
                table: "Clients",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_Depots_ComId",
                table: "Depots",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_Exchanges_ComId",
                table: "Exchanges",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_Exporters_ComId",
                table: "Exporters",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_Forwarders_ComId",
                table: "Forwarders",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_Importers_ComId",
                table: "Importers",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_ComId",
                table: "Suppliers",
                column: "ComId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Buyers");

            migrationBuilder.DropTable(
                name: "Charges");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Depots");

            migrationBuilder.DropTable(
                name: "Exchanges");

            migrationBuilder.DropTable(
                name: "Exporters");

            migrationBuilder.DropTable(
                name: "Forwarders");

            migrationBuilder.DropTable(
                name: "Importers");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "Company");
        }
    }
}
