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
                name: "CurrentTaskLists",
                columns: table => new
                {
                    CurrentTaskListId = table.Column<Guid>(type: "uuid", nullable: false),
                    CurrentTaskListName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserCurrentTaskListId = table.Column<Guid>(type: "uuid", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrentTaskLists", x => x.CurrentTaskListId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    LastName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "CurrentTasks",
                columns: table => new
                {
                    CurrentTaskId = table.Column<Guid>(type: "uuid", nullable: false),
                    CurrentTaskName = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    IsCompleted = table.Column<int>(type: "integer", nullable: false),
                    CurrentTaskListId = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "UserCurrentTaskLists",
                columns: table => new
                {
                    UserCurrentTaskListId = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
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
                name: "CurrentTaskListUserCurrentTaskList",
                columns: table => new
                {
                    CurrentTaskListsCurrentTaskListId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserCurrentTaskListsUserCurrentTaskListId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrentTaskListUserCurrentTaskList", x => new { x.CurrentTaskListsCurrentTaskListId, x.UserCurrentTaskListsUserCurrentTaskListId });
                    table.ForeignKey(
                        name: "FK_CurrentTaskListUserCurrentTaskList_CurrentTaskLists_Current~",
                        column: x => x.CurrentTaskListsCurrentTaskListId,
                        principalTable: "CurrentTaskLists",
                        principalColumn: "CurrentTaskListId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CurrentTaskListUserCurrentTaskList_UserCurrentTaskLists_Use~",
                        column: x => x.UserCurrentTaskListsUserCurrentTaskListId,
                        principalTable: "UserCurrentTaskLists",
                        principalColumn: "UserCurrentTaskListId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CurrentTaskListUserCurrentTaskList_UserCurrentTaskListsUser~",
                table: "CurrentTaskListUserCurrentTaskList",
                column: "UserCurrentTaskListsUserCurrentTaskListId");

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
                name: "CurrentTaskListUserCurrentTaskList");

            migrationBuilder.DropTable(
                name: "CurrentTasks");

            migrationBuilder.DropTable(
                name: "UserCurrentTaskLists");

            migrationBuilder.DropTable(
                name: "CurrentTaskLists");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
