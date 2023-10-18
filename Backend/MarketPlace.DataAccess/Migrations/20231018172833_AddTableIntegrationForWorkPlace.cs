using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MarketPlace.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddTableIntegrationForWorkPlace : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IntegrationForWorkPlaces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    WorkPlaceId = table.Column<int>(type: "integer", nullable: false),
                    IntegrationType = table.Column<int>(type: "integer", nullable: false),
                    ApiKey = table.Column<string>(type: "text", nullable: false),
                    ApiSecret = table.Column<string>(type: "text", nullable: false),
                    IdForApi = table.Column<string>(type: "text", nullable: true),
                    CreatedUserId = table.Column<int>(type: "integer", nullable: false),
                    UpdatedUserId = table.Column<int>(type: "integer", nullable: false),
                    DeletedUserId = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IntegrationForWorkPlaces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IntegrationForWorkPlaces_WorkPlaces_WorkPlaceId",
                        column: x => x.WorkPlaceId,
                        principalTable: "WorkPlaces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 18, 20, 28, 33, 487, DateTimeKind.Local).AddTicks(8347));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 18, 20, 28, 33, 488, DateTimeKind.Local).AddTicks(1417));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 18, 20, 28, 33, 488, DateTimeKind.Local).AddTicks(1424));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 18, 20, 28, 33, 488, DateTimeKind.Local).AddTicks(1427));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 18, 20, 28, 33, 487, DateTimeKind.Local).AddTicks(9747));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 18, 20, 28, 33, 488, DateTimeKind.Local).AddTicks(603));

            migrationBuilder.CreateIndex(
                name: "IX_IntegrationForWorkPlaces_WorkPlaceId",
                table: "IntegrationForWorkPlaces",
                column: "WorkPlaceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IntegrationForWorkPlaces");

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
        }
    }
}
