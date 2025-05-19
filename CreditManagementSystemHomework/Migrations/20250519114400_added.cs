using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CreditManagementSystemHomework.Migrations
{
    /// <inheritdoc />
    public partial class added : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreditCreateTime",
                table: "Loans",
                newName: "StartDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Loans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Loans");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "Loans",
                newName: "CreditCreateTime");
        }
    }
}
