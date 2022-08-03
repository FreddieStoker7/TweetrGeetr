using Microsoft.EntityFrameworkCore.Migrations;

namespace TweetrGeetr.Migrations
{
    public partial class TweetDataFromApiAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TweetsFromApi",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    text = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TweetsFromApi", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TweetsFromApi");
        }
    }
}
