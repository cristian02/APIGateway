using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GlobalErrorApi.Migrations
{
    public partial class AddEnableAttribute : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Drivers",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<bool>(
                name: "enabled",
                table: "Drivers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_Name",
                table: "Drivers",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Drivers_Name",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "enabled",
                table: "Drivers");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Drivers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
