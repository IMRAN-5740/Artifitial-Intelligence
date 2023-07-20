using Microsoft.EntityFrameworkCore.Migrations;

namespace ArtifitialIntelligence.Migrations
{
    public partial class OrderTableProcessIDColumnAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TransactionID",
                table: "Orders",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TransactionID",
                table: "Orders");
        }
    }
}
