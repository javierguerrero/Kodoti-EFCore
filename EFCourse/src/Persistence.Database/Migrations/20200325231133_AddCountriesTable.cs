using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Database.Migrations
{
    public partial class AddCountriesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Country_Id",
                table: "Clients",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryId);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryId", "Name" },
                values: new object[] { 1, "Peru" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryId", "Name" },
                values: new object[] { 2, "México" });

            migrationBuilder.CreateIndex(
                name: "IX_Clients_Country_Id",
                table: "Clients",
                column: "Country_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Countries_Country_Id",
                table: "Clients",
                column: "Country_Id",
                principalTable: "Countries",
                principalColumn: "CountryId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Countries_Country_Id",
                table: "Clients");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropIndex(
                name: "IX_Clients_Country_Id",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Country_Id",
                table: "Clients");
        }
    }
}
