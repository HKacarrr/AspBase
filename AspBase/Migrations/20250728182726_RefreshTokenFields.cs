using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AspBase.Migrations
{
    /// <inheritdoc />
    public partial class RefreshTokenFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                schema: "a_user",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                schema: "a_user",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                schema: "a_roles",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                schema: "a_user",
                table: "AspNetUserTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_Profile_AspNetUsers_UserId",
                schema: "a_user",
                table: "Profile");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DeleteData(
                schema: "a_roles",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0666d7d2-5386-4c3c-bd1b-8288a8ebab26");

            migrationBuilder.DeleteData(
                schema: "a_roles",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0a3b9c68-ab30-461b-81c8-72fe7329ca08");

            migrationBuilder.DeleteData(
                schema: "a_roles",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "20d40440-de47-4572-9efa-1ac1076e6471");

            migrationBuilder.DeleteData(
                schema: "a_roles",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4b884690-c77a-489e-8c8b-6b05e44d78ea");

            migrationBuilder.DeleteData(
                schema: "a_roles",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5b12b22c-7e44-482f-87d5-30e7dde88e12");

            migrationBuilder.DeleteData(
                schema: "a_roles",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9629ccde-e05f-4710-ac81-343e6d9139e1");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                schema: "a_user",
                table: "AspNetUsers",
                type: "character varying(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NormalizedUserName",
                schema: "a_user",
                table: "AspNetUsers",
                type: "character varying(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NormalizedEmail",
                schema: "a_user",
                table: "AspNetUsers",
                type: "character varying(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "a_user",
                table: "AspNetUsers",
                type: "character varying(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                schema: "a_user",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenExpiryTime",
                schema: "a_user",
                table: "AspNetUsers",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "a_user",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "a_user",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                schema: "a_user",
                table: "AspNetUserClaims",
                column: "UserId",
                principalSchema: "a_user",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                schema: "a_user",
                table: "AspNetUserLogins",
                column: "UserId",
                principalSchema: "a_user",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                schema: "a_roles",
                table: "AspNetUserRoles",
                column: "UserId",
                principalSchema: "a_user",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                schema: "a_user",
                table: "AspNetUserTokens",
                column: "UserId",
                principalSchema: "a_user",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Profile_AspNetUsers_UserId",
                schema: "a_user",
                table: "Profile",
                column: "UserId",
                principalSchema: "a_user",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                schema: "a_user",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                schema: "a_user",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                schema: "a_roles",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                schema: "a_user",
                table: "AspNetUserTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_Profile_AspNetUsers_UserId",
                schema: "a_user",
                table: "Profile");

            migrationBuilder.DropIndex(
                name: "EmailIndex",
                schema: "a_user",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "UserNameIndex",
                schema: "a_user",
                table: "AspNetUsers");

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

            migrationBuilder.DropColumn(
                name: "RefreshToken",
                schema: "a_user",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RefreshTokenExpiryTime",
                schema: "a_user",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                schema: "a_user",
                table: "AspNetUsers",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NormalizedUserName",
                schema: "a_user",
                table: "AspNetUsers",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NormalizedEmail",
                schema: "a_user",
                table: "AspNetUsers",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "a_user",
                table: "AspNetUsers",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "a_roles",
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0666d7d2-5386-4c3c-bd1b-8288a8ebab26", null, "User", "USER" },
                    { "0a3b9c68-ab30-461b-81c8-72fe7329ca08", null, "Team Member", "TEAM_MEMBER" },
                    { "20d40440-de47-4572-9efa-1ac1076e6471", null, "Admin", "ADMIN" },
                    { "4b884690-c77a-489e-8c8b-6b05e44d78ea", null, "Workspace Leader", "WORKSPACE_LEADER" },
                    { "5b12b22c-7e44-482f-87d5-30e7dde88e12", null, "Team Leader", "TEAM_LEADER" },
                    { "9629ccde-e05f-4710-ac81-343e6d9139e1", null, "Workspace Member", "WORKSPACE_MEMBER" }
                });

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                schema: "a_user",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                schema: "a_user",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                schema: "a_roles",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                schema: "a_user",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Profile_AspNetUsers_UserId",
                schema: "a_user",
                table: "Profile",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
