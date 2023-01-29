using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class TreeMigration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaxFruitliness",
                table: "TreeDbs");

            migrationBuilder.DropColumn(
                name: "MaxHeight",
                table: "TreeDbs");

            migrationBuilder.DropColumn(
                name: "MaxSquare",
                table: "TreeDbs");

            migrationBuilder.RenameColumn(
                name: "TypeId",
                table: "TreeDbs",
                newName: "TreeSortId");

            migrationBuilder.CreateIndex(
                name: "IX_TreeDbs_TreeSortId",
                table: "TreeDbs",
                column: "TreeSortId");

            migrationBuilder.AddForeignKey(
                name: "FK_TreeDbs_TreeSortDbs_TreeSortId",
                table: "TreeDbs",
                column: "TreeSortId",
                principalTable: "TreeSortDbs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TreeDbs_TreeSortDbs_TreeSortId",
                table: "TreeDbs");

            migrationBuilder.DropIndex(
                name: "IX_TreeDbs_TreeSortId",
                table: "TreeDbs");

            migrationBuilder.RenameColumn(
                name: "TreeSortId",
                table: "TreeDbs",
                newName: "TypeId");

            migrationBuilder.AddColumn<double>(
                name: "MaxFruitliness",
                table: "TreeDbs",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "MaxHeight",
                table: "TreeDbs",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "MaxSquare",
                table: "TreeDbs",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
