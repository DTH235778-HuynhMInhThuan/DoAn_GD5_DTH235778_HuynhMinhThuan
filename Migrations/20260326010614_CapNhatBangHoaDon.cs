using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyNhaTro.Migrations
{
    /// <inheritdoc />
    public partial class CapNhatBangHoaDon : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HoaDons_Phongs_PhongMaPhong",
                table: "HoaDons");

            migrationBuilder.DropIndex(
                name: "IX_HoaDons_PhongMaPhong",
                table: "HoaDons");

            migrationBuilder.DropColumn(
                name: "PhongMaPhong",
                table: "HoaDons");

            migrationBuilder.AddColumn<string>(
                name: "TrangThai",
                table: "HoaDons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDons_MaPhong",
                table: "HoaDons",
                column: "MaPhong");

            migrationBuilder.AddForeignKey(
                name: "FK_HoaDons_Phongs_MaPhong",
                table: "HoaDons",
                column: "MaPhong",
                principalTable: "Phongs",
                principalColumn: "MaPhong",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HoaDons_Phongs_MaPhong",
                table: "HoaDons");

            migrationBuilder.DropIndex(
                name: "IX_HoaDons_MaPhong",
                table: "HoaDons");

            migrationBuilder.DropColumn(
                name: "TrangThai",
                table: "HoaDons");

            migrationBuilder.AddColumn<int>(
                name: "PhongMaPhong",
                table: "HoaDons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_HoaDons_PhongMaPhong",
                table: "HoaDons",
                column: "PhongMaPhong");

            migrationBuilder.AddForeignKey(
                name: "FK_HoaDons_Phongs_PhongMaPhong",
                table: "HoaDons",
                column: "PhongMaPhong",
                principalTable: "Phongs",
                principalColumn: "MaPhong",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
