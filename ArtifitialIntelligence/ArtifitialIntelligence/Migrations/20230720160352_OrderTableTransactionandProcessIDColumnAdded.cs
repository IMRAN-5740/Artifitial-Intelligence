using Microsoft.EntityFrameworkCore.Migrations;

namespace ArtifitialIntelligence.Migrations
{
    public partial class OrderTableTransactionandProcessIDColumnAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OrderProcessID",
                table: "Orders",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderProcessID",
                table: "Orders");
        }
    }
}
