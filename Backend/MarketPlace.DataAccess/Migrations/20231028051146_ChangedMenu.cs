using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarketPlace.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ChangedMenu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompanentKey",
                table: "Menus");

            migrationBuilder.AddColumn<bool>(
                name: "IsHide",
                table: "Menus",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 22, 11, 46, 883, DateTimeKind.Local).AddTicks(153));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "IsHide" },
                values: new object[] { new DateTime(2023, 10, 27, 22, 11, 46, 883, DateTimeKind.Local).AddTicks(937), false });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "IsHide" },
                values: new object[] { new DateTime(2023, 10, 27, 22, 11, 46, 883, DateTimeKind.Local).AddTicks(940), false });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "IsDeleted", "IsHide", "Name", "Path", "UIName" },
                values: new object[] { new DateTime(2023, 10, 27, 22, 11, 46, 883, DateTimeKind.Local).AddTicks(942), false, true, "AdminWorkplaces", "/adminWorkplaces", "adminWorkplaces" });

            migrationBuilder.UpdateData(
                table: "RoleMenus",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 22, 11, 46, 883, DateTimeKind.Local).AddTicks(1403));

            migrationBuilder.UpdateData(
                table: "RoleMenus",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 22, 11, 46, 883, DateTimeKind.Local).AddTicks(1405));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 22, 11, 46, 883, DateTimeKind.Local).AddTicks(505));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 22, 11, 46, 883, DateTimeKind.Local).AddTicks(732));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsHide",
                table: "Menus");

            migrationBuilder.AddColumn<string>(
                name: "CompanentKey",
                table: "Menus",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 26, 22, 47, 3, 899, DateTimeKind.Local).AddTicks(3990));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CompanentKey", "CreatedDate" },
                values: new object[] { "SystemManagement", new DateTime(2023, 10, 26, 22, 47, 3, 899, DateTimeKind.Local).AddTicks(4817) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CompanentKey", "CreatedDate" },
                values: new object[] { "Settings", new DateTime(2023, 10, 26, 22, 47, 3, 899, DateTimeKind.Local).AddTicks(4822) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CompanentKey", "CreatedDate", "IsDeleted", "Name", "Path", "UIName" },
                values: new object[] { "CreateUser", new DateTime(2023, 10, 26, 22, 47, 3, 899, DateTimeKind.Local).AddTicks(4825), true, "CreateUser", "/createUser", "createUser" });

            migrationBuilder.UpdateData(
                table: "RoleMenus",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 26, 22, 47, 3, 899, DateTimeKind.Local).AddTicks(5270));

            migrationBuilder.UpdateData(
                table: "RoleMenus",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 26, 22, 47, 3, 899, DateTimeKind.Local).AddTicks(5272));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 26, 22, 47, 3, 899, DateTimeKind.Local).AddTicks(4381));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 26, 22, 47, 3, 899, DateTimeKind.Local).AddTicks(4594));
        }
    }
}
