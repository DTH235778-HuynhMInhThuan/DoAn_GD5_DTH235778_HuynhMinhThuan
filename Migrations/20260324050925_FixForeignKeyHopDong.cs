using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyNhaTro.Migrations
{
    /// <inheritdoc />
    public partial class FixForeignKeyHopDong : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HopDongs_Phongs_PhongMaPhong",
                table: "HopDongs");

            migrationBuilder.DropForeignKey(
                name: "FK_HopDongs_SinhViens_SinhVienMaSV",
                table: "HopDongs");

            migrationBuilder.DropIndex(
                name: "IX_HopDongs_PhongMaPhong",
                table: "HopDongs");

            migrationBuilder.DropIndex(
                name: "IX_HopDongs_SinhVienMaSV",
                table: "HopDongs");

            migrationBuilder.DropColumn(
                name: "PhongMaPhong",
                table: "HopDongs");

            migrationBuilder.DropColumn(
                name: "SinhVienMaSV",
                table: "HopDongs");

            migrationBuilder.CreateIndex(
                name: "IX_HopDongs_MaPhong",
                table: "HopDongs",
                column: "MaPhong");

            migrationBuilder.CreateIndex(
                name: "IX_HopDongs_MaSV",
                table: "HopDongs",
                column: "MaSV");

            migrationBuilder.AddForeignKey(
                name: "FK_HopDongs_Phongs_MaPhong",
                table: "HopDongs",
                column: "MaPhong",
                principalTable: "Phongs",
                principalColumn: "MaPhong",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HopDongs_SinhViens_MaSV",
                table: "HopDongs",
                column: "MaSV",
                principalTable: "SinhViens",
                principalColumn: "MaSV",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HopDongs_Phongs_MaPhong",
                table: "HopDongs");

            migrationBuilder.DropForeignKey(
                name: "FK_HopDongs_SinhViens_MaSV",
                table: "HopDongs");

            migrationBuilder.DropIndex(
                name: "IX_HopDongs_MaPhong",
                table: "HopDongs");

            migrationBuilder.DropIndex(
                name: "IX_HopDongs_MaSV",
                table: "HopDongs");

            migrationBuilder.AddColumn<int>(
                name: "PhongMaPhong",
                table: "HopDongs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SinhVienMaSV",
                table: "HopDongs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_HopDongs_PhongMaPhong",
                table: "HopDongs",
                column: "PhongMaPhong");

            migrationBuilder.CreateIndex(
                name: "IX_HopDongs_SinhVienMaSV",
                table: "HopDongs",
                column: "SinhVienMaSV");

            migrationBuilder.AddForeignKey(
                name: "FK_HopDongs_Phongs_PhongMaPhong",
                table: "HopDongs",
                column: "PhongMaPhong",
                principalTable: "Phongs",
                principalColumn: "MaPhong",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HopDongs_SinhViens_SinhVienMaSV",
                table: "HopDongs",
                column: "SinhVienMaSV",
                principalTable: "SinhViens",
                principalColumn: "MaSV",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
