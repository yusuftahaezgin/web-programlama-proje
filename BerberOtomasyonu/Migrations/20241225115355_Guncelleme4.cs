using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BerberOtomasyonu.Migrations
{
    /// <inheritdoc />
    public partial class Guncelleme4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BerberHizmet_Berberler_BerberID",
                table: "BerberHizmet");

            migrationBuilder.DropForeignKey(
                name: "FK_BerberHizmet_Hizmetler_HizmetID",
                table: "BerberHizmet");

            migrationBuilder.RenameColumn(
                name: "HizmetID",
                table: "BerberHizmet",
                newName: "HizmetlerHizmetID");

            migrationBuilder.RenameColumn(
                name: "BerberID",
                table: "BerberHizmet",
                newName: "BerberlerBerberID");

            migrationBuilder.RenameIndex(
                name: "IX_BerberHizmet_HizmetID",
                table: "BerberHizmet",
                newName: "IX_BerberHizmet_HizmetlerHizmetID");

            migrationBuilder.AddForeignKey(
                name: "FK_BerberHizmet_Berberler_BerberlerBerberID",
                table: "BerberHizmet",
                column: "BerberlerBerberID",
                principalTable: "Berberler",
                principalColumn: "BerberID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BerberHizmet_Hizmetler_HizmetlerHizmetID",
                table: "BerberHizmet",
                column: "HizmetlerHizmetID",
                principalTable: "Hizmetler",
                principalColumn: "HizmetID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BerberHizmet_Berberler_BerberlerBerberID",
                table: "BerberHizmet");

            migrationBuilder.DropForeignKey(
                name: "FK_BerberHizmet_Hizmetler_HizmetlerHizmetID",
                table: "BerberHizmet");

            migrationBuilder.RenameColumn(
                name: "HizmetlerHizmetID",
                table: "BerberHizmet",
                newName: "HizmetID");

            migrationBuilder.RenameColumn(
                name: "BerberlerBerberID",
                table: "BerberHizmet",
                newName: "BerberID");

            migrationBuilder.RenameIndex(
                name: "IX_BerberHizmet_HizmetlerHizmetID",
                table: "BerberHizmet",
                newName: "IX_BerberHizmet_HizmetID");

            migrationBuilder.AddForeignKey(
                name: "FK_BerberHizmet_Berberler_BerberID",
                table: "BerberHizmet",
                column: "BerberID",
                principalTable: "Berberler",
                principalColumn: "BerberID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BerberHizmet_Hizmetler_HizmetID",
                table: "BerberHizmet",
                column: "HizmetID",
                principalTable: "Hizmetler",
                principalColumn: "HizmetID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
