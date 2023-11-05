using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarketPlace.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddAllWorkplaces : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 5, 23, 11, 30, 325, DateTimeKind.Local).AddTicks(5021));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 5, 23, 11, 30, 325, DateTimeKind.Local).AddTicks(8950));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 5, 23, 11, 30, 325, DateTimeKind.Local).AddTicks(8958));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 5, 23, 11, 30, 325, DateTimeKind.Local).AddTicks(8962));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 5, 23, 11, 30, 325, DateTimeKind.Local).AddTicks(8966));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 5, 23, 11, 30, 325, DateTimeKind.Local).AddTicks(8969));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 5, 23, 11, 30, 325, DateTimeKind.Local).AddTicks(8972));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 5, 23, 11, 30, 325, DateTimeKind.Local).AddTicks(8975));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 5, 23, 11, 30, 325, DateTimeKind.Local).AddTicks(8978));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 5, 23, 11, 30, 325, DateTimeKind.Local).AddTicks(8981));

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "Id", "CreatedDate", "CreatedUserId", "DeletedDate", "DeletedUserId", "Icon", "IsDeleted", "IsHide", "Name", "OrderNumber", "ParentId", "Path", "UIName", "UpdatedDate", "UpdatedUserId" },
                values: new object[] { 10, new DateTime(2023, 11, 5, 23, 11, 30, 325, DateTimeKind.Local).AddTicks(8984), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "user", false, true, "AdminAllWorkplaces", 2, 2, "/adminAllWorkplaces", "adminAllWorkplaces", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 });

            migrationBuilder.UpdateData(
                table: "RoleMenus",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 5, 23, 11, 30, 325, DateTimeKind.Local).AddTicks(9938));

            migrationBuilder.UpdateData(
                table: "RoleMenus",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 5, 23, 11, 30, 325, DateTimeKind.Local).AddTicks(9943));

            migrationBuilder.UpdateData(
                table: "RoleMenus",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 5, 23, 11, 30, 325, DateTimeKind.Local).AddTicks(9945));

            migrationBuilder.UpdateData(
                table: "RoleMenus",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 5, 23, 11, 30, 325, DateTimeKind.Local).AddTicks(9946));

            migrationBuilder.UpdateData(
                table: "RoleMenus",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 5, 23, 11, 30, 325, DateTimeKind.Local).AddTicks(9948));

            migrationBuilder.UpdateData(
                table: "RoleMenus",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 5, 23, 11, 30, 325, DateTimeKind.Local).AddTicks(9951));

            migrationBuilder.UpdateData(
                table: "RoleMenus",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 5, 23, 11, 30, 325, DateTimeKind.Local).AddTicks(9953));

            migrationBuilder.UpdateData(
                table: "RoleMenus",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 5, 23, 11, 30, 325, DateTimeKind.Local).AddTicks(9955));

            migrationBuilder.UpdateData(
                table: "RoleMenus",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 5, 23, 11, 30, 325, DateTimeKind.Local).AddTicks(9957));

            migrationBuilder.UpdateData(
                table: "RoleMenus",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 5, 23, 11, 30, 325, DateTimeKind.Local).AddTicks(9959));

            migrationBuilder.UpdateData(
                table: "RoleMenus",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 5, 23, 11, 30, 325, DateTimeKind.Local).AddTicks(9961));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 5, 23, 11, 30, 325, DateTimeKind.Local).AddTicks(6282));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 5, 23, 11, 30, 325, DateTimeKind.Local).AddTicks(6289));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 5, 23, 11, 30, 325, DateTimeKind.Local).AddTicks(6291));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 5, 23, 11, 30, 325, DateTimeKind.Local).AddTicks(6294));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 5, 23, 11, 30, 325, DateTimeKind.Local).AddTicks(7529));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 3, 23, 44, 35, 479, DateTimeKind.Local).AddTicks(9540));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 3, 23, 44, 35, 480, DateTimeKind.Local).AddTicks(512));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 3, 23, 44, 35, 480, DateTimeKind.Local).AddTicks(516));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 3, 23, 44, 35, 480, DateTimeKind.Local).AddTicks(519));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 3, 23, 44, 35, 480, DateTimeKind.Local).AddTicks(522));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 3, 23, 44, 35, 480, DateTimeKind.Local).AddTicks(524));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 3, 23, 44, 35, 480, DateTimeKind.Local).AddTicks(527));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 3, 23, 44, 35, 480, DateTimeKind.Local).AddTicks(529));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 3, 23, 44, 35, 480, DateTimeKind.Local).AddTicks(532));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 3, 23, 44, 35, 480, DateTimeKind.Local).AddTicks(534));

            migrationBuilder.UpdateData(
                table: "RoleMenus",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 3, 23, 44, 35, 480, DateTimeKind.Local).AddTicks(781));

            migrationBuilder.UpdateData(
                table: "RoleMenus",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 3, 23, 44, 35, 480, DateTimeKind.Local).AddTicks(784));

            migrationBuilder.UpdateData(
                table: "RoleMenus",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 3, 23, 44, 35, 480, DateTimeKind.Local).AddTicks(786));

            migrationBuilder.UpdateData(
                table: "RoleMenus",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 3, 23, 44, 35, 480, DateTimeKind.Local).AddTicks(787));

            migrationBuilder.UpdateData(
                table: "RoleMenus",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 3, 23, 44, 35, 480, DateTimeKind.Local).AddTicks(789));

            migrationBuilder.UpdateData(
                table: "RoleMenus",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 3, 23, 44, 35, 480, DateTimeKind.Local).AddTicks(791));

            migrationBuilder.UpdateData(
                table: "RoleMenus",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 3, 23, 44, 35, 480, DateTimeKind.Local).AddTicks(793));

            migrationBuilder.UpdateData(
                table: "RoleMenus",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 3, 23, 44, 35, 480, DateTimeKind.Local).AddTicks(795));

            migrationBuilder.UpdateData(
                table: "RoleMenus",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 3, 23, 44, 35, 480, DateTimeKind.Local).AddTicks(797));

            migrationBuilder.UpdateData(
                table: "RoleMenus",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 3, 23, 44, 35, 480, DateTimeKind.Local).AddTicks(798));

            migrationBuilder.UpdateData(
                table: "RoleMenus",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 3, 23, 44, 35, 480, DateTimeKind.Local).AddTicks(800));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 3, 23, 44, 35, 479, DateTimeKind.Local).AddTicks(9963));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 3, 23, 44, 35, 479, DateTimeKind.Local).AddTicks(9967));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 3, 23, 44, 35, 479, DateTimeKind.Local).AddTicks(9995));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 3, 23, 44, 35, 479, DateTimeKind.Local).AddTicks(9997));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 3, 23, 44, 35, 480, DateTimeKind.Local).AddTicks(249));
        }
    }
}
