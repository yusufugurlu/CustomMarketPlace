using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MarketPlace.DataAccess.Migrations.ApplicationLogDb
{
    /// <inheritdoc />
    public partial class AddColumnUserIdInQueue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QueueHistories_Queues_QueueId",
                table: "QueueHistories");

            migrationBuilder.DropTable(
                name: "Queues");

            migrationBuilder.CreateTable(
                name: "CustomQueues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    IntegrationType = table.Column<int>(type: "integer", nullable: false),
                    QueueActionType = table.Column<int>(type: "integer", nullable: false),
                    QueueProcessType = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomQueues", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_QueueHistories_CustomQueues_QueueId",
                table: "QueueHistories",
                column: "QueueId",
                principalTable: "CustomQueues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QueueHistories_CustomQueues_QueueId",
                table: "QueueHistories");

            migrationBuilder.DropTable(
                name: "CustomQueues");

            migrationBuilder.CreateTable(
                name: "Queues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IntegrationType = table.Column<int>(type: "integer", nullable: false),
                    QueueActionType = table.Column<int>(type: "integer", nullable: false),
                    QueueProcessType = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Queues", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_QueueHistories_Queues_QueueId",
                table: "QueueHistories",
                column: "QueueId",
                principalTable: "Queues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
