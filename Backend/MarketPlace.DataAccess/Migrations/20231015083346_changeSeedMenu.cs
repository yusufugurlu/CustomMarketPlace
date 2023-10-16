using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarketPlace.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class changeSeedMenu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 15, 1, 33, 46, 679, DateTimeKind.Local).AddTicks(3179));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Path" },
                values: new object[] { new DateTime(2023, 10, 15, 1, 33, 46, 679, DateTimeKind.Local).AddTicks(3992), "/" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Icon" },
                values: new object[] { new DateTime(2023, 10, 15, 1, 33, 46, 679, DateTimeKind.Local).AddTicks(3995), "shop" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 15, 1, 33, 46, 679, DateTimeKind.Local).AddTicks(3998));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 15, 1, 33, 46, 679, DateTimeKind.Local).AddTicks(3548));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 15, 1, 33, 46, 679, DateTimeKind.Local).AddTicks(3789));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 15, 0, 0, 37, 730, DateTimeKind.Local).AddTicks(5809));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Path" },
                values: new object[] { new DateTime(2023, 10, 15, 0, 0, 37, 730, DateTimeKind.Local).AddTicks(6731), "" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Icon" },
                values: new object[] { new DateTime(2023, 10, 15, 0, 0, 37, 730, DateTimeKind.Local).AddTicks(6735), "company" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 15, 0, 0, 37, 730, DateTimeKind.Local).AddTicks(6738));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 15, 0, 0, 37, 730, DateTimeKind.Local).AddTicks(6222));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 15, 0, 0, 37, 730, DateTimeKind.Local).AddTicks(6483));
        }
    }
}
