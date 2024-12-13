using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hairdresser.Migrations
{
    public partial class deneme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_Customers_CustomerId",
                table: "Appointment");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_Employees_EmployeeId",
                table: "Appointment");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_Service_ServiceId",
                table: "Appointment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Service",
                table: "Service");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Appointment",
                table: "Appointment");

            migrationBuilder.RenameTable(
                name: "Service",
                newName: "Services");

            migrationBuilder.RenameTable(
                name: "Appointment",
                newName: "Appointments");

            migrationBuilder.RenameIndex(
                name: "IX_Appointment_ServiceId",
                table: "Appointments",
                newName: "IX_Appointments_ServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_Appointment_EmployeeId",
                table: "Appointments",
                newName: "IX_Appointments_EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_Appointment_CustomerId",
                table: "Appointments",
                newName: "IX_Appointments_CustomerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Services",
                table: "Services",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Appointments",
                table: "Appointments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Customers_CustomerId",
                table: "Appointments",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Employees_EmployeeId",
                table: "Appointments",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Services_ServiceId",
                table: "Appointments",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Customers_CustomerId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Employees_EmployeeId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Services_ServiceId",
                table: "Appointments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Services",
                table: "Services");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Appointments",
                table: "Appointments");

            migrationBuilder.RenameTable(
                name: "Services",
                newName: "Service");

            migrationBuilder.RenameTable(
                name: "Appointments",
                newName: "Appointment");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_ServiceId",
                table: "Appointment",
                newName: "IX_Appointment_ServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_EmployeeId",
                table: "Appointment",
                newName: "IX_Appointment_EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_CustomerId",
                table: "Appointment",
                newName: "IX_Appointment_CustomerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Service",
                table: "Service",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Appointment",
                table: "Appointment",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_Customers_CustomerId",
                table: "Appointment",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_Employees_EmployeeId",
                table: "Appointment",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_Service_ServiceId",
                table: "Appointment",
                column: "ServiceId",
                principalTable: "Service",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
