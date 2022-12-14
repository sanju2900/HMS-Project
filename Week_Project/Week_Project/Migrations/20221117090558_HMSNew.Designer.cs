// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Week_Project;
using Week_Project.Data;

#nullable disable

namespace WeekProject.Migrations
{
    [DbContext(typeof(Week_ProjectContext))]
    [Migration("20221117090558_HMSNew")]
    partial class HMSNew
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Week_Project.Models.Admin_pg", b =>
                {
                    b.Property<int>("Admin_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Admin_Id"));

                    b.Property<string>("Admin_Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Admin_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Admin_password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Doctor_DetailDr_id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("Patient_id")
                        .HasColumnType("int");

                    b.HasKey("Admin_Id");

                    b.HasIndex("Doctor_DetailDr_id");

                    b.HasIndex("Patient_id");

                    b.ToTable("Admin_Pgs");
                });

            modelBuilder.Entity("Week_Project.Models.Doctor_Detail", b =>
                {
                    b.Property<string>("Dr_id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<long>("Dr_Number")
                        .HasColumnType("bigint");

                    b.Property<string>("Dr_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Dr_pofile")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("begin_time")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("end_time")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Dr_id");

                    b.ToTable("Doctor_Details");
                });

            modelBuilder.Entity("Week_Project.Models.Patient", b =>
                {
                    b.Property<int>("Patient_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Patient_id"));

                    b.Property<string>("Patient_Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Patient_DOB")
                        .HasColumnType("datetime2");

                    b.Property<string>("Patient_Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Patient_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Patient_Problem")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Patient_email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Patient_number")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("Todays_date")
                        .HasColumnType("datetime2");

                    b.HasKey("Patient_id");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("Week_Project.Models.Admin_pg", b =>
                {
                    b.HasOne("Week_Project.Models.Doctor_Detail", null)
                        .WithMany("Admin_pgs")
                        .HasForeignKey("Doctor_DetailDr_id");

                    b.HasOne("Week_Project.Models.Patient", null)
                        .WithMany("Admin_Pgs")
                        .HasForeignKey("Patient_id");
                });

            modelBuilder.Entity("Week_Project.Models.Doctor_Detail", b =>
                {
                    b.Navigation("Admin_pgs");
                });

            modelBuilder.Entity("Week_Project.Models.Patient", b =>
                {
                    b.Navigation("Admin_Pgs");
                });
#pragma warning restore 612, 618
        }
    }
}
