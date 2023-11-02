using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarketPlace.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddMenuCacheManagment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 1, 19, 5, 35, 946, DateTimeKind.Local).AddTicks(135));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 1, 19, 5, 35, 946, DateTimeKind.Local).AddTicks(1527));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 1, 19, 5, 35, 946, DateTimeKind.Local).AddTicks(1533));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 1, 19, 5, 35, 946, DateTimeKind.Local).AddTicks(1537));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 1, 19, 5, 35, 946, DateTimeKind.Local).AddTicks(1540));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 1, 19, 5, 35, 946, DateTimeKind.Local).AddTicks(1543));

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "Id", "CreatedDate", "CreatedUserId", "DeletedDate", "DeletedUserId", "Icon", "IsDeleted", "IsHide", "Name", "OrderNumber", "ParentId", "Path", "UIName", "UpdatedDate", "UpdatedUserId" },
                values: new object[] { 6, new DateTime(2023, 11, 1, 19, 5, 35, 946, DateTimeKind.Local).AddTicks(1546), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "user", false, true, "CacheManagment", 2, 2, "/cacheManagment", "cacheManagment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 });

            migrationBuilder.UpdateData(
                table: "RoleMenus",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 1, 19, 5, 35, 946, DateTimeKind.Local).AddTicks(2514));

            migrationBuilder.UpdateData(
                table: "RoleMenus",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 1, 19, 5, 35, 946, DateTimeKind.Local).AddTicks(2525));

            migrationBuilder.UpdateData(
                table: "RoleMenus",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 1, 19, 5, 35, 946, DateTimeKind.Local).AddTicks(2528));

            migrationBuilder.UpdateData(
                table: "RoleMenus",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 1, 19, 5, 35, 946, DateTimeKind.Local).AddTicks(2530));

            migrationBuilder.UpdateData(
                table: "RoleMenus",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 1, 19, 5, 35, 946, DateTimeKind.Local).AddTicks(2532));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 1, 19, 5, 35, 946, DateTimeKind.Local).AddTicks(724));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 1, 19, 5, 35, 946, DateTimeKind.Local).AddTicks(731));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 1, 19, 5, 35, 946, DateTimeKind.Local).AddTicks(733));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 1, 19, 5, 35, 946, DateTimeKind.Local).AddTicks(736));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 1, 19, 5, 35, 946, DateTimeKind.Local).AddTicks(1127));

            migrationBuilder.InsertData(
                table: "RoleMenus",
                columns: new[] { "Id", "CreatedDate", "CreatedUserId", "DeletedDate", "DeletedUserId", "IsDeleted", "MenuId", "RoleId", "UpdatedDate", "UpdatedUserId" },
                values: new object[] { 6, new DateTime(2023, 11, 1, 19, 5, 35, 946, DateTimeKind.Local).AddTicks(2534), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, false, 6, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RoleMenus",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 29, 16, 33, 24, 789, DateTimeKind.Local).AddTicks(9536));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 29, 16, 33, 24, 790, DateTimeKind.Local).AddTicks(538));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 29, 16, 33, 24, 790, DateTimeKind.Local).AddTicks(542));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 29, 16, 33, 24, 790, DateTimeKind.Local).AddTicks(544));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 29, 16, 33, 24, 790, DateTimeKind.Local).AddTicks(547));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 29, 16, 33, 24, 790, DateTimeKind.Local).AddTicks(550));

            migrationBuilder.UpdateData(
                table: "RoleMenus",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 29, 16, 33, 24, 790, DateTimeKind.Local).AddTicks(1162));

            migrationBuilder.UpdateData(
                table: "RoleMenus",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 29, 16, 33, 24, 790, DateTimeKind.Local).AddTicks(1165));

            migrationBuilder.UpdateData(
                table: "RoleMenus",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 29, 16, 33, 24, 790, DateTimeKind.Local).AddTicks(1167));

            migrationBuilder.UpdateData(
                table: "RoleMenus",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 29, 16, 33, 24, 790, DateTimeKind.Local).AddTicks(1168));

            migrationBuilder.UpdateData(
                table: "RoleMenus",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 29, 16, 33, 24, 790, DateTimeKind.Local).AddTicks(1170));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 29, 16, 33, 24, 789, DateTimeKind.Local).AddTicks(9984));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 29, 16, 33, 24, 789, DateTimeKind.Local).AddTicks(9989));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 29, 16, 33, 24, 789, DateTimeKind.Local).AddTicks(9991));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 29, 16, 33, 24, 789, DateTimeKind.Local).AddTicks(9993));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 29, 16, 33, 24, 790, DateTimeKind.Local).AddTicks(268));
        }
    }
}
