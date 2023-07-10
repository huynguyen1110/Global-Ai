using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GlobalAI.HostConsole.Migrations
{
    /// <inheritdoc />
    public partial class updatetblsp : Migration
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
                name: "P_SanPham",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    MA_SAN_PHAM = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    TEN_SAN_PHAM = table.Column<string>(type: "NVARCHAR2(400)", maxLength: 400, nullable: true),
                    MO_TA = table.Column<string>(type: "NVARCHAR2(1000)", maxLength: 1000, nullable: true),
                    GIA_BAN = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    GIA_CHIET_KHAU = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    ID_DANH_MUC = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    ID_G_STORE = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    NGAY_DANG_KI = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    NGAY_DUYET = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    DELETED = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    STATUS = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    CREATED_BY = table.Column<string>(type: "VARCHAR2(50)", maxLength: 50, nullable: true),
                    CREATED_DATE = table.Column<DateTime>(type: "DATE", nullable: true),
                    DELETED_BY = table.Column<string>(type: "VARCHAR2(50)", maxLength: 50, nullable: true),
                    DELETED_DATE = table.Column<DateTime>(type: "DATE", nullable: true),
                    MODIFIED_BY = table.Column<string>(type: "VARCHAR2(50)", maxLength: 50, nullable: true),
                    MODIFIED_DATE = table.Column<DateTime>(type: "DATE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_P_SanPham", x => x.Id);
                },
                comment: "bảng sản phẩm");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AlterColumn<decimal>(
                name: "GIA_CUOI",
                table: "P_TraGia",
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
