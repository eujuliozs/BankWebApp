using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankWebApp.Migrations
{
    public partial class TransactionRecordON : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransactionRecord_Account_AccountId",
                table: "TransactionRecord");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TransactionRecord",
                table: "TransactionRecord");

            migrationBuilder.RenameTable(
                name: "TransactionRecord",
                newName: "TransactionRecords");

            migrationBuilder.RenameIndex(
                name: "IX_TransactionRecord_AccountId",
                table: "TransactionRecords",
                newName: "IX_TransactionRecords_AccountId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TransactionRecords",
                table: "TransactionRecords",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionRecords_Account_AccountId",
                table: "TransactionRecords",
                column: "AccountId",
                principalTable: "Account",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransactionRecords_Account_AccountId",
                table: "TransactionRecords");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TransactionRecords",
                table: "TransactionRecords");

            migrationBuilder.RenameTable(
                name: "TransactionRecords",
                newName: "TransactionRecord");

            migrationBuilder.RenameIndex(
                name: "IX_TransactionRecords_AccountId",
                table: "TransactionRecord",
                newName: "IX_TransactionRecord_AccountId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TransactionRecord",
                table: "TransactionRecord",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionRecord_Account_AccountId",
                table: "TransactionRecord",
                column: "AccountId",
                principalTable: "Account",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
