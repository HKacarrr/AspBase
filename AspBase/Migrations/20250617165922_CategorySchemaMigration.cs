using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspBase.Migrations
{
    /// <inheritdoc />
    public partial class CategorySchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

            migrationBuilder.EnsureSchema(
                name: "c_category");

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "category",
                newSchema: "c_category");

            migrationBuilder.AddPrimaryKey(
                name: "PK_category",
                schema: "c_category",
                table: "category",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_category",
                schema: "c_category",
                table: "category");

            migrationBuilder.RenameTable(
                name: "category",
                schema: "c_category",
                newName: "Category");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "Id");
        }
    }
}
