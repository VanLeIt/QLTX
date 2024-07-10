using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLTX.Migrations
{
    /// <inheritdoc />
    public partial class updateRental : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KmEnd",
                table: "Rentals");

            migrationBuilder.DropColumn(
                name: "KmStart",
                table: "Rentals");

            migrationBuilder.DropColumn(
                name: "Tolls",
                table: "Configs");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "KmEnd",
                table: "Rentals",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "KmStart",
                table: "Rentals",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<decimal>(
                name: "Tolls",
                table: "Configs",
                type: "decimal(18,2)",
                nullable: true);
        }
    }
}
