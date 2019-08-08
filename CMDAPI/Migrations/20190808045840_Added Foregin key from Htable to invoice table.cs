using Microsoft.EntityFrameworkCore.Migrations;

namespace CMDAPI.Migrations
{
    public partial class AddedForeginkeyfromHtabletoinvoicetable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Invoice_tabId",
                table: "Invoice",
                column: "tabId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_HTable_tabId",
                table: "Invoice",
                column: "tabId",
                principalTable: "HTable",
                principalColumn: "tabId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_HTable_tabId",
                table: "Invoice");

            migrationBuilder.DropIndex(
                name: "IX_Invoice_tabId",
                table: "Invoice");
        }
    }
}
