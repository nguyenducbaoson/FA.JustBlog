using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FA.JustBlog.Entities.Migrations
{
    public partial class gg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UrlSlug = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modify = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "LocalUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PassWord = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocalUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    TagId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UrlSlug = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modify = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.TagId);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    PostId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortDecription = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    PostContent = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    UrlSlug = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Published = table.Column<bool>(type: "bit", nullable: true),
                    PostOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    ViewCount = table.Column<int>(type: "int", nullable: true),
                    RateCount = table.Column<int>(type: "int", nullable: true),
                    TotalRate = table.Column<int>(type: "int", nullable: true),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modify = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.PostId);
                    table.ForeignKey(
                        name: "FK_Posts_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    CommentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommentHeader = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommentText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommentTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PostId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_Comments_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "PostId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PostTagMaps",
                columns: table => new
                {
                    PostId = table.Column<int>(type: "int", nullable: false),
                    TagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostTagMaps", x => new { x.TagId, x.PostId });
                    table.ForeignKey(
                        name: "FK_PostTagMaps_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "PostId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostTagMaps_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "TagId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName", "CreateAt", "Description", "Modify", "Status", "UrlSlug" },
                values: new object[,]
                {
                    { 1, "Science", new DateTime(2022, 11, 4, 9, 55, 20, 625, DateTimeKind.Local).AddTicks(854), "Delecius", new DateTime(2022, 11, 4, 9, 55, 20, 625, DateTimeKind.Local).AddTicks(855), 1, "#" },
                    { 2, "Social", new DateTime(2022, 11, 4, 9, 55, 20, 625, DateTimeKind.Local).AddTicks(857), "Delecius", new DateTime(2022, 11, 4, 9, 55, 20, 625, DateTimeKind.Local).AddTicks(858), 1, "#" },
                    { 3, "Culture", new DateTime(2022, 11, 4, 9, 55, 20, 625, DateTimeKind.Local).AddTicks(859), "Not good", new DateTime(2022, 11, 4, 9, 55, 20, 625, DateTimeKind.Local).AddTicks(860), 1, "#" },
                    { 4, "Travel", new DateTime(2022, 11, 4, 9, 55, 20, 625, DateTimeKind.Local).AddTicks(861), "Delecius", new DateTime(2022, 11, 4, 9, 55, 20, 625, DateTimeKind.Local).AddTicks(862), 1, "#" }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "TagId", "Count", "CreateAt", "Description", "Modify", "Name", "Status", "UrlSlug" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "None", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bao Son", 0, "Tag/what-is-a-url-slug1" },
                    { 2, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Andreww", 0, "Tag/what-is-a-url-slug2" },
                    { 3, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description 1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nam", 0, "Tag/what-is-a-url-slug3" },
                    { 4, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description 3", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nhung", 0, "Tag/what-is-a-url-slug3" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "CategoryId", "CreateAt", "Modify", "PostContent", "PostOn", "Published", "RateCount", "ShortDecription", "Status", "Title", "TotalRate", "UrlSlug", "ViewCount" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2022, 11, 4, 9, 55, 20, 625, DateTimeKind.Local).AddTicks(667), new DateTime(2022, 11, 4, 9, 55, 20, 625, DateTimeKind.Local).AddTicks(656), "Post content", new DateTime(2012, 12, 25, 1, 3, 12, 0, DateTimeKind.Unspecified), true, null, "mot", 1, "Title 1", null, "Url1", null },
                    { 2, 1, new DateTime(2022, 11, 4, 9, 55, 20, 625, DateTimeKind.Local).AddTicks(674), new DateTime(2022, 11, 4, 9, 55, 20, 625, DateTimeKind.Local).AddTicks(673), "employee", new DateTime(2021, 12, 25, 1, 3, 12, 0, DateTimeKind.Unspecified), true, null, "hai", 1, "Title 2", null, "Url12", null },
                    { 3, 2, new DateTime(2022, 11, 4, 9, 55, 20, 625, DateTimeKind.Local).AddTicks(679), new DateTime(2022, 11, 4, 9, 55, 20, 625, DateTimeKind.Local).AddTicks(678), "Name", new DateTime(2020, 12, 25, 1, 3, 12, 0, DateTimeKind.Unspecified), true, null, "ba", 1, "Title 3", null, "Url3", null },
                    { 4, 2, new DateTime(2022, 11, 4, 9, 55, 20, 625, DateTimeKind.Local).AddTicks(681), new DateTime(2022, 11, 4, 9, 55, 20, 625, DateTimeKind.Local).AddTicks(681), "gae", new DateTime(2016, 12, 25, 1, 3, 12, 0, DateTimeKind.Unspecified), false, null, "bon", 1, "Title 4", null, "Url4", null },
                    { 5, 1, new DateTime(2022, 11, 4, 9, 55, 20, 625, DateTimeKind.Local).AddTicks(684), new DateTime(2022, 11, 4, 9, 55, 20, 625, DateTimeKind.Local).AddTicks(683), "Car", new DateTime(2015, 12, 25, 1, 3, 12, 0, DateTimeKind.Unspecified), true, null, "nam", 1, "Title 5", null, "Url5", null }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "CommentId", "CommentHeader", "CommentText", "CommentTime", "Email", "Name", "PostId" },
                values: new object[,]
                {
                    { 1, "None", "None", new DateTime(2015, 12, 25, 1, 3, 12, 0, DateTimeKind.Unspecified), "Andreww@gmail.com", "Adnreww", 1 },
                    { 2, "None", "None", new DateTime(2015, 12, 25, 1, 3, 12, 0, DateTimeKind.Unspecified), "Andreww@gmail.com", "baoson", 1 },
                    { 13, "None", "None", new DateTime(2015, 12, 25, 1, 3, 12, 0, DateTimeKind.Unspecified), "Andreww@gmail.com", "thuyen", 1 }
                });

            migrationBuilder.InsertData(
                table: "PostTagMaps",
                columns: new[] { "PostId", "TagId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 1 },
                    { 1, 2 },
                    { 1, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId",
                table: "Comments",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_CategoryId",
                table: "Posts",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PostTagMaps_PostId",
                table: "PostTagMaps",
                column: "PostId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "LocalUsers");

            migrationBuilder.DropTable(
                name: "PostTagMaps");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
