using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FA.JustBlog.Entities.Migrations
{
    public partial class AddUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1,
                columns: new[] { "CreateAt", "Modify" },
                values: new object[] { new DateTime(2022, 10, 24, 10, 44, 49, 89, DateTimeKind.Local).AddTicks(4096), new DateTime(2022, 10, 24, 10, 44, 49, 89, DateTimeKind.Local).AddTicks(4097) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2,
                columns: new[] { "CreateAt", "Modify" },
                values: new object[] { new DateTime(2022, 10, 24, 10, 44, 49, 89, DateTimeKind.Local).AddTicks(4099), new DateTime(2022, 10, 24, 10, 44, 49, 89, DateTimeKind.Local).AddTicks(4099) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3,
                columns: new[] { "CreateAt", "Modify" },
                values: new object[] { new DateTime(2022, 10, 24, 10, 44, 49, 89, DateTimeKind.Local).AddTicks(4101), new DateTime(2022, 10, 24, 10, 44, 49, 89, DateTimeKind.Local).AddTicks(4101) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 4,
                columns: new[] { "CreateAt", "Modify" },
                values: new object[] { new DateTime(2022, 10, 24, 10, 44, 49, 89, DateTimeKind.Local).AddTicks(4102), new DateTime(2022, 10, 24, 10, 44, 49, 89, DateTimeKind.Local).AddTicks(4103) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                columns: new[] { "CreateAt", "Modify" },
                values: new object[] { new DateTime(2022, 10, 24, 10, 44, 49, 89, DateTimeKind.Local).AddTicks(3949), new DateTime(2022, 10, 24, 10, 44, 49, 89, DateTimeKind.Local).AddTicks(3939) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 2,
                columns: new[] { "CreateAt", "Modify" },
                values: new object[] { new DateTime(2022, 10, 24, 10, 44, 49, 89, DateTimeKind.Local).AddTicks(3953), new DateTime(2022, 10, 24, 10, 44, 49, 89, DateTimeKind.Local).AddTicks(3951) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 3,
                columns: new[] { "CreateAt", "Modify" },
                values: new object[] { new DateTime(2022, 10, 24, 10, 44, 49, 89, DateTimeKind.Local).AddTicks(3955), new DateTime(2022, 10, 24, 10, 44, 49, 89, DateTimeKind.Local).AddTicks(3955) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 4,
                columns: new[] { "CreateAt", "Modify" },
                values: new object[] { new DateTime(2022, 10, 24, 10, 44, 49, 89, DateTimeKind.Local).AddTicks(3958), new DateTime(2022, 10, 24, 10, 44, 49, 89, DateTimeKind.Local).AddTicks(3957) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 5,
                columns: new[] { "CreateAt", "Modify" },
                values: new object[] { new DateTime(2022, 10, 24, 10, 44, 49, 89, DateTimeKind.Local).AddTicks(3960), new DateTime(2022, 10, 24, 10, 44, 49, 89, DateTimeKind.Local).AddTicks(3959) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LocalUsers");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1,
                columns: new[] { "CreateAt", "Modify" },
                values: new object[] { new DateTime(2022, 10, 21, 13, 50, 18, 860, DateTimeKind.Local).AddTicks(2659), new DateTime(2022, 10, 21, 13, 50, 18, 860, DateTimeKind.Local).AddTicks(2660) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2,
                columns: new[] { "CreateAt", "Modify" },
                values: new object[] { new DateTime(2022, 10, 21, 13, 50, 18, 860, DateTimeKind.Local).AddTicks(2662), new DateTime(2022, 10, 21, 13, 50, 18, 860, DateTimeKind.Local).AddTicks(2663) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3,
                columns: new[] { "CreateAt", "Modify" },
                values: new object[] { new DateTime(2022, 10, 21, 13, 50, 18, 860, DateTimeKind.Local).AddTicks(2664), new DateTime(2022, 10, 21, 13, 50, 18, 860, DateTimeKind.Local).AddTicks(2665) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 4,
                columns: new[] { "CreateAt", "Modify" },
                values: new object[] { new DateTime(2022, 10, 21, 13, 50, 18, 860, DateTimeKind.Local).AddTicks(2666), new DateTime(2022, 10, 21, 13, 50, 18, 860, DateTimeKind.Local).AddTicks(2666) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                columns: new[] { "CreateAt", "Modify" },
                values: new object[] { new DateTime(2022, 10, 21, 13, 50, 18, 860, DateTimeKind.Local).AddTicks(2525), new DateTime(2022, 10, 21, 13, 50, 18, 860, DateTimeKind.Local).AddTicks(2516) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 2,
                columns: new[] { "CreateAt", "Modify" },
                values: new object[] { new DateTime(2022, 10, 21, 13, 50, 18, 860, DateTimeKind.Local).AddTicks(2531), new DateTime(2022, 10, 21, 13, 50, 18, 860, DateTimeKind.Local).AddTicks(2529) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 3,
                columns: new[] { "CreateAt", "Modify" },
                values: new object[] { new DateTime(2022, 10, 21, 13, 50, 18, 860, DateTimeKind.Local).AddTicks(2533), new DateTime(2022, 10, 21, 13, 50, 18, 860, DateTimeKind.Local).AddTicks(2533) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 4,
                columns: new[] { "CreateAt", "Modify" },
                values: new object[] { new DateTime(2022, 10, 21, 13, 50, 18, 860, DateTimeKind.Local).AddTicks(2536), new DateTime(2022, 10, 21, 13, 50, 18, 860, DateTimeKind.Local).AddTicks(2535) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 5,
                columns: new[] { "CreateAt", "Modify" },
                values: new object[] { new DateTime(2022, 10, 21, 13, 50, 18, 860, DateTimeKind.Local).AddTicks(2538), new DateTime(2022, 10, 21, 13, 50, 18, 860, DateTimeKind.Local).AddTicks(2537) });
        }
    }
}
