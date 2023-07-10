using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GlobalAI.HostConsole.Migrations
{
    /// <inheritdoc />
    public partial class thembangentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DEMO_PRODUCT");

            migrationBuilder.AlterColumn<decimal>(
                name: "FAIL_ATTEMP",
                table: "USER",
                type: "DECIMAL(18, 2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "P_ChiTietDonHang",
                columns: table => new
                {
                    ID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    MA_DON_HANG = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    MA_SAN_PHAM = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    SO_LUONG = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    DELETED = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_P_ChiTietDonHang", x => x.ID);
                },
                comment: "bảng chi tiết đơn hàng");

            migrationBuilder.CreateTable(
                name: "P_DanhMuc",
                columns: table => new
                {
                    ID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    MA_DANH_MUC = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    TEN_DANH_MUC = table.Column<string>(type: "NVARCHAR2(400)", maxLength: 400, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_P_DanhMuc", x => x.ID);
                },
                comment: "Demo bảng danh mục sản phẩm");

            migrationBuilder.CreateTable(
                name: "P_DonHang",
                columns: table => new
                {
                    ID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    MA_DON_HANG = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    NGAY_HOAN_THANH = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    MA_G_STORE = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    MA_G_SALER = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    SO_TIEN = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: true),
                    HINH_THUC_THANH_TOAN = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    DELETED = table.Column<bool>(type: "NUMBER(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_P_DonHang", x => x.ID);
                },
                comment: "bảng đơn hàng");

            migrationBuilder.CreateTable(
                name: "P_SanPham",
                columns: table => new
                {
                    ID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    MA_SAN_PHAM = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    TEN_SAN_PHAM = table.Column<string>(type: "NVARCHAR2(400)", maxLength: 400, nullable: true),
                    MO_TA = table.Column<string>(type: "NVARCHAR2(1000)", maxLength: 1000, nullable: true),
                    GIA_BAN = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    GIA_CHIET_KHAU = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    MA_DANH_MUC = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    MA_G_STORE = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    NGAY_DANG_KI = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    NGAY_DUYET = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    DELETED = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    CREATED_BY = table.Column<string>(type: "VARCHAR2(50)", maxLength: 50, nullable: true),
                    CREATED_DATE = table.Column<DateTime>(type: "DATE", nullable: true),
                    DELETED_BY = table.Column<string>(type: "VARCHAR2(50)", maxLength: 50, nullable: true),
                    DELETED_DATE = table.Column<DateTime>(type: "DATE", nullable: true),
                    MODIFIED_BY = table.Column<string>(type: "VARCHAR2(50)", maxLength: 50, nullable: true),
                    MODIFIED_DATE = table.Column<DateTime>(type: "DATE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_P_SanPham", x => x.ID);
                },
                comment: "bảng sản phẩm");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "P_ChiTietDonHang");

            migrationBuilder.DropTable(
                name: "P_DanhMuc");

            migrationBuilder.DropTable(
                name: "P_DonHang");

            migrationBuilder.DropTable(
                name: "P_SanPham");

            migrationBuilder.AlterColumn<decimal>(
                name: "FAIL_ATTEMP",
                table: "USER",
                type: "DECIMAL(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "DEMO_PRODUCT",
                columns: table => new
                {
                    PRODUCT_RECORD_ID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    DESCRIPTION = table.Column<string>(type: "NVARCHAR2(1000)", maxLength: 1000, nullable: false),
                    MANUFACTURER = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: false),
                    PRICE = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    PRODUCT_ID = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    PRODUCT_NAME = table.Column<string>(type: "NVARCHAR2(400)", maxLength: 400, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DEMO_PRODUCT", x => x.PRODUCT_RECORD_ID);
                },
                comment: "Demo bảng sản phẩm");
        }
    }
}
