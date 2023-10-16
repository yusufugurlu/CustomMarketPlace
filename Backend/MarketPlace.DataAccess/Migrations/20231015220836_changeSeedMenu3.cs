using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarketPlace.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class changeSeedMenu3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 15, 15, 8, 36, 52, DateTimeKind.Local).AddTicks(7012));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Icon" },
                values: new object[] { new DateTime(2023, 10, 15, 15, 8, 36, 52, DateTimeKind.Local).AddTicks(7781), "tool" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 15, 15, 8, 36, 52, DateTimeKind.Local).AddTicks(7784));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 15, 15, 8, 36, 52, DateTimeKind.Local).AddTicks(7787));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 15, 15, 8, 36, 52, DateTimeKind.Local).AddTicks(7367));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 15, 15, 8, 36, 52, DateTimeKind.Local).AddTicks(7588));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 15, 14, 21, 43, 370, DateTimeKind.Local).AddTicks(1597));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Icon" },
                values: new object[] { new DateTime(2023, 10, 15, 14, 21, 43, 370, DateTimeKind.Local).AddTicks(2905), "system" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 15, 14, 21, 43, 370, DateTimeKind.Local).AddTicks(2908));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 15, 14, 21, 43, 370, DateTimeKind.Local).AddTicks(2911));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 15, 14, 21, 43, 370, DateTimeKind.Local).AddTicks(2136));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 15, 14, 21, 43, 370, DateTimeKind.Local).AddTicks(2542));
        }
    }
}
