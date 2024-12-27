using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BerberOtomasyonu.Migrations
{
    /// <inheritdoc />
    public partial class Guncelleme12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Randevular_MusteriID",
                table: "Randevular",
                column: "MusteriID");

            migrationBuilder.AddForeignKey(
                name: "FK_Randevular_Musteriler_MusteriID",
                table: "Randevular",
                column: "MusteriID",
                principalTable: "Musteriler",
                principalColumn: "MusteriID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Randevular_Musteriler_MusteriID",
                table: "Randevular");

            migrationBuilder.DropIndex(
                name: "IX_Randevular_MusteriID",
                table: "Randevular");
        }
    }
}
