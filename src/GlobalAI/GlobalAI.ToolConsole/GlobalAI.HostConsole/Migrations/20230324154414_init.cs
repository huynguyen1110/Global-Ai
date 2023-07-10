using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GlobalAI.HostConsole.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DEMO_PRODUCT",
                columns: table => new
                {
                    PRODUCT_RECORD_ID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    PRODUCT_ID = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    PRODUCT_NAME = table.Column<string>(type: "NVARCHAR2(400)", maxLength: 400, nullable: false),
                    MANUFACTURER = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: false),
                    DESCRIPTION = table.Column<string>(type: "NVARCHAR2(1000)", maxLength: 1000, nullable: false),
                    PRICE = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DEMO_PRODUCT", x => x.PRODUCT_RECORD_ID);
                },
                comment: "Demo bảng sản phẩm");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DEMO_PRODUCT");
        }
    }
}
