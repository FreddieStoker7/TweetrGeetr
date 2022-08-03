using Microsoft.EntityFrameworkCore.Migrations;

namespace TweetrGeetr.Migrations
{
    public partial class changedTablDataTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tweets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TweetsFromApi",
                table: "TweetsFromApi");

            migrationBuilder.RenameTable(
                name: "TweetsFromApi",
                newName: "AllTweets");

            migrationBuilder.AddColumn<bool>(
                name: "isItBlogged",
                table: "AllTweets",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AllTweets",
                table: "AllTweets",
                column: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AllTweets",
                table: "AllTweets");

            migrationBuilder.DropColumn(
                name: "isItBlogged",
                table: "AllTweets");

            migrationBuilder.RenameTable(
                name: "AllTweets",
                newName: "TweetsFromApi");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TweetsFromApi",
                table: "TweetsFromApi",
                column: "id");

            migrationBuilder.CreateTable(
                name: "Tweets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SocialMediaTypeId = table.Column<int>(type: "int", nullable: true),
                    TweetContent = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tweets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tweets_SocialMediaTypes_SocialMediaTypeId",
                        column: x => x.SocialMediaTypeId,
                        principalTable: "SocialMediaTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tweets_SocialMediaTypeId",
                table: "Tweets",
                column: "SocialMediaTypeId");
        }
    }
}
