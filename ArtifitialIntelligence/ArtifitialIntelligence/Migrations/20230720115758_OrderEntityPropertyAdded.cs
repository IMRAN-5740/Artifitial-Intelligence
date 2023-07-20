using Microsoft.EntityFrameworkCore.Migrations;

namespace ArtifitialIntelligence.Migrations
{
    public partial class OrderEntityPropertyAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "TotalOrderAmount",
                table: "Orders",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalOrderAmount",
                table: "Orders");
        }
    }
}
