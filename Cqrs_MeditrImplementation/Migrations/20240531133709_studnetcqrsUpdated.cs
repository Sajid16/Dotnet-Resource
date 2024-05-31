using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cqrs_MediatR_Implementation.Migrations
{
    public partial class studnetcqrsUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsUpdated",
                table: "StudentsCqrs",
                type: "bit",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsUpdated",
                table: "StudentsCqrs");
        }
    }
}
