using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MarketPlace.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class removeTableUserPasswordHistories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserPasswordHistories");

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 29, 16, 27, 38, 247, DateTimeKind.Local).AddTicks(3962));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 29, 16, 27, 38, 247, DateTimeKind.Local).AddTicks(4905));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 29, 16, 27, 38, 247, DateTimeKind.Local).AddTicks(4908));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 29, 16, 27, 38, 247, DateTimeKind.Local).AddTicks(4910));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 29, 16, 27, 38, 247, DateTimeKind.Local).AddTicks(4913));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 29, 16, 27, 38, 247, DateTimeKind.Local).AddTicks(4915));

            migrationBuilder.UpdateData(
                table: "RoleMenus",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 29, 16, 27, 38, 247, DateTimeKind.Local).AddTicks(5471));

            migrationBuilder.UpdateData(
                table: "RoleMenus",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 29, 16, 27, 38, 247, DateTimeKind.Local).AddTicks(5475));

            migrationBuilder.UpdateData(
                table: "RoleMenus",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 29, 16, 27, 38, 247, DateTimeKind.Local).AddTicks(5476));

            migrationBuilder.UpdateData(
                table: "RoleMenus",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 29, 16, 27, 38, 247, DateTimeKind.Local).AddTicks(5478));

            migrationBuilder.UpdateData(
                table: "RoleMenus",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 29, 16, 27, 38, 247, DateTimeKind.Local).AddTicks(5479));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 29, 16, 27, 38, 247, DateTimeKind.Local).AddTicks(4388));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 29, 16, 27, 38, 247, DateTimeKind.Local).AddTicks(4392));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 29, 16, 27, 38, 247, DateTimeKind.Local).AddTicks(4394));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 29, 16, 27, 38, 247, DateTimeKind.Local).AddTicks(4395));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 29, 16, 27, 38, 247, DateTimeKind.Local).AddTicks(4672));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserPasswordHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedUserId = table.Column<int>(type: "integer", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DeletedUserId = table.Column<int>(type: "integer", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    GuidKey = table.Column<string>(type: "text", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    IsUsed = table.Column<bool>(type: "boolean", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedUserId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPasswordHistories", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 29, 16, 23, 13, 21, DateTimeKind.Local).AddTicks(2684));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 29, 16, 23, 13, 21, DateTimeKind.Local).AddTicks(3987));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 29, 16, 23, 13, 21, DateTimeKind.Local).AddTicks(3998));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 29, 16, 23, 13, 21, DateTimeKind.Local).AddTicks(4002));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 29, 16, 23, 13, 21, DateTimeKind.Local).AddTicks(4005));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 29, 16, 23, 13, 21, DateTimeKind.Local).AddTicks(4008));

            migrationBuilder.UpdateData(
                table: "RoleMenus",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 29, 16, 23, 13, 21, DateTimeKind.Local).AddTicks(4712));

            migrationBuilder.UpdateData(
                table: "RoleMenus",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 29, 16, 23, 13, 21, DateTimeKind.Local).AddTicks(4715));

            migrationBuilder.UpdateData(
                table: "RoleMenus",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 29, 16, 23, 13, 21, DateTimeKind.Local).AddTicks(4717));

            migrationBuilder.UpdateData(
                table: "RoleMenus",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 29, 16, 23, 13, 21, DateTimeKind.Local).AddTicks(4719));

            migrationBuilder.UpdateData(
                table: "RoleMenus",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 29, 16, 23, 13, 21, DateTimeKind.Local).AddTicks(4721));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 29, 16, 23, 13, 21, DateTimeKind.Local).AddTicks(3178));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 29, 16, 23, 13, 21, DateTimeKind.Local).AddTicks(3184));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 29, 16, 23, 13, 21, DateTimeKind.Local).AddTicks(3186));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 29, 16, 23, 13, 21, DateTimeKind.Local).AddTicks(3188));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 29, 16, 23, 13, 21, DateTimeKind.Local).AddTicks(3471));
        }
    }
}
