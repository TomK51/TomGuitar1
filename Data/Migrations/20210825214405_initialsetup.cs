using Microsoft.EntityFrameworkCore.Migrations;

namespace TomGuitar1.Data.Migrations
{
    public partial class initialsetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Guitar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GuitarType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GuitarName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GuitarCost = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GuitarPic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InsuredValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guitar", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Guitar");
        }
    }
}
