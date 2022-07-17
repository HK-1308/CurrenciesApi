using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CurrenciesTaskApi.Migrations
{
    public partial class TV_16072022 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Currencies_Ondates",
                columns: table => new
                {
                    GUID = table.Column<string>(type: "TEXT", nullable: false),
                    CODE = table.Column<string>(type: "TEXT", nullable: false),
                    CURVAL = table.Column<decimal>(type: "TEXT", nullable: false),
                    CURDATE = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies_Ondates", x => x.GUID);
                });

            migrationBuilder.CreateTable(
                name: "Currency",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Code = table.Column<string>(type: "TEXT", nullable: false),
                    Abbreviation = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    QuotName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currency", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Currencies_Ondates");

            migrationBuilder.DropTable(
                name: "Currency");
        }
    }
}
