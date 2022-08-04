using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TweetrGeetr.Migrations
{
    public partial class freshSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AllTweets",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    text = table.Column<string>(nullable: true),
                    isItBlogged = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllTweets", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "SocialMediaTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialMediaTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BlogComments",
                columns: table => new
                {
                    BlogEntryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id = table.Column<string>(nullable: true),
                    CommentContent = table.Column<string>(nullable: true),
                    DateTimePosted = table.Column<DateTime>(nullable: false),
                    Datumid = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogComments", x => x.BlogEntryId);
                    table.ForeignKey(
                        name: "FK_BlogComments_AllTweets_Datumid",
                        column: x => x.Datumid,
                        principalTable: "AllTweets",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlogComments_Datumid",
                table: "BlogComments",
                column: "Datumid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogComments");

            migrationBuilder.DropTable(
                name: "SocialMediaTypes");

            migrationBuilder.DropTable(
                name: "AllTweets");
        }
    }
}
