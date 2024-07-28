using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLTX.Migrations
{
    /// <inheritdoc />
    public partial class broken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateExpired",
                table: "Rentals",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DetailBroken",
                table: "Rentals",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "SumTotal",
                table: "Rentals",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "TotalBroken",
                table: "Rentals",
                type: "real",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateExpired",
                table: "Rentals");

            migrationBuilder.DropColumn(
                name: "DetailBroken",
                table: "Rentals");

            migrationBuilder.DropColumn(
                name: "SumTotal",
                table: "Rentals");

            migrationBuilder.DropColumn(
                name: "TotalBroken",
                table: "Rentals");
        }
    }
}
