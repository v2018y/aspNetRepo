using Microsoft.EntityFrameworkCore.Migrations;

namespace CMDAPI.Migrations
{
    public partial class AddedForeginkeyfromFoodeQtytoInvoicetable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "fqId",
                table: "Invoice",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_fqId",
                table: "Invoice",
                column: "fqId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_FoodQty_fqId",
                table: "Invoice",
                column: "fqId",
                principalTable: "FoodQty",
                principalColumn: "fqId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_FoodQty_fqId",
                table: "Invoice");

            migrationBuilder.DropIndex(
                name: "IX_Invoice_fqId",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "fqId",
                table: "Invoice");
        }
    }
}
