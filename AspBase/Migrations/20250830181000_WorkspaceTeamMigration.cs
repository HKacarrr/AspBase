using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AspBase.Migrations
{
    /// <inheritdoc />
    public partial class WorkspaceTeamMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "a_roles",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "03e9e448-0dea-4bf1-a886-e06c3a776b01");

            migrationBuilder.DeleteData(
                schema: "a_roles",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3e184d77-6d9d-4fc2-b7fa-c2aa29ed712f");

            migrationBuilder.DeleteData(
                schema: "a_roles",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5437abaf-6840-4a6c-b33b-8b4da174ce86");

            migrationBuilder.DeleteData(
                schema: "a_roles",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9466a2f2-aacc-4efd-a546-02a78023d1f3");

            migrationBuilder.DeleteData(
                schema: "a_roles",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a6cb2441-a0b9-42f9-96bf-dc408cdb5c4d");

            migrationBuilder.DeleteData(
                schema: "a_roles",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d439b4f9-408d-4171-ba7a-7f699e02acfa");

            migrationBuilder.EnsureSchema(
                name: "t_team");

            migrationBuilder.EnsureSchema(
                name: "w_workspace");

            migrationBuilder.CreateTable(
                name: "team_invites",
                schema: "t_team",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TeamId = table.Column<Guid>(type: "uuid", nullable: false),
                    TeamRoleId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_team_invites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_team_invites_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "a_user",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "team_member_roles",
                schema: "t_team",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Alias = table.Column<string>(type: "text", nullable: true),
                    Degree = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TeamId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_team_member_roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "team_members",
                schema: "t_team",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TeamId = table.Column<Guid>(type: "uuid", nullable: false),
                    TeamRoleId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_team_members", x => x.Id);
                    table.ForeignKey(
                        name: "FK_team_members_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "a_user",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_team_members_team_member_roles_TeamRoleId",
                        column: x => x.TeamRoleId,
                        principalSchema: "t_team",
                        principalTable: "team_member_roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "teams",
                schema: "t_team",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Logo = table.Column<string>(type: "text", nullable: true),
                    Uuid = table.Column<string>(type: "text", nullable: true),
                    CreatedUserId = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    WorkspaceId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_teams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_teams_AspNetUsers_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalSchema: "a_user",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "workspace_invites",
                schema: "w_workspace",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Phone = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Uuid = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    WorkspaceId = table.Column<Guid>(type: "uuid", nullable: false),
                    WorkspaceMemberRoleId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_workspace_invites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_workspace_invites_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "a_user",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "workspace_member_roles",
                schema: "w_workspace",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Alias = table.Column<string>(type: "text", nullable: true),
                    Degree = table.Column<int>(type: "integer", nullable: true),
                    WorkspaceMemberId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    WorkspaceId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_workspace_member_roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "workspace_members",
                schema: "w_workspace",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    WorkspaceId = table.Column<Guid>(type: "uuid", nullable: false),
                    WorkspaceMemberRoleId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_workspace_members", x => x.Id);
                    table.ForeignKey(
                        name: "FK_workspace_members_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "a_user",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_workspace_members_workspace_member_roles_WorkspaceMemberRol~",
                        column: x => x.WorkspaceMemberRoleId,
                        principalSchema: "w_workspace",
                        principalTable: "workspace_member_roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "workspaces",
                schema: "w_workspace",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Logo = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Phone = table.Column<string>(type: "text", nullable: true),
                    Website = table.Column<string>(type: "text", nullable: true),
                    Enable = table.Column<bool>(type: "boolean", nullable: true),
                    CreatedUserId = table.Column<string>(type: "text", nullable: true),
                    WorkspaceInviteId = table.Column<Guid>(type: "uuid", nullable: true),
                    WorkspaceMemberId = table.Column<Guid>(type: "uuid", nullable: true),
                    WorkspaceMemberRoleId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_workspaces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_workspaces_AspNetUsers_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalSchema: "a_user",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_workspaces_workspace_invites_WorkspaceInviteId",
                        column: x => x.WorkspaceInviteId,
                        principalSchema: "w_workspace",
                        principalTable: "workspace_invites",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_workspaces_workspace_member_roles_WorkspaceMemberRoleId",
                        column: x => x.WorkspaceMemberRoleId,
                        principalSchema: "w_workspace",
                        principalTable: "workspace_member_roles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_workspaces_workspace_members_WorkspaceMemberId",
                        column: x => x.WorkspaceMemberId,
                        principalSchema: "w_workspace",
                        principalTable: "workspace_members",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                schema: "a_roles",
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0b22a6f8-4180-4364-8f1d-aa0722fa550a", null, "Workspace Leader", "WORKSPACE_LEADER" },
                    { "621e29a5-59e5-414c-8a1f-e07f2f5e5f22", null, "Team Leader", "TEAM_LEADER" },
                    { "65768c9c-be6b-434c-becf-653f9047fd58", null, "User", "USER" },
                    { "7e23187e-5f80-4282-beb8-fb8426966bd4", null, "Admin", "ADMIN" },
                    { "d2cd27d5-24e2-493f-ad30-2de18d00ef0d", null, "Workspace Member", "WORKSPACE_MEMBER" },
                    { "e2c48687-011e-4e66-9705-ad26d51e4ccb", null, "Team Member", "TEAM_MEMBER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_team_invites_TeamId",
                schema: "t_team",
                table: "team_invites",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_team_invites_TeamRoleId",
                schema: "t_team",
                table: "team_invites",
                column: "TeamRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_team_invites_UserId",
                schema: "t_team",
                table: "team_invites",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_team_member_roles_TeamId",
                schema: "t_team",
                table: "team_member_roles",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_team_members_TeamId",
                schema: "t_team",
                table: "team_members",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_team_members_TeamRoleId",
                schema: "t_team",
                table: "team_members",
                column: "TeamRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_team_members_UserId",
                schema: "t_team",
                table: "team_members",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_teams_CreatedUserId",
                schema: "t_team",
                table: "teams",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_teams_WorkspaceId",
                schema: "t_team",
                table: "teams",
                column: "WorkspaceId");

            migrationBuilder.CreateIndex(
                name: "IX_workspace_invites_UserId",
                schema: "w_workspace",
                table: "workspace_invites",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_workspace_invites_WorkspaceId",
                schema: "w_workspace",
                table: "workspace_invites",
                column: "WorkspaceId");

            migrationBuilder.CreateIndex(
                name: "IX_workspace_invites_WorkspaceMemberRoleId",
                schema: "w_workspace",
                table: "workspace_invites",
                column: "WorkspaceMemberRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_workspace_member_roles_WorkspaceId",
                schema: "w_workspace",
                table: "workspace_member_roles",
                column: "WorkspaceId");

            migrationBuilder.CreateIndex(
                name: "IX_workspace_member_roles_WorkspaceMemberId",
                schema: "w_workspace",
                table: "workspace_member_roles",
                column: "WorkspaceMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_workspace_members_UserId",
                schema: "w_workspace",
                table: "workspace_members",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_workspace_members_WorkspaceId",
                schema: "w_workspace",
                table: "workspace_members",
                column: "WorkspaceId");

            migrationBuilder.CreateIndex(
                name: "IX_workspace_members_WorkspaceMemberRoleId",
                schema: "w_workspace",
                table: "workspace_members",
                column: "WorkspaceMemberRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_workspaces_CreatedUserId",
                schema: "w_workspace",
                table: "workspaces",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_workspaces_WorkspaceInviteId",
                schema: "w_workspace",
                table: "workspaces",
                column: "WorkspaceInviteId");

            migrationBuilder.CreateIndex(
                name: "IX_workspaces_WorkspaceMemberId",
                schema: "w_workspace",
                table: "workspaces",
                column: "WorkspaceMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_workspaces_WorkspaceMemberRoleId",
                schema: "w_workspace",
                table: "workspaces",
                column: "WorkspaceMemberRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_team_invites_team_member_roles_TeamRoleId",
                schema: "t_team",
                table: "team_invites",
                column: "TeamRoleId",
                principalSchema: "t_team",
                principalTable: "team_member_roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_team_invites_teams_TeamId",
                schema: "t_team",
                table: "team_invites",
                column: "TeamId",
                principalSchema: "t_team",
                principalTable: "teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_team_member_roles_teams_TeamId",
                schema: "t_team",
                table: "team_member_roles",
                column: "TeamId",
                principalSchema: "t_team",
                principalTable: "teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_team_members_teams_TeamId",
                schema: "t_team",
                table: "team_members",
                column: "TeamId",
                principalSchema: "t_team",
                principalTable: "teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_teams_workspaces_WorkspaceId",
                schema: "t_team",
                table: "teams",
                column: "WorkspaceId",
                principalSchema: "w_workspace",
                principalTable: "workspaces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_workspace_invites_workspace_member_roles_WorkspaceMemberRol~",
                schema: "w_workspace",
                table: "workspace_invites",
                column: "WorkspaceMemberRoleId",
                principalSchema: "w_workspace",
                principalTable: "workspace_member_roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_workspace_invites_workspaces_WorkspaceId",
                schema: "w_workspace",
                table: "workspace_invites",
                column: "WorkspaceId",
                principalSchema: "w_workspace",
                principalTable: "workspaces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_workspace_member_roles_workspace_members_WorkspaceMemberId",
                schema: "w_workspace",
                table: "workspace_member_roles",
                column: "WorkspaceMemberId",
                principalSchema: "w_workspace",
                principalTable: "workspace_members",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_workspace_member_roles_workspaces_WorkspaceId",
                schema: "w_workspace",
                table: "workspace_member_roles",
                column: "WorkspaceId",
                principalSchema: "w_workspace",
                principalTable: "workspaces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_workspace_members_workspaces_WorkspaceId",
                schema: "w_workspace",
                table: "workspace_members",
                column: "WorkspaceId",
                principalSchema: "w_workspace",
                principalTable: "workspaces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_workspace_invites_workspaces_WorkspaceId",
                schema: "w_workspace",
                table: "workspace_invites");

            migrationBuilder.DropForeignKey(
                name: "FK_workspace_member_roles_workspaces_WorkspaceId",
                schema: "w_workspace",
                table: "workspace_member_roles");

            migrationBuilder.DropForeignKey(
                name: "FK_workspace_members_workspaces_WorkspaceId",
                schema: "w_workspace",
                table: "workspace_members");

            migrationBuilder.DropForeignKey(
                name: "FK_workspace_members_workspace_member_roles_WorkspaceMemberRol~",
                schema: "w_workspace",
                table: "workspace_members");

            migrationBuilder.DropTable(
                name: "team_invites",
                schema: "t_team");

            migrationBuilder.DropTable(
                name: "team_members",
                schema: "t_team");

            migrationBuilder.DropTable(
                name: "team_member_roles",
                schema: "t_team");

            migrationBuilder.DropTable(
                name: "teams",
                schema: "t_team");

            migrationBuilder.DropTable(
                name: "workspaces",
                schema: "w_workspace");

            migrationBuilder.DropTable(
                name: "workspace_invites",
                schema: "w_workspace");

            migrationBuilder.DropTable(
                name: "workspace_member_roles",
                schema: "w_workspace");

            migrationBuilder.DropTable(
                name: "workspace_members",
                schema: "w_workspace");

            migrationBuilder.DeleteData(
                schema: "a_roles",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0b22a6f8-4180-4364-8f1d-aa0722fa550a");

            migrationBuilder.DeleteData(
                schema: "a_roles",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "621e29a5-59e5-414c-8a1f-e07f2f5e5f22");

            migrationBuilder.DeleteData(
                schema: "a_roles",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "65768c9c-be6b-434c-becf-653f9047fd58");

            migrationBuilder.DeleteData(
                schema: "a_roles",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7e23187e-5f80-4282-beb8-fb8426966bd4");

            migrationBuilder.DeleteData(
                schema: "a_roles",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d2cd27d5-24e2-493f-ad30-2de18d00ef0d");

            migrationBuilder.DeleteData(
                schema: "a_roles",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e2c48687-011e-4e66-9705-ad26d51e4ccb");

            migrationBuilder.InsertData(
                schema: "a_roles",
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "03e9e448-0dea-4bf1-a886-e06c3a776b01", null, "Admin", "ADMIN" },
                    { "3e184d77-6d9d-4fc2-b7fa-c2aa29ed712f", null, "Team Member", "TEAM_MEMBER" },
                    { "5437abaf-6840-4a6c-b33b-8b4da174ce86", null, "User", "USER" },
                    { "9466a2f2-aacc-4efd-a546-02a78023d1f3", null, "Team Leader", "TEAM_LEADER" },
                    { "a6cb2441-a0b9-42f9-96bf-dc408cdb5c4d", null, "Workspace Leader", "WORKSPACE_LEADER" },
                    { "d439b4f9-408d-4171-ba7a-7f699e02acfa", null, "Workspace Member", "WORKSPACE_MEMBER" }
                });
        }
    }
}
