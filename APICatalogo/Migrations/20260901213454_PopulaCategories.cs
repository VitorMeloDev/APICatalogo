using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APICatalogo.Migrations
{
    /// <inheritdoc />
    public partial class PopulaCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Categories (Name, ImageUrl) VALUES ('Bebidas', 'bebidas.png')");
            migrationBuilder.Sql("INSERT INTO Categories (Name, ImageUrl) VALUES ('Lanches', 'lanches.png')");
            migrationBuilder.Sql("INSERT INTO Categories (Name, ImageUrl) VALUES ('Sobremesas', 'sobremesas.png')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete from Categories");
        }
    }
}
