using Microsoft.EntityFrameworkCore.Migrations;

namespace PatientAngularCore.Migrations
{
    public partial class PatientQueries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PatientQueries",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Query = table.Column<string>(nullable: true),
                    diseaseID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientQueries", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PatientQueries_Diseases_diseaseID",
                        column: x => x.diseaseID,
                        principalTable: "Diseases",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PatientQueries_diseaseID",
                table: "PatientQueries",
                column: "diseaseID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PatientQueries");
        }
    }
}
