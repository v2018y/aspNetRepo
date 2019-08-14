using Microsoft.EntityFrameworkCore.Migrations;

namespace CMDAPI.Migrations
{
    public partial class AddedTheUserIDColumnreminingTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "userId",
                table: "HTable",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "userId",
                table: "FoodItem",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "userId",
                table: "HTable");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "FoodItem");
        }
    }
}
