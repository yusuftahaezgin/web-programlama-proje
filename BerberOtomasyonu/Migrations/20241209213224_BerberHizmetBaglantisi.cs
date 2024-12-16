using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BerberOtomasyonu.Migrations
{
    /// <inheritdoc />
    public partial class BerberHizmetBaglantisi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HizmetID",
                table: "Berberler",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Berberler_HizmetID",
                table: "Berberler",
                column: "HizmetID");

            migrationBuilder.AddForeignKey(
                name: "FK_Berberler_Hizmetler_HizmetID",
                table: "Berberler",
                column: "HizmetID",
                principalTable: "Hizmetler",
                principalColumn: "HizmetID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Berberler_Hizmetler_HizmetID",
                table: "Berberler");

            migrationBuilder.DropIndex(
                name: "IX_Berberler_HizmetID",
                table: "Berberler");

            migrationBuilder.DropColumn(
                name: "HizmetID",
                table: "Berberler");
        }
    }
}
