﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BerberOtomasyonu.Migrations
{
    /// <inheritdoc />
    public partial class duzenlemee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Randevular_Hizmetler_HizmetID",
                table: "Randevular");

            migrationBuilder.DropIndex(
                name: "IX_Randevular_HizmetID",
                table: "Randevular");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}