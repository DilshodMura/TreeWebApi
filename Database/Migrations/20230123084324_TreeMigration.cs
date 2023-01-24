using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class TreeMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FarmAreaDbs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Capacity = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FarmAreaDbs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TreeDbs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaxHeight = table.Column<double>(type: "float", nullable: false),
                    MaxSquare = table.Column<double>(type: "float", nullable: false),
                    MaxFruitliness = table.Column<double>(type: "float", nullable: false),
                    SortName = table.Column<int>(type: "int", nullable: false),
                    TreeTypes = table.Column<int>(type: "int", nullable: false),
                    AreaId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreeDbs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TreeDbs_FarmAreaDbs_AreaId",
                        column: x => x.AreaId,
                        principalTable: "FarmAreaDbs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TreeDbs_AreaId",
                table: "TreeDbs",
                column: "AreaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TreeDbs");

            migrationBuilder.DropTable(
                name: "FarmAreaDbs");
        }
    }
}
