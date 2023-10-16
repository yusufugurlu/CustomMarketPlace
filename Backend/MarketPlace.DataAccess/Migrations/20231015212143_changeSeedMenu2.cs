using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarketPlace.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class changeSeedMenu2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UIName",
                table: "Menus",
                type: "text",
                nullable: false,
                defaultValue: "");

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
                columns: new[] { "CreatedDate", "UIName" },
                values: new object[] { new DateTime(2023, 10, 15, 14, 21, 43, 370, DateTimeKind.Local).AddTicks(2905), "systemManagement" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UIName" },
                values: new object[] { new DateTime(2023, 10, 15, 14, 21, 43, 370, DateTimeKind.Local).AddTicks(2908), "createCompany" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UIName" },
                values: new object[] { new DateTime(2023, 10, 15, 14, 21, 43, 370, DateTimeKind.Local).AddTicks(2911), "createUser" });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UIName",
                table: "Menus");

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
                column: "CreatedDate",
                value: new DateTime(2023, 10, 15, 1, 33, 46, 679, DateTimeKind.Local).AddTicks(3992));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 15, 1, 33, 46, 679, DateTimeKind.Local).AddTicks(3995));

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
    }
}
