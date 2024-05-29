using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLTX.Migrations
{
    /// <inheritdoc />
    public partial class colume_fil : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "EMotorbikes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "EMotorbikes",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
