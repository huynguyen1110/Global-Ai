using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GlobalAI.HostConsole.Migrations
{
    /// <inheritdoc />
    public partial class updatectdonhang : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DELETED",
                table: "P_ChiTietDonHang");

            migrationBuilder.DropColumn(
                name: "STATUS",
                table: "P_ChiTietDonHang");

            migrationBuilder.RenameColumn(
                name: "MA_SAN_PHAM",
                table: "P_ChiTietDonHang",
                newName: "ID_SAN_PHAM");

            migrationBuilder.RenameColumn(
                name: "MA_DON_HANG",
                table: "P_ChiTietDonHang",
                newName: "ID_DON_HANG");

            migrationBuilder.AlterColumn<decimal>(
                name: "FAIL_ATTEMP",
                table: "USER",
                type: "DECIMAL(18, 2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "GIA_TIEN",
                table: "P_TraGia",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "GIA_CHIET_KHAU",
                table: "P_SanPham",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "GIA_BAN",
                table: "P_SanPham",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "SO_TIEN",
                table: "P_DonHang",
                type: "DECIMAL(18, 2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CREATED_BY",
                table: "P_ChiTietDonHang",
                type: "VARCHAR2(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CREATED_DATE",
                table: "P_ChiTietDonHang",
                type: "DATE",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DELETED_BY",
                table: "P_ChiTietDonHang",
                type: "VARCHAR2(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DELETED_DATE",
                table: "P_ChiTietDonHang",
                type: "DATE",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CREATED_BY",
                table: "P_ChiTietDonHang");

            migrationBuilder.DropColumn(
                name: "CREATED_DATE",
                table: "P_ChiTietDonHang");

            migrationBuilder.DropColumn(
                name: "DELETED_BY",
                table: "P_ChiTietDonHang");

            migrationBuilder.DropColumn(
                name: "DELETED_DATE",
                table: "P_ChiTietDonHang");

            migrationBuilder.RenameColumn(
                name: "ID_SAN_PHAM",
                table: "P_ChiTietDonHang",
                newName: "MA_SAN_PHAM");

            migrationBuilder.RenameColumn(
                name: "ID_DON_HANG",
                table: "P_ChiTietDonHang",
                newName: "MA_DON_HANG");

            migrationBuilder.AlterColumn<decimal>(
                name: "FAIL_ATTEMP",
                table: "USER",
                type: "DECIMAL(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "GIA_TIEN",
                table: "P_TraGia",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "GIA_CHIET_KHAU",
                table: "P_SanPham",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "GIA_BAN",
                table: "P_SanPham",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "SO_TIEN",
                table: "P_DonHang",
                type: "DECIMAL(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "DELETED",
                table: "P_ChiTietDonHang",
                type: "NUMBER(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "STATUS",
                table: "P_ChiTietDonHang",
                type: "NUMBER(1)",
                nullable: false,
                defaultValue: false);
        }
    }
}
