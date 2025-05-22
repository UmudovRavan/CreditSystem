using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CreditManagementSystemHomework.Migrations
{
    /// <inheritdoc />
    public partial class addedLoanItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UnitPrice",
                table: "LoansItem",
                newName: "TotalDecimal");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "LoansItem",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "LoansItem");

            migrationBuilder.RenameColumn(
                name: "TotalDecimal",
                table: "LoansItem",
                newName: "UnitPrice");
        }
    }
}
