using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeekProject.Migrations
{
    /// <inheritdoc />
    public partial class HMS1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doctor_Details",
                columns: table => new
                {
                    Drid = table.Column<string>(name: "Dr_id", type: "nvarchar(450)", nullable: false),
                    Drname = table.Column<string>(name: "Dr_name", type: "nvarchar(max)", nullable: false),
                    Drpofile = table.Column<string>(name: "Dr_pofile", type: "nvarchar(max)", nullable: false),
                    DrNumber = table.Column<int>(name: "Dr_Number", type: "int", nullable: false),
                    begintime = table.Column<string>(name: "begin_time", type: "nvarchar(max)", nullable: false),
                    endtime = table.Column<string>(name: "end_time", type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctor_Details", x => x.Drid);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Patientid = table.Column<int>(name: "Patient_id", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientName = table.Column<string>(name: "Patient_Name", type: "nvarchar(max)", nullable: false),
                    PatientDOB = table.Column<DateTime>(name: "Patient_DOB", type: "datetime2", nullable: true),
                    PatientGender = table.Column<string>(name: "Patient_Gender", type: "nvarchar(max)", nullable: false),
                    Patientnumber = table.Column<int>(name: "Patient_number", type: "int", nullable: false),
                    Patientemail = table.Column<string>(name: "Patient_email", type: "nvarchar(max)", nullable: false),
                    PatientAddress = table.Column<string>(name: "Patient_Address", type: "nvarchar(max)", nullable: false),
                    PatientProblem = table.Column<string>(name: "Patient_Problem", type: "nvarchar(max)", nullable: false),
                    Todaysdate = table.Column<DateTime>(name: "Todays_date", type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Patientid);
                });

            migrationBuilder.CreateTable(
                name: "Admin_Pgs",
                columns: table => new
                {
                    AdminId = table.Column<int>(name: "Admin_Id", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdminName = table.Column<string>(name: "Admin_Name", type: "nvarchar(max)", nullable: false),
                    AdminEmail = table.Column<string>(name: "Admin_Email", type: "nvarchar(max)", nullable: false),
                    Adminpassword = table.Column<string>(name: "Admin_password", type: "nvarchar(max)", nullable: false),
                    DoctorDetailDrid = table.Column<string>(name: "Doctor_DetailDr_id", type: "nvarchar(450)", nullable: true),
                    Patientid = table.Column<int>(name: "Patient_id", type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin_Pgs", x => x.AdminId);
                    table.ForeignKey(
                        name: "FK_Admin_Pgs_Doctor_Details_Doctor_DetailDr_id",
                        column: x => x.DoctorDetailDrid,
                        principalTable: "Doctor_Details",
                        principalColumn: "Dr_id");
                    table.ForeignKey(
                        name: "FK_Admin_Pgs_Patients_Patient_id",
                        column: x => x.Patientid,
                        principalTable: "Patients",
                        principalColumn: "Patient_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admin_Pgs_Doctor_DetailDr_id",
                table: "Admin_Pgs",
                column: "Doctor_DetailDr_id");

            migrationBuilder.CreateIndex(
                name: "IX_Admin_Pgs_Patient_id",
                table: "Admin_Pgs",
                column: "Patient_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin_Pgs");

            migrationBuilder.DropTable(
                name: "Doctor_Details");

            migrationBuilder.DropTable(
                name: "Patients");
        }
    }
}
