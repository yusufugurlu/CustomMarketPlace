using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarketPlace.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class WorkPlaceCompanyAddRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "WorkPlaces",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 18, 19, 59, 13, 44, DateTimeKind.Local).AddTicks(3362));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 18, 19, 59, 13, 44, DateTimeKind.Local).AddTicks(5510));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 18, 19, 59, 13, 44, DateTimeKind.Local).AddTicks(5514));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 18, 19, 59, 13, 44, DateTimeKind.Local).AddTicks(5517));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 18, 19, 59, 13, 44, DateTimeKind.Local).AddTicks(4196));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 18, 19, 59, 13, 44, DateTimeKind.Local).AddTicks(4919));

            migrationBuilder.CreateIndex(
                name: "IX_WorkPlaces_CompanyId",
                table: "WorkPlaces",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkPlaces_Companies_CompanyId",
                table: "WorkPlaces",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkPlaces_Companies_CompanyId",
                table: "WorkPlaces");

            migrationBuilder.DropIndex(
                name: "IX_WorkPlaces_CompanyId",
                table: "WorkPlaces");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "WorkPlaces");

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 18, 19, 54, 24, 510, DateTimeKind.Local).AddTicks(1079));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 18, 19, 54, 24, 510, DateTimeKind.Local).AddTicks(2818));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 18, 19, 54, 24, 510, DateTimeKind.Local).AddTicks(2824));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 18, 19, 54, 24, 510, DateTimeKind.Local).AddTicks(2826));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 18, 19, 54, 24, 510, DateTimeKind.Local).AddTicks(1789));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 18, 19, 54, 24, 510, DateTimeKind.Local).AddTicks(2296));
        }
    }
}
