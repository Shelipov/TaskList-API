using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskList.DAL.DataBase.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "NCHAR(255)", maxLength: 255, nullable: true),
                    LastName = table.Column<string>(type: "NCHAR(255)", maxLength: 255, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "TIMESTAMP(3)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "TIMESTAMP(3)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "UserCurrentTaskLists",
                columns: table => new
                {
                    UserCurrentTaskListId = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "TIMESTAMP(3)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "TIMESTAMP(3)", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCurrentTaskLists", x => x.UserCurrentTaskListId);
                    table.ForeignKey(
                        name: "FK_UserCurrentTaskLists_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CurrentTaskLists",
                columns: table => new
                {
                    CurrentTaskListId = table.Column<Guid>(type: "uuid", nullable: false),
                    CurrentTaskListName = table.Column<string>(type: "NCHAR(255)", maxLength: 255, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "TIMESTAMP(3)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "TIMESTAMP(3)", nullable: false),
                    UserCurrentTaskListId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrentTaskLists", x => x.CurrentTaskListId);
                    table.ForeignKey(
                        name: "FK_CurrentTaskLists_UserCurrentTaskLists_UserCurrentTaskListId",
                        column: x => x.UserCurrentTaskListId,
                        principalTable: "UserCurrentTaskLists",
                        principalColumn: "UserCurrentTaskListId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CurrentTasks",
                columns: table => new
                {
                    CurrentTaskId = table.Column<Guid>(type: "uuid", nullable: false),
                    CurrentTaskName = table.Column<string>(type: "NCHAR(500)", nullable: true),
                    Description = table.Column<string>(type: "NCHAR(500)", nullable: true),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    CurrentTaskListId = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "TIMESTAMP(3)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "TIMESTAMP(3)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrentTasks", x => x.CurrentTaskId);
                    table.ForeignKey(
                        name: "FK_CurrentTasks_CurrentTaskLists_CurrentTaskListId",
                        column: x => x.CurrentTaskListId,
                        principalTable: "CurrentTaskLists",
                        principalColumn: "CurrentTaskListId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CurrentTaskLists_UserCurrentTaskListId",
                table: "CurrentTaskLists",
                column: "UserCurrentTaskListId");

            migrationBuilder.CreateIndex(
                name: "IX_CurrentTasks_CurrentTaskListId",
                table: "CurrentTasks",
                column: "CurrentTaskListId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCurrentTaskLists_UserId",
                table: "UserCurrentTaskLists",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CurrentTasks");

            migrationBuilder.DropTable(
                name: "CurrentTaskLists");

            migrationBuilder.DropTable(
                name: "UserCurrentTaskLists");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
