﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BerberOtomasyonu.Migrations
{
    /// <inheritdoc />
    public partial class Guncelleme5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Randevular_Berberler_BerberID",
                table: "Randevular");

            migrationBuilder.DropForeignKey(
                name: "FK_Randevular_Hizmetler_HizmetID",
                table: "Randevular");

            migrationBuilder.DropForeignKey(
                name: "FK_Randevular_Musteriler_MusteriID",
                table: "Randevular");

            migrationBuilder.DropIndex(
                name: "IX_Randevular_BerberID",
                table: "Randevular");

            migrationBuilder.DropIndex(
                name: "IX_Randevular_HizmetID",
                table: "Randevular");

            migrationBuilder.DropIndex(
                name: "IX_Randevular_MusteriID",
                table: "Randevular");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Randevular_BerberID",
                table: "Randevular",
                column: "BerberID");

            migrationBuilder.CreateIndex(
                name: "IX_Randevular_HizmetID",
                table: "Randevular",
                column: "HizmetID");

            migrationBuilder.CreateIndex(
                name: "IX_Randevular_MusteriID",
                table: "Randevular",
                column: "MusteriID");

            migrationBuilder.AddForeignKey(
                name: "FK_Randevular_Berberler_BerberID",
                table: "Randevular",
                column: "BerberID",
                principalTable: "Berberler",
                principalColumn: "BerberID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Randevular_Hizmetler_HizmetID",
                table: "Randevular",
                column: "HizmetID",
                principalTable: "Hizmetler",
                principalColumn: "HizmetID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Randevular_Musteriler_MusteriID",
                table: "Randevular",
                column: "MusteriID",
                principalTable: "Musteriler",
                principalColumn: "MusteriID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
