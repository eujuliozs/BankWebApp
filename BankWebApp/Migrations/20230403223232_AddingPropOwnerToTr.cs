using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankWebApp.Migrations
{
    public partial class AddingPropOwnerToTr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                table: "TransactionRecords",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TransactionRecords_OwnerId",
                table: "TransactionRecords",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionRecords_Owner_OwnerId",
                table: "TransactionRecords",
                column: "OwnerId",
                principalTable: "Owner",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransactionRecords_Owner_OwnerId",
                table: "TransactionRecords");

            migrationBuilder.DropIndex(
                name: "IX_TransactionRecords_OwnerId",
                table: "TransactionRecords");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "TransactionRecords");
        }
    }
}
