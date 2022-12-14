using Microsoft.EntityFrameworkCore.Migrations;

namespace ArtifitialIntelligence.Data.Migrations
{
    public partial class addCompaniesTableIntoDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(nullable: false),
                    Summary = table.Column<string>(nullable: false),
                    ImageFileName = table.Column<string>(nullable: false),
                    AnchorLink = table.Column<string>(nullable: false),
                    Like = table.Column<int>(nullable: false),
                    canIncreaseLike = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
