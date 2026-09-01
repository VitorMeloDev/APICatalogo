using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APICatalogo.Migrations
{
    /// <inheritdoc />
    public partial class PopulaProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Products (Name, Description, Price, ImageUrl, Stock, DateCreated, CategoryId) " +
                "VALUES ('Coca-Cola', 'Refrigerante de cola', 5.99, 'coca-cola.png', 100, NOW(), 1)");
            migrationBuilder.Sql("INSERT INTO Products (Name, Description, Price, ImageUrl, Stock, DateCreated, CategoryId) " +
                "VALUES ('Hambúrguer', 'Hambúrguer artesanal', 12.99, 'hamburguer.png', 50, NOW(), 2)");
            migrationBuilder.Sql("INSERT INTO Products (Name, Description, Price, ImageUrl, Stock, DateCreated, CategoryId) " +
                "VALUES ('Sobremesa', 'Sobremesa deliciosa', 8.99, 'sobremesa.png', 30, NOW(), 3)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Products");
        }
    }
}
