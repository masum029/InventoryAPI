using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepoPatternAPI.Migrations
{
    /// <inheritdoc />
    public partial class modelchangesinmenu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SubMenuId",
                table: "SubMenus",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "MenuId",
                table: "Menus",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "SubMenus",
                newName: "SubMenuId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Menus",
                newName: "MenuId");
        }
    }
}
