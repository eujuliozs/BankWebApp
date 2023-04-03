using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankWebApp.Migrations
{
    public partial class AddingOwnerIdProptoTr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransactionRecords_Owner_OwnerId",
                table: "TransactionRecords");

            migrationBuilder.RenameColumn(
                name: "OwnerId",
                table: "TransactionRecords",
                newName: "OwnerIdId");

            migrationBuilder.RenameIndex(
                name: "IX_TransactionRecords_OwnerId",
                table: "TransactionRecords",
                newName: "IX_TransactionRecords_OwnerIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionRecords_Owner_OwnerIdId",
                table: "TransactionRecords",
                column: "OwnerIdId",
                principalTable: "Owner",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransactionRecords_Owner_OwnerIdId",
                table: "TransactionRecords");

            migrationBuilder.RenameColumn(
                name: "OwnerIdId",
                table: "TransactionRecords",
                newName: "OwnerId");

            migrationBuilder.RenameIndex(
                name: "IX_TransactionRecords_OwnerIdId",
                table: "TransactionRecords",
                newName: "IX_TransactionRecords_OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionRecords_Owner_OwnerId",
                table: "TransactionRecords",
                column: "OwnerId",
                principalTable: "Owner",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
