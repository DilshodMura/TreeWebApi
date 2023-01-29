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
                name: "TreeTypesDb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreeTypesDb", x => x.Id);
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
                    SortId = table.Column<int>(type: "int", nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    AreaId = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "TreeSortDbs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaxHeight = table.Column<double>(type: "float", nullable: false),
                    MaxSquare = table.Column<double>(type: "float", nullable: false),
                    MaxFruitliness = table.Column<double>(type: "float", nullable: false),
                    TreeTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreeSortDbs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TreeSortDbs_TreeTypesDb_TreeTypeId",
                        column: x => x.TreeTypeId,
                        principalTable: "TreeTypesDb",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TreeDbs_AreaId",
                table: "TreeDbs",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_TreeSortDbs_TreeTypeId",
                table: "TreeSortDbs",
                column: "TreeTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TreeDbs");

            migrationBuilder.DropTable(
                name: "TreeSortDbs");

            migrationBuilder.DropTable(
                name: "FarmAreaDbs");

            migrationBuilder.DropTable(
                name: "TreeTypesDb");
        }
    }
}
