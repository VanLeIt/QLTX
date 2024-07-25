using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLTX.Migrations
{
    /// <inheritdoc />
    public partial class updateRenald : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
            name: "RentalDetails",
            columns: table => new
            {
                RentalId = table.Column<int>(nullable: false),
                EMotorbileId = table.Column<int>(nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_RentalDetails", x => new { x.RentalId, x.EMotorbileId });
                table.ForeignKey(
                    name: "FK_RentalDetails_Rentals_RentalId",
                    column: x => x.RentalId,
                    principalTable: "Rentals",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_RentalDetails_EMotorbikes_EMotorbileId",
                    column: x => x.EMotorbileId,
                    principalTable: "EMotorbikes",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

            migrationBuilder.CreateIndex(
                name: "IX_RentalDetails_EMotorbileId",
                table: "RentalDetails",
                column: "EMotorbileId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
            name: "RentalDetails");
        }
    }
}
