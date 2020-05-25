using Microsoft.EntityFrameworkCore.Migrations;

namespace PatientAngularCore.Migrations
{
    public partial class PatientDiseaseRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "deseaseIdID",
                table: "PatientModels",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PatientModels_deseaseIdID",
                table: "PatientModels",
                column: "deseaseIdID");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientModels_Diseases_deseaseIdID",
                table: "PatientModels",
                column: "deseaseIdID",
                principalTable: "Diseases",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientModels_Diseases_deseaseIdID",
                table: "PatientModels");

            migrationBuilder.DropIndex(
                name: "IX_PatientModels_deseaseIdID",
                table: "PatientModels");

            migrationBuilder.DropColumn(
                name: "deseaseIdID",
                table: "PatientModels");
        }
    }
}
