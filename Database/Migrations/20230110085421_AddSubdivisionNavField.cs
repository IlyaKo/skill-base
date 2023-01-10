using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class AddSubdivisionNavField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubdivisionAreas_Subdivisions_SubdivisionId",
                table: "SubdivisionAreas");

            migrationBuilder.RenameColumn(
                name: "SubdivisionId",
                table: "SubdivisionAreas",
                newName: "SubdivisionsId");

            migrationBuilder.RenameIndex(
                name: "IX_SubdivisionAreas_SubdivisionId",
                table: "SubdivisionAreas",
                newName: "IX_SubdivisionAreas_SubdivisionsId");

            migrationBuilder.InsertData(
                table: "SkillAreas",
                columns: new[] { "Id", "Name", "Order" },
                values: new object[] { 1, "Common", 1 });

            migrationBuilder.AddForeignKey(
                name: "FK_SubdivisionAreas_Subdivisions_SubdivisionsId",
                table: "SubdivisionAreas",
                column: "SubdivisionsId",
                principalTable: "Subdivisions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubdivisionAreas_Subdivisions_SubdivisionsId",
                table: "SubdivisionAreas");

            migrationBuilder.DeleteData(
                table: "SkillAreas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.RenameColumn(
                name: "SubdivisionsId",
                table: "SubdivisionAreas",
                newName: "SubdivisionId");

            migrationBuilder.RenameIndex(
                name: "IX_SubdivisionAreas_SubdivisionsId",
                table: "SubdivisionAreas",
                newName: "IX_SubdivisionAreas_SubdivisionId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubdivisionAreas_Subdivisions_SubdivisionId",
                table: "SubdivisionAreas",
                column: "SubdivisionId",
                principalTable: "Subdivisions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
