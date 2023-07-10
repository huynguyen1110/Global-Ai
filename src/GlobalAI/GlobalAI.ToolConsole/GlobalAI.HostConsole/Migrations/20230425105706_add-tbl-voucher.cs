using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GlobalAI.HostConsole.Migrations
{
    /// <inheritdoc />
    public partial class addtblvoucher : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "FAIL_ATTEMP",
                table: "USER",
                type: "DECIMAL(18, 2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "GIA_CUOI",
                table: "P_TraGia",
                type: "DECIMAL(18, 2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "GIA_TOI_THIEU",
                table: "P_SanPham",
                type: "DECIMAL(18, 2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "GIA_CHIET_KHAU",
                table: "P_SanPham",
                type: "DECIMAL(18, 2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "GIA_BAN",
                table: "P_SanPham",
                type: "DECIMAL(18, 2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "SO_TIEN",
                table: "P_DonHang",
                type: "DECIMAL(18, 2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "GIA_TIEN",
                table: "P_ChiTietTraGia",
                type: "DECIMAL(18, 2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "P_Voucher",
                columns: table => new
                {
                    ID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NAME = table.Column<string>(type: "VARCHAR2(250)", maxLength: 250, nullable: true),
                    AVATAR = table.Column<string>(type: "VARCHAR2(500)", maxLength: 500, nullable: true),
                    MO_TA = table.Column<string>(type: "VARCHAR2(500)", maxLength: 500, nullable: true),
                    GIA_TRI = table.Column<double>(type: "BINARY_DOUBLE", nullable: true),
                    SO_LUONG = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    NGAY_HET_HAN = table.Column<DateTime>(type: "DATE", nullable: true),
                    STATUS = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    CREATED_BY = table.Column<string>(type: "VARCHAR2(50)", maxLength: 50, nullable: true),
                    CREATED_DATE = table.Column<DateTime>(type: "DATE", nullable: true),
                    DELETED = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DELETED_BY = table.Column<string>(type: "VARCHAR2(50)", maxLength: 50, nullable: true),
                    DELETED_DATE = table.Column<DateTime>(type: "DATE", nullable: true),
                    MODIFIED_BY = table.Column<string>(type: "VARCHAR2(50)", maxLength: 50, nullable: true),
                    MODIFIED_DATE = table.Column<DateTime>(type: "DATE", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_P_Voucher", x => x.ID);
                },
                comment: "Voucher");

            migrationBuilder.CreateTable(
                name: "P_Voucher_ChiTiet",
                columns: table => new
                {
                    ID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    VOUCHER_ID = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    MA_VOUCHER = table.Column<string>(type: "VARCHAR2(150)", maxLength: 150, nullable: true),
                    NGAY_GIAO = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    NGAY_SU_DUNG = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    NGUOI_SU_DUNG = table.Column<string>(type: "VARCHAR2(150)", maxLength: 150, nullable: true),
                    LICH_SU_TEN_VOUCHER = table.Column<string>(type: "VARCHAR2(250)", maxLength: 250, nullable: true),
                    LICH_SU_MO_TA = table.Column<string>(type: "VARCHAR2(500)", maxLength: 500, nullable: true),
                    LICH_SU_GIA_TRI = table.Column<double>(type: "BINARY_DOUBLE", nullable: true),
                    STATUS = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    CREATED_BY = table.Column<string>(type: "VARCHAR2(50)", maxLength: 50, nullable: true),
                    CREATED_DATE = table.Column<DateTime>(type: "DATE", nullable: true),
                    DELETED = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DELETED_BY = table.Column<string>(type: "VARCHAR2(50)", maxLength: 50, nullable: true),
                    DELETED_DATE = table.Column<DateTime>(type: "DATE", nullable: true),
                    MODIFIED_BY = table.Column<string>(type: "VARCHAR2(50)", maxLength: 50, nullable: true),
                    MODIFIED_DATE = table.Column<DateTime>(type: "DATE", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_P_Voucher_ChiTiet", x => x.ID);
                },
                comment: "Voucher chi tiết");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "P_Voucher");

            migrationBuilder.DropTable(
                name: "P_Voucher_ChiTiet");

            migrationBuilder.AlterColumn<decimal>(
                name: "FAIL_ATTEMP",
                table: "USER",
                type: "DECIMAL(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "GIA_CUOI",
                table: "P_TraGia",
                type: "DECIMAL(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "GIA_TOI_THIEU",
                table: "P_SanPham",
                type: "DECIMAL(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "GIA_CHIET_KHAU",
                table: "P_SanPham",
                type: "DECIMAL(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "GIA_BAN",
                table: "P_SanPham",
                type: "DECIMAL(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "SO_TIEN",
                table: "P_DonHang",
                type: "DECIMAL(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "GIA_TIEN",
                table: "P_ChiTietTraGia",
                type: "DECIMAL(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)",
                oldNullable: true);
        }
    }
}
