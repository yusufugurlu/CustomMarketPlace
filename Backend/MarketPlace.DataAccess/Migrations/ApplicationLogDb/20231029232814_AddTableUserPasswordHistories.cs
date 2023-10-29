using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarketPlace.DataAccess.Migrations.ApplicationLogDb
{
    /// <inheritdoc />
    public partial class AddTableUserPasswordHistories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LoginType",
                table: "UserPasswordHistories");

            migrationBuilder.RenameColumn(
                name: "IsSuccess",
                table: "UserPasswordHistories",
                newName: "IsUsed");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "UserPasswordHistories",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletedDate",
                table: "UserPasswordHistories",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "UserPasswordHistories",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpiryDate",
                table: "UserPasswordHistories",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "GuidKey",
                table: "UserPasswordHistories",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExpiryDate",
                table: "UserPasswordHistories");

            migrationBuilder.DropColumn(
                name: "GuidKey",
                table: "UserPasswordHistories");

            migrationBuilder.RenameColumn(
                name: "IsUsed",
                table: "UserPasswordHistories",
                newName: "IsSuccess");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "UserPasswordHistories",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletedDate",
                table: "UserPasswordHistories",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "UserPasswordHistories",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AddColumn<int>(
                name: "LoginType",
                table: "UserPasswordHistories",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
