using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLTX.Migrations
{
    /// <inheritdoc />
    public partial class updateTypeMotor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bills");

            migrationBuilder.DropColumn(
                name: "PriceDay",
                table: "Configs");

            migrationBuilder.DropColumn(
                name: "PriceHour",
                table: "Configs");

            migrationBuilder.DropColumn(
                name: "PriceWeek",
                table: "Configs");

            migrationBuilder.RenameColumn(
                name: "Battery",
                table: "TypeMotorbikes",
                newName: "Distance");

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "TypeMotorbikes",
                type: "float",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "TypeMotorbikes");

            migrationBuilder.RenameColumn(
                name: "Distance",
                table: "TypeMotorbikes",
                newName: "Battery");

            migrationBuilder.AddColumn<double>(
                name: "PriceDay",
                table: "Configs",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "PriceHour",
                table: "Configs",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "PriceWeek",
                table: "Configs",
                type: "float",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Bills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RentalId = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DatePay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    StoreName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SumAmount = table.Column<double>(type: "float", nullable: false),
                    SumEMotor = table.Column<int>(type: "int", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdationTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bills_Rentals_RentalId",
                        column: x => x.RentalId,
                        principalTable: "Rentals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bills_RentalId",
                table: "Bills",
                column: "RentalId");
        }
    }
}
