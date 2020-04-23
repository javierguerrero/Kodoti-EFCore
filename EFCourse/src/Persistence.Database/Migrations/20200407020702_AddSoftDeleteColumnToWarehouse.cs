using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Database.Migrations
{
    public partial class AddSoftDeleteColumnToWarehouse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Warehouses",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Warehouses");
        }
    }
}
