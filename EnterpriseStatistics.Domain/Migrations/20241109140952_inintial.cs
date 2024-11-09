using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnterpriseStatistics.Domain.Migrations
{
    /// <inheritdoc />
    public partial class inintial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Supplies_Enterprises_EnterpriseMainStateRegistrationNumber",
                table: "Supplies");

            migrationBuilder.DropForeignKey(
                name: "FK_Supplies_Suppliers_SupplierId",
                table: "Supplies");

            migrationBuilder.RenameColumn(
                name: "SupplierId",
                table: "Supplies",
                newName: "supplier_id");

            migrationBuilder.RenameColumn(
                name: "EnterpriseMainStateRegistrationNumber",
                table: "Supplies",
                newName: "enterprise_id");

            migrationBuilder.RenameIndex(
                name: "IX_Supplies_SupplierId",
                table: "Supplies",
                newName: "IX_Supplies_supplier_id");

            migrationBuilder.RenameIndex(
                name: "IX_Supplies_EnterpriseMainStateRegistrationNumber",
                table: "Supplies",
                newName: "IX_Supplies_enterprise_id");

            migrationBuilder.AlterColumn<string>(
                name: "OwnershipForm",
                table: "Enterprises",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "IndustryType",
                table: "Enterprises",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<ulong>(
                name: "MainStateRegistrationNumber",
                table: "Enterprises",
                type: "bigint unsigned",
                nullable: false,
                oldClrType: typeof(ulong),
                oldType: "bigint unsigned")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddForeignKey(
                name: "FK_Supplies_Enterprises_enterprise_id",
                table: "Supplies",
                column: "enterprise_id",
                principalTable: "Enterprises",
                principalColumn: "MainStateRegistrationNumber",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Supplies_Suppliers_supplier_id",
                table: "Supplies",
                column: "supplier_id",
                principalTable: "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Supplies_Enterprises_enterprise_id",
                table: "Supplies");

            migrationBuilder.DropForeignKey(
                name: "FK_Supplies_Suppliers_supplier_id",
                table: "Supplies");

            migrationBuilder.RenameColumn(
                name: "supplier_id",
                table: "Supplies",
                newName: "SupplierId");

            migrationBuilder.RenameColumn(
                name: "enterprise_id",
                table: "Supplies",
                newName: "EnterpriseMainStateRegistrationNumber");

            migrationBuilder.RenameIndex(
                name: "IX_Supplies_supplier_id",
                table: "Supplies",
                newName: "IX_Supplies_SupplierId");

            migrationBuilder.RenameIndex(
                name: "IX_Supplies_enterprise_id",
                table: "Supplies",
                newName: "IX_Supplies_EnterpriseMainStateRegistrationNumber");

            migrationBuilder.AlterColumn<int>(
                name: "OwnershipForm",
                table: "Enterprises",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "IndustryType",
                table: "Enterprises",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<ulong>(
                name: "MainStateRegistrationNumber",
                table: "Enterprises",
                type: "bigint unsigned",
                nullable: false,
                oldClrType: typeof(ulong),
                oldType: "bigint unsigned")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddForeignKey(
                name: "FK_Supplies_Enterprises_EnterpriseMainStateRegistrationNumber",
                table: "Supplies",
                column: "EnterpriseMainStateRegistrationNumber",
                principalTable: "Enterprises",
                principalColumn: "MainStateRegistrationNumber",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Supplies_Suppliers_SupplierId",
                table: "Supplies",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
