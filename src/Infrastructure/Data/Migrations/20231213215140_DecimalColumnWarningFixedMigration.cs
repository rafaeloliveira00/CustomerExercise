using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Connectlime.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DecimalColumnWarningFixedMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "UnitPrice",
                table: "Transactions",
                type: "decimal(9,4)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "PersonTax",
                table: "Transactions",
                type: "decimal(9,4)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "CompanyTax",
                table: "Transactions",
                type: "decimal(9,4)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "UnitPrice",
                table: "Transactions",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(9,4)");

            migrationBuilder.AlterColumn<decimal>(
                name: "PersonTax",
                table: "Transactions",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(9,4)");

            migrationBuilder.AlterColumn<decimal>(
                name: "CompanyTax",
                table: "Transactions",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(9,4)");
        }
    }
}
