using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CreditManagementSystemHomework.Migrations
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Payment_PaymentId",
                table: "Payment");

            migrationBuilder.DropIndex(
                name: "IX_Payment_PaymentId",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "PaymentId",
                table: "Payment");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PaymentId",
                table: "Payment",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Payment_PaymentId",
                table: "Payment",
                column: "PaymentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_Payment_PaymentId",
                table: "Payment",
                column: "PaymentId",
                principalTable: "Payment",
                principalColumn: "Id");
        }
    }
}
