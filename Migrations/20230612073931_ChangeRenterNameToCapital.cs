using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentalApp.Migrations
{
    /// <inheritdoc />
    public partial class ChangeRenterNameToCapital : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_renters",
                table: "renters");

            migrationBuilder.RenameTable(
                name: "renters",
                newName: "Renters");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Renters",
                table: "Renters",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Renters",
                table: "Renters");

            migrationBuilder.RenameTable(
                name: "Renters",
                newName: "renters");

            migrationBuilder.AddPrimaryKey(
                name: "PK_renters",
                table: "renters",
                column: "Id");
        }
    }
}
