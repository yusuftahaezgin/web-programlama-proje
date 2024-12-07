using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BerberOtomasyonu.Migrations
{
    /// <inheritdoc />
    public partial class VeriDoldurma : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "hizmetVeren",
                table: "Hizmetler");

            migrationBuilder.RenameColumn(
                name: "Eposta",
                table: "Musteriler",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "Eposta",
                table: "Berberler",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "Eposta",
                table: "Adminler",
                newName: "Email");

            migrationBuilder.AddColumn<string>(
                name: "KullaniciAdi",
                table: "Musteriler",
                type: "TEXT",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Sifre",
                table: "Musteriler",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KullaniciAdi",
                table: "Musteriler");

            migrationBuilder.DropColumn(
                name: "Sifre",
                table: "Musteriler");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Musteriler",
                newName: "Eposta");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Berberler",
                newName: "Eposta");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Adminler",
                newName: "Eposta");

            migrationBuilder.AddColumn<string>(
                name: "hizmetVeren",
                table: "Hizmetler",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
