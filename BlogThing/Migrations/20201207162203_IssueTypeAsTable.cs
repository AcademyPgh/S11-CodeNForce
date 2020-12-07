using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogThing.Migrations
{
    public partial class IssueTypeAsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IssueType",
                table: "Complaints");

            migrationBuilder.AddColumn<int>(
                name: "IssueTypeId",
                table: "Complaints",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "IssueType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IssueDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IssueType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Complaints_IssueTypeId",
                table: "Complaints",
                column: "IssueTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Complaints_IssueType_IssueTypeId",
                table: "Complaints",
                column: "IssueTypeId",
                principalTable: "IssueType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Complaints_IssueType_IssueTypeId",
                table: "Complaints");

            migrationBuilder.DropTable(
                name: "IssueType");

            migrationBuilder.DropIndex(
                name: "IX_Complaints_IssueTypeId",
                table: "Complaints");

            migrationBuilder.DropColumn(
                name: "IssueTypeId",
                table: "Complaints");

            migrationBuilder.AddColumn<int>(
                name: "IssueType",
                table: "Complaints",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
