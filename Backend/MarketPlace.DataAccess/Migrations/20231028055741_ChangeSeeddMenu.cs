using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarketPlace.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ChangeSeeddMenu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 22, 57, 41, 94, DateTimeKind.Local).AddTicks(2554));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 22, 57, 41, 94, DateTimeKind.Local).AddTicks(3333));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 22, 57, 41, 94, DateTimeKind.Local).AddTicks(3336));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ParentId" },
                values: new object[] { new DateTime(2023, 10, 27, 22, 57, 41, 94, DateTimeKind.Local).AddTicks(3338), 2 });

            migrationBuilder.UpdateData(
                table: "RoleMenus",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 22, 57, 41, 94, DateTimeKind.Local).AddTicks(3800));

            migrationBuilder.UpdateData(
                table: "RoleMenus",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 22, 57, 41, 94, DateTimeKind.Local).AddTicks(3802));

            migrationBuilder.UpdateData(
                table: "RoleMenus",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 22, 57, 41, 94, DateTimeKind.Local).AddTicks(3804));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 22, 57, 41, 94, DateTimeKind.Local).AddTicks(2906));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 22, 57, 41, 94, DateTimeKind.Local).AddTicks(3136));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 22, 17, 29, 840, DateTimeKind.Local).AddTicks(2668));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 22, 17, 29, 840, DateTimeKind.Local).AddTicks(3450));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 22, 17, 29, 840, DateTimeKind.Local).AddTicks(3453));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ParentId" },
                values: new object[] { new DateTime(2023, 10, 27, 22, 17, 29, 840, DateTimeKind.Local).AddTicks(3455), 1 });

            migrationBuilder.UpdateData(
                table: "RoleMenus",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 22, 17, 29, 840, DateTimeKind.Local).AddTicks(3869));

            migrationBuilder.UpdateData(
                table: "RoleMenus",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 22, 17, 29, 840, DateTimeKind.Local).AddTicks(3871));

            migrationBuilder.UpdateData(
                table: "RoleMenus",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 22, 17, 29, 840, DateTimeKind.Local).AddTicks(3893));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 22, 17, 29, 840, DateTimeKind.Local).AddTicks(3038));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 22, 17, 29, 840, DateTimeKind.Local).AddTicks(3241));
        }
    }
}
