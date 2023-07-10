using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GlobalAI.HostConsole.Migrations
{
    /// <inheritdoc />
    public partial class createTableUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "USER",
                columns: table => new
                {
                    USER_ID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    USERNAME = table.Column<string>(type: "VARCHAR2(100)", maxLength: 100, nullable: false),
                    DISPLAY_NAME = table.Column<string>(type: "VARCHAR2(500)", maxLength: 500, nullable: false),
                    FIRST_NAME = table.Column<string>(type: "VARCHAR2(250)", maxLength: 250, nullable: false),
                    LAST_NAME = table.Column<string>(type: "VARCHAR2(250)", maxLength: 250, nullable: false),
                    PASSWORD = table.Column<string>(type: "VARCHAR2(500)", maxLength: 500, nullable: false),
                    STATUS = table.Column<string>(type: "CHAR(3)", maxLength: 3, nullable: false),
                    DELETED = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    EMAIL = table.Column<string>(type: "VARCHAR2(500)", maxLength: 500, nullable: false),
                    PHONE = table.Column<string>(type: "VARCHAR2(20)", maxLength: 20, nullable: false),
                    USER_TYPE = table.Column<string>(type: "VARCHAR2(20)", maxLength: 20, nullable: false),
                    LAST_LOGIN = table.Column<DateTime>(type: "DATE", nullable: true),
                    LAST_FAILED_LOGIN = table.Column<DateTime>(type: "DATE", nullable: true),
                    FAIL_ATTEMP = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: true),
                    IS_FIRST_TIME = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    IS_TEMP_PASSWORD = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    RESET_PASSWORD_TOKEN = table.Column<string>(type: "VARCHAR2(500)", maxLength: 500, nullable: false),
                    RESET_PASSWORD_TOKEN_EXP = table.Column<DateTime>(type: "DATE", nullable: true),
                    IS_VERIFIED_EMAIL = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    VERIFY_EMAIL_CODE = table.Column<string>(type: "VARCHAR2(100)", maxLength: 100, nullable: false),
                    CREATED_BY = table.Column<string>(type: "VARCHAR2(50)", maxLength: 50, nullable: false),
                    CREATED_DATE = table.Column<DateTime>(type: "DATE", nullable: true),
                    DELETED_BY = table.Column<string>(type: "VARCHAR2(50)", maxLength: 50, nullable: false),
                    DELETED_DATE = table.Column<DateTime>(type: "DATE", nullable: true),
                    MODIFIED_BY = table.Column<string>(type: "VARCHAR2(50)", maxLength: 50, nullable: false),
                    MODIFIED_DATE = table.Column<DateTime>(type: "DATE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER", x => x.USER_ID);
                },
                comment: "User");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "USER");
        }
    }
}
