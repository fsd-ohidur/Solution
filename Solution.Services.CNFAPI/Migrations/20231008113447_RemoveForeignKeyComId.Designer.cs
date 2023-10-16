﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Solution.Services.CNFAPI.Data;

#nullable disable

namespace Solution.Services.CNFAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231008113447_RemoveForeignKeyComId")]
    partial class RemoveForeignKeyComId
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Solution.Core.Models.CNF.Domain.Buyer", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)")
                        .HasColumnOrder(1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ComId")
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<string>("ContEmail")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ContName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("ContNo")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDisabled")
                        .HasColumnType("bit");

                    b.Property<string>("LastModifiedBy")
                        .IsRequired()
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("NameFull")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NameShort")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Buyers");
                });

            modelBuilder.Entity("Solution.Core.Models.CNF.Domain.Charge", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)")
                        .HasColumnOrder(1);

                    b.Property<string>("ComId")
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Department")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Flag")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<bool>("IsDisabled")
                        .HasColumnType("bit");

                    b.Property<string>("LastModifiedBy")
                        .IsRequired()
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("NameFull")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<double>("Rate")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Charges");
                });

            modelBuilder.Entity("Solution.Core.Models.CNF.Domain.Client", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)")
                        .HasColumnOrder(1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("BillTo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<long>("Com300")
                        .HasColumnType("bigint");

                    b.Property<long>("Com300Max")
                        .HasColumnType("bigint");

                    b.Property<long>("Com300Min")
                        .HasColumnType("bigint");

                    b.Property<long>("Com301")
                        .HasColumnType("bigint");

                    b.Property<long>("Com301Max")
                        .HasColumnType("bigint");

                    b.Property<long>("Com301Min")
                        .HasColumnType("bigint");

                    b.Property<long>("ComCountFrom")
                        .HasColumnType("bigint");

                    b.Property<string>("ComId")
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<string>("ContEmail")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ContName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ContNo")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Flag")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<bool>("IsDisabled")
                        .HasColumnType("bit");

                    b.Property<string>("LastModifiedBy")
                        .IsRequired()
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("NameFull")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NameShort")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("Solution.Core.Models.CNF.Domain.Depot", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)")
                        .HasColumnOrder(1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ComId")
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<string>("ContEmail")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ContName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("ContNo")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDisabled")
                        .HasColumnType("bit");

                    b.Property<string>("LastModifiedBy")
                        .IsRequired()
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("NameFull")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NameShort")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Depots");
                });

            modelBuilder.Entity("Solution.Core.Models.CNF.Domain.Exchange", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)")
                        .HasColumnOrder(1);

                    b.Property<string>("ComId")
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Flag")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("FromCurrency")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("LastModifiedBy")
                        .IsRequired()
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("Rate")
                        .HasColumnType("float");

                    b.Property<string>("ToCurrency")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<DateTime>("dtExchange")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Exchanges");
                });

            modelBuilder.Entity("Solution.Core.Models.CNF.Domain.Exporter", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)")
                        .HasColumnOrder(1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ComId")
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<string>("ContEmail")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ContName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("ContNo")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDisabled")
                        .HasColumnType("bit");

                    b.Property<string>("LastModifiedBy")
                        .IsRequired()
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("NameFull")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NameShort")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Exporters");
                });

            modelBuilder.Entity("Solution.Core.Models.CNF.Domain.Forwarder", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)")
                        .HasColumnOrder(1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ComId")
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<string>("ContEmail")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ContName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("ContNo")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDisabled")
                        .HasColumnType("bit");

                    b.Property<string>("LastModifiedBy")
                        .IsRequired()
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("NameFull")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NameShort")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Forwarders");
                });

            modelBuilder.Entity("Solution.Core.Models.CNF.Domain.Importer", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)")
                        .HasColumnOrder(1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("BillAddTo")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ComId")
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<double>("ComRate")
                        .HasMaxLength(100)
                        .HasColumnType("float");

                    b.Property<string>("ContEmail")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ContName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("ContNo")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDisabled")
                        .HasColumnType("bit");

                    b.Property<string>("LastModifiedBy")
                        .IsRequired()
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("NameFull")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NameShort")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Importers");
                });

            modelBuilder.Entity("Solution.Core.Models.CNF.Domain.Supplier", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)")
                        .HasColumnOrder(1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ComId")
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<string>("ContEmail")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ContName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("ContNo")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDisabled")
                        .HasColumnType("bit");

                    b.Property<string>("LastModifiedBy")
                        .IsRequired()
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("NameFull")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NameShort")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Suppliers");
                });
#pragma warning restore 612, 618
        }
    }
}
