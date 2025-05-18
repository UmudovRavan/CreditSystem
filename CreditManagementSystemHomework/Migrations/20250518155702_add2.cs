﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CreditManagementSystemHomework.Migrations
{
    /// <inheritdoc />
    public partial class add2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Model",
                table: "Products",
                newName: "BrandModel");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BrandModel",
                table: "Products",
                newName: "Model");
        }
    }
}
