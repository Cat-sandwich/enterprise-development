using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnterpriseStatistics.Domain.Migrations
{
    /// <inheritdoc />
    public partial class migration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Quanity",
                table: "Supplies",
                newName: "quanity");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Supplies",
                newName: "date");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Supplies",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Suppliers",
                newName: "phone");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Suppliers",
                newName: "address");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Suppliers",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "Suppliers",
                newName: "full_name");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Enterprises",
                newName: "phone");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Enterprises",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Enterprises",
                newName: "address");

            migrationBuilder.RenameColumn(
                name: "TotalArea",
                table: "Enterprises",
                newName: "total_area");

            migrationBuilder.RenameColumn(
                name: "OwnershipForm",
                table: "Enterprises",
                newName: "ownership_form");

            migrationBuilder.RenameColumn(
                name: "IndustryType",
                table: "Enterprises",
                newName: "industry_type");

            migrationBuilder.RenameColumn(
                name: "EmployeeCount",
                table: "Enterprises",
                newName: "employee_count");

            migrationBuilder.RenameColumn(
                name: "MainStateRegistrationNumber",
                table: "Enterprises",
                newName: "main_state_registration_number");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "quanity",
                table: "Supplies",
                newName: "Quanity");

            migrationBuilder.RenameColumn(
                name: "date",
                table: "Supplies",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Supplies",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "phone",
                table: "Suppliers",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "address",
                table: "Suppliers",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Suppliers",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "full_name",
                table: "Suppliers",
                newName: "FullName");

            migrationBuilder.RenameColumn(
                name: "phone",
                table: "Enterprises",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Enterprises",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "address",
                table: "Enterprises",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "total_area",
                table: "Enterprises",
                newName: "TotalArea");

            migrationBuilder.RenameColumn(
                name: "ownership_form",
                table: "Enterprises",
                newName: "OwnershipForm");

            migrationBuilder.RenameColumn(
                name: "industry_type",
                table: "Enterprises",
                newName: "IndustryType");

            migrationBuilder.RenameColumn(
                name: "employee_count",
                table: "Enterprises",
                newName: "EmployeeCount");

            migrationBuilder.RenameColumn(
                name: "main_state_registration_number",
                table: "Enterprises",
                newName: "MainStateRegistrationNumber");
        }
    }
}
