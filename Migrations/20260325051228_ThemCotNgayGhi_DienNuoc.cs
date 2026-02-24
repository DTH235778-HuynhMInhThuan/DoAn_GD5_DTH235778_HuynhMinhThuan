using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyNhaTro.Migrations
{
    /// <inheritdoc />
    public partial class ThemCotNgayGhi_DienNuoc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DienNuocs_Phongs_PhongMaPhong",
                table: "DienNuocs");

            migrationBuilder.DropIndex(
                name: "IX_DienNuocs_PhongMaPhong",
                table: "DienNuocs");

            migrationBuilder.DropColumn(
                name: "PhongMaPhong",
                table: "DienNuocs");

            migrationBuilder.AddColumn<DateTime>(
                name: "NgayGhi",
                table: "DienNuocs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_DienNuocs_MaPhong",
                table: "DienNuocs",
                column: "MaPhong");

            migrationBuilder.AddForeignKey(
                name: "FK_DienNuocs_Phongs_MaPhong",
                table: "DienNuocs",
                column: "MaPhong",
                principalTable: "Phongs",
                principalColumn: "MaPhong",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DienNuocs_Phongs_MaPhong",
                table: "DienNuocs");

            migrationBuilder.DropIndex(
                name: "IX_DienNuocs_MaPhong",
                table: "DienNuocs");

            migrationBuilder.DropColumn(
                name: "NgayGhi",
                table: "DienNuocs");

            migrationBuilder.AddColumn<int>(
                name: "PhongMaPhong",
                table: "DienNuocs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DienNuocs_PhongMaPhong",
                table: "DienNuocs",
                column: "PhongMaPhong");

            migrationBuilder.AddForeignKey(
                name: "FK_DienNuocs_Phongs_PhongMaPhong",
                table: "DienNuocs",
                column: "PhongMaPhong",
                principalTable: "Phongs",
                principalColumn: "MaPhong",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
