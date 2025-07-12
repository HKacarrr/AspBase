using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AspBase.Migrations
{
    /// <inheritdoc />
    public partial class AuthRoleMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
