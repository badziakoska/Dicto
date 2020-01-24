using Microsoft.EntityFrameworkCore.Migrations;

namespace Dicto.Migrations
{
    public partial class PoprawaModeluDziennika : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Rok",
                table: "Dzienniki",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Rok",
                table: "Dzienniki",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
