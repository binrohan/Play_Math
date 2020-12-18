using Microsoft.EntityFrameworkCore.Migrations;

namespace PlayMath.API.Migrations
{
    public partial class NewColumnInANSWER : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Answers",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Answers");
        }
    }
}
