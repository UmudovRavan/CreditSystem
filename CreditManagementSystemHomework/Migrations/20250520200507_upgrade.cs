using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CreditManagementSystemHomework.Migrations
{
    /// <inheritdoc />
    public partial class upgrade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DueDate",
                table: "LoansDetail",
                newName: "StartDate");

            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "LoansDetail",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "LoansDetail",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "LoansDetail",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "LoansDetail");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "LoansDetail");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "LoansDetail");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "LoansDetail",
                newName: "DueDate");
        }
    }
}
