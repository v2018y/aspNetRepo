using Microsoft.EntityFrameworkCore.Migrations;

namespace CMDAPI.Migrations
{
    public partial class AddedFoIdprimerykeyinOthertable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "Invoice",
                newName: "invId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "HTable",
                newName: "tabId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "FoodQty",
                newName: "fqId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "invId",
                table: "Invoice",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "tabId",
                table: "HTable",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "fqId",
                table: "FoodQty",
                newName: "id");
        }
    }
}
