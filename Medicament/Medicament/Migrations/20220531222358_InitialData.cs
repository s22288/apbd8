using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Medicament.Migrations
{
    public partial class InitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "idDoctor", "Email", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "niewiem@gmail.com", "Janek", "Lekarz" },
                    { 2, "takiEmail@gmail.com", "Michał", "Nowak" }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "idPatient", "Birhtdate", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jan", "Kowalski" },
                    { 2, new DateTime(2001, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Michał", "Nowak" }
                });

            migrationBuilder.InsertData(
                table: "Prescriptions",
                columns: new[] { "IdDoctor", "Date", "DueDate", "IdPatient", "IdPrescription" },
                values: new object[] { 2, new DateTime(2021, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 });

            migrationBuilder.InsertData(
                table: "Prescriptions",
                columns: new[] { "IdDoctor", "Date", "DueDate", "IdPatient", "IdPrescription" },
                values: new object[] { 1, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 2, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Prescriptions",
                keyColumn: "IdDoctor",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Prescriptions",
                keyColumn: "IdDoctor",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "idDoctor",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "idDoctor",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "idPatient",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "idPatient",
                keyValue: 2);
        }
    }
}
