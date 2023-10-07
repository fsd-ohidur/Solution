﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Solution.Services.HRAPI.Data;

#nullable disable

namespace Solution.Services.HRAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231003064437_UpdateDesignation")]
    partial class UpdateDesignation
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Solution.Core.Models.Common.Domain.CommonData", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)")
                        .HasColumnOrder(1);

                    b.Property<string>("ComId")
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<string>("CommonName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("CommonType")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .IsRequired()
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ComId");

                    b.ToTable("CommonDatas");
                });

            modelBuilder.Entity("Solution.Core.Models.Common.Domain.Company", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)")
                        .HasColumnOrder(1);

                    b.Property<int>("Basic")
                        .HasColumnType("int");

                    b.Property<string>("ComName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("HRent")
                        .HasColumnType("int");

                    b.Property<bool>("IsInactive")
                        .HasColumnType("bit");

                    b.Property<string>("LastModifiedBy")
                        .IsRequired()
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Medical")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ComName")
                        .IsUnique();

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("Solution.Core.Models.HR.Domain.Attendance", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)")
                        .HasColumnOrder(1);

                    b.Property<string>("AttnStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ComId")
                        .IsRequired()
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmpId")
                        .IsRequired()
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<string>("LastModifiedBy")
                        .IsRequired()
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<TimeSpan>("TimeIn")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("TimeOut")
                        .HasColumnType("time");

                    b.Property<DateTime>("dtDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ComId");

                    b.HasIndex("EmpId");

                    b.ToTable("Attendances");
                });

            modelBuilder.Entity("Solution.Core.Models.HR.Domain.Department", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)")
                        .HasColumnOrder(1);

                    b.Property<string>("ComId")
                        .IsRequired()
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeptName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastModifiedBy")
                        .IsRequired()
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ComId", "DeptName")
                        .IsUnique();

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("Solution.Core.Models.HR.Domain.Designation", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)")
                        .HasColumnOrder(1);

                    b.Property<string>("ComId")
                        .IsRequired()
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DesigName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("DesigNameShort")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastModifiedBy")
                        .IsRequired()
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ComId", "DesigName")
                        .IsUnique();

                    b.ToTable("Designations");
                });

            modelBuilder.Entity("Solution.Core.Models.HR.Domain.Employee", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)")
                        .HasColumnOrder(1);

                    b.Property<int?>("Basic")
                        .HasColumnType("int");

                    b.Property<string>("ComId")
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeptId")
                        .IsRequired()
                        .HasColumnType("nvarchar(36)");

                    b.Property<string>("DesigId")
                        .IsRequired()
                        .HasColumnType("nvarchar(36)");

                    b.Property<string>("EmpCode")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("EmpName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("GenderId")
                        .IsRequired()
                        .HasColumnType("nvarchar(36)");

                    b.Property<int>("Gross")
                        .HasColumnType("int");

                    b.Property<int?>("HRent")
                        .HasColumnType("int");

                    b.Property<string>("LastModifiedBy")
                        .IsRequired()
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Medical")
                        .HasColumnType("int");

                    b.Property<int?>("Other")
                        .HasColumnType("int");

                    b.Property<string>("ShiftId")
                        .IsRequired()
                        .HasColumnType("nvarchar(36)");

                    b.Property<DateTime>("dtJoin")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ComId");

                    b.HasIndex("DeptId");

                    b.HasIndex("DesigId");

                    b.HasIndex("GenderId");

                    b.HasIndex("ShiftId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Solution.Core.Models.HR.Domain.Shift", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)")
                        .HasColumnOrder(1);

                    b.Property<string>("ComId")
                        .IsRequired()
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .IsRequired()
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ShiftName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<TimeSpan>("TimeIn")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("TimeLate")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("TimeOut")
                        .HasColumnType("time");

                    b.HasKey("Id");

                    b.HasIndex("ComId", "ShiftName")
                        .IsUnique();

                    b.ToTable("Shifts");
                });

            modelBuilder.Entity("Solution.Core.Models.Common.Domain.CommonData", b =>
                {
                    b.HasOne("Solution.Core.Models.Common.Domain.Company", "Company")
                        .WithMany()
                        .HasForeignKey("ComId");

                    b.Navigation("Company");
                });

            modelBuilder.Entity("Solution.Core.Models.HR.Domain.Attendance", b =>
                {
                    b.HasOne("Solution.Core.Models.Common.Domain.Company", "Company")
                        .WithMany()
                        .HasForeignKey("ComId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Solution.Core.Models.HR.Domain.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmpId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("Solution.Core.Models.HR.Domain.Department", b =>
                {
                    b.HasOne("Solution.Core.Models.Common.Domain.Company", "Company")
                        .WithMany()
                        .HasForeignKey("ComId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("Solution.Core.Models.HR.Domain.Designation", b =>
                {
                    b.HasOne("Solution.Core.Models.Common.Domain.Company", "Company")
                        .WithMany()
                        .HasForeignKey("ComId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("Solution.Core.Models.HR.Domain.Employee", b =>
                {
                    b.HasOne("Solution.Core.Models.Common.Domain.Company", "Company")
                        .WithMany()
                        .HasForeignKey("ComId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Solution.Core.Models.HR.Domain.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DeptId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Solution.Core.Models.HR.Domain.Designation", "Designation")
                        .WithMany()
                        .HasForeignKey("DesigId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Solution.Core.Models.Common.Domain.CommonData", "Gender")
                        .WithMany()
                        .HasForeignKey("GenderId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Solution.Core.Models.HR.Domain.Shift", "Shift")
                        .WithMany()
                        .HasForeignKey("ShiftId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("Department");

                    b.Navigation("Designation");

                    b.Navigation("Gender");

                    b.Navigation("Shift");
                });

            modelBuilder.Entity("Solution.Core.Models.HR.Domain.Shift", b =>
                {
                    b.HasOne("Solution.Core.Models.Common.Domain.Company", "Company")
                        .WithMany()
                        .HasForeignKey("ComId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Company");
                });
#pragma warning restore 612, 618
        }
    }
}
