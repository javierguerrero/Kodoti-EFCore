using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Database.Migrations
{
    public partial class AddProductExtraInformationTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductsExtraInformation",
                columns: table => new
                {
                    ProductExtraInformationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SKU = table.Column<string>(maxLength: 20, nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: false),
                    Image = table.Column<string>(nullable: true),
                    Weight = table.Column<int>(nullable: false),
                    Height = table.Column<int>(nullable: false),
                    Size = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsExtraInformation", x => x.ProductExtraInformationId);
                    table.ForeignKey(
                        name: "FK_ProductsExtraInformation_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductsExtraInformation_ProductId",
                table: "ProductsExtraInformation",
                column: "ProductId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductsExtraInformation");
        }
    }
}
