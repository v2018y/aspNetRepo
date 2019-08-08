using Microsoft.EntityFrameworkCore.Migrations;

namespace CMDAPI.Migrations
{
    public partial class AddedForeginkeyfromFoodItemtoFoodeQtytable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "foId",
                table: "FoodQty",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_FoodQty_foId",
                table: "FoodQty",
                column: "foId");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodQty_FoodItem_foId",
                table: "FoodQty",
                column: "foId",
                principalTable: "FoodItem",
                principalColumn: "foId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodQty_FoodItem_foId",
                table: "FoodQty");

            migrationBuilder.DropIndex(
                name: "IX_FoodQty_foId",
                table: "FoodQty");

            migrationBuilder.DropColumn(
                name: "foId",
                table: "FoodQty");
        }
    }
}
