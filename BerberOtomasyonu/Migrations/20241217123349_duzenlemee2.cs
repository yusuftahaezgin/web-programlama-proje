using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BerberOtomasyonu.Migrations
{
    /// <inheritdoc />
    public partial class duzenlemee2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hizmetler_Randevular_RandevuID",
                table: "Hizmetler");

            migrationBuilder.DropIndex(
                name: "IX_Hizmetler_RandevuID",
                table: "Hizmetler");

            migrationBuilder.DropColumn(
                name: "RandevuID",
                table: "Hizmetler");

            migrationBuilder.CreateIndex(
                name: "IX_Randevular_HizmetID",
                table: "Randevular",
                column: "HizmetID");

            migrationBuilder.AddForeignKey(
                name: "FK_Randevular_Hizmetler_HizmetID",
                table: "Randevular",
                column: "HizmetID",
                principalTable: "Hizmetler",
                principalColumn: "HizmetID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Randevular_Hizmetler_HizmetID",
                table: "Randevular");

            migrationBuilder.DropIndex(
                name: "IX_Randevular_HizmetID",
                table: "Randevular");

            migrationBuilder.AddColumn<int>(
                name: "RandevuID",
                table: "Hizmetler",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Hizmetler_RandevuID",
                table: "Hizmetler",
                column: "RandevuID");

            migrationBuilder.AddForeignKey(
                name: "FK_Hizmetler_Randevular_RandevuID",
                table: "Hizmetler",
                column: "RandevuID",
                principalTable: "Randevular",
                principalColumn: "RandevuID");
        }
    }
}
