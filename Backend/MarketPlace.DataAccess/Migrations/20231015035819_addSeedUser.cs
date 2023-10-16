using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarketPlace.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addSeedUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 14, 20, 58, 19, 737, DateTimeKind.Local).AddTicks(2375));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 14, 20, 58, 19, 737, DateTimeKind.Local).AddTicks(2732));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "SelectedLanguage" },
                values: new object[] { new DateTime(2023, 10, 14, 20, 58, 19, 737, DateTimeKind.Local).AddTicks(2956), 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 14, 20, 56, 26, 469, DateTimeKind.Local).AddTicks(3101));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 14, 20, 56, 26, 469, DateTimeKind.Local).AddTicks(3435));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "SelectedLanguage" },
                values: new object[] { new DateTime(2023, 10, 14, 20, 56, 26, 469, DateTimeKind.Local).AddTicks(3653), 0 });
        }
    }
}
