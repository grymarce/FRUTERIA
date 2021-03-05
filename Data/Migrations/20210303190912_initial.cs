using Microsoft.EntityFrameworkCore.Migrations;

namespace FRUTERIA.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FRUTERIA_MAR",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Producto = table.Column<string>(nullable: true),
                    Categoria = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true),
                    Precio = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    URL_IMAGEN = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FRUTERIA_MAR", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FRUTERIA_MAR");
        }
    }
}
