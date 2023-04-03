using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankWebApp.Migrations
{
    public partial class correction4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReceiverNumber",
                table: "TransactionRecord");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ReceiverNumber",
                table: "TransactionRecord",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
