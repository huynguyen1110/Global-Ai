using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GlobalAI.HostConsole.Migrations
{
    /// <inheritdoc />
    public partial class addtblspthuoctinh : Migration
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
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

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
                name: "P_SanPhamChiTiet",
                columns: table => new
                {
                    ID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    MA_SAN_PHAM_CHI_TIET = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    MO_TA = table.Column<string>(type: "NVARCHAR2(1000)", maxLength: 1000, nullable: true),
                    GIA_BAN = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: true),
                    GIA_CHIET_KHAU = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: true),
                    NGAY_DANG_KI = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    NGAY_DUYET = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    STATUS = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    GIA_TOI_THIEU = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: true),
                    THUMBNAIL = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    LUOT_XEM = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    LUOT_BAN = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    SO_LUONG = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    CREATED_BY = table.Column<string>(type: "VARCHAR2(50)", maxLength: 50, nullable: true),
                    CREATED_DATE = table.Column<DateTime>(type: "DATE", nullable: true),
                    DELETED = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DELETED_BY = table.Column<string>(type: "VARCHAR2(50)", maxLength: 50, nullable: true),
                    DELETED_DATE = table.Column<DateTime>(type: "DATE", nullable: true),
                    MODIFIED_BY = table.Column<string>(type: "VARCHAR2(50)", maxLength: 50, nullable: true),
                    MODIFIED_DATE = table.Column<DateTime>(type: "DATE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_P_SanPhamChiTiet", x => x.ID);
                },
                comment: "bảng sản phẩm chi tiết");

            migrationBuilder.CreateTable(
                name: "P_SanPhamChiTietThuocTinh",
                columns: table => new
                {
                    ID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    ID_THUOC_TINH_GIA_TRI = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ID_SAN_PHAM_CHI_TIET = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    CREATED_BY = table.Column<string>(type: "VARCHAR2(50)", maxLength: 50, nullable: true),
                    CREATED_DATE = table.Column<DateTime>(type: "DATE", nullable: true),
                    DELETED = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DELETED_BY = table.Column<string>(type: "VARCHAR2(50)", maxLength: 50, nullable: true),
                    DELETED_DATE = table.Column<DateTime>(type: "DATE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_P_SanPhamChiTietThuocTinh", x => x.ID);
                },
                comment: "bảng nối giữa Sản phẩm chi tiết & Thuộc tính giá trị");

            migrationBuilder.CreateTable(
                name: "P_ThuocTinh",
                columns: table => new
                {
                    ID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    ID_DANH_MUC = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    TEN_THUOC_TINH = table.Column<string>(type: "VARCHAR2(150)", maxLength: 150, nullable: true),
                    CREATED_BY = table.Column<string>(type: "VARCHAR2(50)", maxLength: 50, nullable: true),
                    CREATED_DATE = table.Column<DateTime>(type: "DATE", nullable: true),
                    DELETED = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DELETED_BY = table.Column<string>(type: "VARCHAR2(50)", maxLength: 50, nullable: true),
                    DELETED_DATE = table.Column<DateTime>(type: "DATE", nullable: true),
                    MODIFIED_BY = table.Column<string>(type: "VARCHAR2(50)", maxLength: 50, nullable: true),
                    MODIFIED_DATE = table.Column<DateTime>(type: "DATE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_P_ThuocTinh", x => x.ID);
                },
                comment: "bảng thuộc tính theo danh mục");

            migrationBuilder.CreateTable(
                name: "P_ThuocTinhGiaTri",
                columns: table => new
                {
                    ID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    ID_THUOC_TINH = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    TEN_THUOC_TINH = table.Column<string>(type: "VARCHAR2(150)", maxLength: 150, nullable: true),
                    GIA_TRI = table.Column<string>(type: "VARCHAR2(500)", maxLength: 500, nullable: true),
                    CREATED_BY = table.Column<string>(type: "VARCHAR2(50)", maxLength: 50, nullable: true),
                    CREATED_DATE = table.Column<DateTime>(type: "DATE", nullable: true),
                    DELETED = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DELETED_BY = table.Column<string>(type: "VARCHAR2(50)", maxLength: 50, nullable: true),
                    DELETED_DATE = table.Column<DateTime>(type: "DATE", nullable: true),
                    MODIFIED_BY = table.Column<string>(type: "VARCHAR2(50)", maxLength: 50, nullable: true),
                    MODIFIED_DATE = table.Column<DateTime>(type: "DATE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_P_ThuocTinhGiaTri", x => x.ID);
                },
                comment: "bảng giá trị thuộc tính");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "P_SanPhamChiTiet");

            migrationBuilder.DropTable(
                name: "P_SanPhamChiTietThuocTinh");

            migrationBuilder.DropTable(
                name: "P_ThuocTinh");

            migrationBuilder.DropTable(
                name: "P_ThuocTinhGiaTri");

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
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

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
