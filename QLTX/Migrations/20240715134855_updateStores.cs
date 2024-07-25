using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLTX.Migrations
{
    /// <inheritdoc />
    public partial class updateStores : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Configs",
                table: "Configs");

            migrationBuilder.RenameTable(
                name: "Configs",
                newName: "Stores");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Stores",
                table: "Stores",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Stores",
                table: "Stores");

            migrationBuilder.RenameTable(
                name: "Stores",
                newName: "Configs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Configs",
                table: "Configs",
                column: "Id");
        }
    }
}
