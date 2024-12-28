using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BerberOtomasyonu.Migrations
{
    /// <inheritdoc />
    public partial class Guncelleme192 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BerberID",
                table: "Hizmetler");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BerberID",
                table: "Hizmetler",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
