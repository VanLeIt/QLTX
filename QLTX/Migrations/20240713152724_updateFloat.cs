using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLTX.Migrations
{
    /// <inheritdoc />
    public partial class updateFloat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Total",
                table: "Rentals",
                type: "real",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<float>(
                name: "RetalTime",
                table: "Rentals",
                type: "real",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "Price",
                table: "Rentals",
                type: "real",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Total",
                table: "Rentals",
                type: "float",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<double>(
                name: "RetalTime",
                table: "Rentals",
                type: "float",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "Rentals",
                type: "float",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");
        }
    }
}
