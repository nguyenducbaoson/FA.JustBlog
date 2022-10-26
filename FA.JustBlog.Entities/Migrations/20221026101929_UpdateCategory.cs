using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FA.JustBlog.Entities.Migrations
{
    public partial class UpdateCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1,
                columns: new[] { "CreateAt", "Modify" },
                values: new object[] { new DateTime(2022, 10, 26, 17, 19, 28, 874, DateTimeKind.Local).AddTicks(1792), new DateTime(2022, 10, 26, 17, 19, 28, 874, DateTimeKind.Local).AddTicks(1793) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2,
                columns: new[] { "CreateAt", "Modify" },
                values: new object[] { new DateTime(2022, 10, 26, 17, 19, 28, 874, DateTimeKind.Local).AddTicks(1795), new DateTime(2022, 10, 26, 17, 19, 28, 874, DateTimeKind.Local).AddTicks(1795) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3,
                columns: new[] { "CreateAt", "Modify" },
                values: new object[] { new DateTime(2022, 10, 26, 17, 19, 28, 874, DateTimeKind.Local).AddTicks(1797), new DateTime(2022, 10, 26, 17, 19, 28, 874, DateTimeKind.Local).AddTicks(1797) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 4,
                columns: new[] { "CreateAt", "Modify" },
                values: new object[] { new DateTime(2022, 10, 26, 17, 19, 28, 874, DateTimeKind.Local).AddTicks(1798), new DateTime(2022, 10, 26, 17, 19, 28, 874, DateTimeKind.Local).AddTicks(1799) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                columns: new[] { "CreateAt", "Modify" },
                values: new object[] { new DateTime(2022, 10, 26, 17, 19, 28, 874, DateTimeKind.Local).AddTicks(1680), new DateTime(2022, 10, 26, 17, 19, 28, 874, DateTimeKind.Local).AddTicks(1669) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 2,
                columns: new[] { "CreateAt", "Modify" },
                values: new object[] { new DateTime(2022, 10, 26, 17, 19, 28, 874, DateTimeKind.Local).AddTicks(1684), new DateTime(2022, 10, 26, 17, 19, 28, 874, DateTimeKind.Local).AddTicks(1683) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 3,
                columns: new[] { "CreateAt", "Modify" },
                values: new object[] { new DateTime(2022, 10, 26, 17, 19, 28, 874, DateTimeKind.Local).AddTicks(1686), new DateTime(2022, 10, 26, 17, 19, 28, 874, DateTimeKind.Local).AddTicks(1685) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 4,
                columns: new[] { "CreateAt", "Modify" },
                values: new object[] { new DateTime(2022, 10, 26, 17, 19, 28, 874, DateTimeKind.Local).AddTicks(1688), new DateTime(2022, 10, 26, 17, 19, 28, 874, DateTimeKind.Local).AddTicks(1688) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 5,
                columns: new[] { "CreateAt", "Modify" },
                values: new object[] { new DateTime(2022, 10, 26, 17, 19, 28, 874, DateTimeKind.Local).AddTicks(1690), new DateTime(2022, 10, 26, 17, 19, 28, 874, DateTimeKind.Local).AddTicks(1690) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
