using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Clearch.Infrastructure.Data.ReminderMigrations
{
    public partial class _001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReminderGroup",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(maxLength: 200, nullable: false),
                    Colour = table.Column<string>(nullable: true),
                    Owner = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReminderGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReminderItem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(maxLength: 200, nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    Done = table.Column<bool>(nullable: false),
                    ReminderDate = table.Column<DateTime>(nullable: true),
                    Priority = table.Column<int>(nullable: false),
                    ReminderGroupId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReminderItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReminderItem_ReminderGroup_ReminderGroupId",
                        column: x => x.ReminderGroupId,
                        principalTable: "ReminderGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReminderGroup_Owner",
                table: "ReminderGroup",
                column: "Owner");

            migrationBuilder.CreateIndex(
                name: "IX_ReminderItem_ReminderGroupId",
                table: "ReminderItem",
                column: "ReminderGroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReminderItem");

            migrationBuilder.DropTable(
                name: "ReminderGroup");
        }
    }
}
