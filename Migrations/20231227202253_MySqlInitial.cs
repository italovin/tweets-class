using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace blazortest.Migrations
{
    /// <inheritdoc />
    public partial class MySqlInitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccessKeys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    HashString = table.Column<string>(type: "TEXT", nullable: false),
                    Revoked = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessKeys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Phrases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Text = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phrases", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Labelings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Label = table.Column<int>(type: "INTEGER", nullable: false),
                    PhraseId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Labelings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Labelings_Phrases_PhraseId",
                        column: x => x.PhraseId,
                        principalTable: "Phrases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Labelings_PhraseId",
                table: "Labelings",
                column: "PhraseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccessKeys");

            migrationBuilder.DropTable(
                name: "Labelings");

            migrationBuilder.DropTable(
                name: "Phrases");
        }
    }
}
