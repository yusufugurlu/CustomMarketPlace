using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarketPlace.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddAdminCompanyInMenu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 28, 17, 5, 9, 456, DateTimeKind.Local).AddTicks(6577));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 28, 17, 5, 9, 456, DateTimeKind.Local).AddTicks(7580));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 28, 17, 5, 9, 456, DateTimeKind.Local).AddTicks(7584));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 28, 17, 5, 9, 456, DateTimeKind.Local).AddTicks(7586));

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "Id", "CreatedDate", "CreatedUserId", "DeletedDate", "DeletedUserId", "Icon", "IsDeleted", "IsHide", "Name", "OrderNumber", "ParentId", "Path", "UIName", "UpdatedDate", "UpdatedUserId" },
                values: new object[] { 4, new DateTime(2023, 10, 28, 17, 5, 9, 456, DateTimeKind.Local).AddTicks(7589), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "user", false, true, "AdminCompanies", 2, 2, "/adminCompanies", "adminCompanies", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 });

            migrationBuilder.UpdateData(
                table: "RoleMenus",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 28, 17, 5, 9, 456, DateTimeKind.Local).AddTicks(8169));

            migrationBuilder.UpdateData(
                table: "RoleMenus",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 28, 17, 5, 9, 456, DateTimeKind.Local).AddTicks(8172));

            migrationBuilder.UpdateData(
                table: "RoleMenus",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 28, 17, 5, 9, 456, DateTimeKind.Local).AddTicks(8174));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 28, 17, 5, 9, 456, DateTimeKind.Local).AddTicks(7027));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 28, 17, 5, 9, 456, DateTimeKind.Local).AddTicks(7291));

            migrationBuilder.InsertData(
                table: "RoleMenus",
                columns: new[] { "Id", "CreatedDate", "CreatedUserId", "DeletedDate", "DeletedUserId", "IsDeleted", "MenuId", "RoleId", "UpdatedDate", "UpdatedUserId" },
                values: new object[] { 4, new DateTime(2023, 10, 28, 17, 5, 9, 456, DateTimeKind.Local).AddTicks(8175), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, false, 4, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RoleMenus",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 4);

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
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 22, 57, 41, 94, DateTimeKind.Local).AddTicks(3338));

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
    }
}
