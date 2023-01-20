using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Radar2._0G6webAPI.Migrations
{
    /// <inheritdoc />
    public partial class CorrecaoNomeTabelas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PedidoProduto_Pedidos_PedidoId1",
                table: "PedidoProduto");

            migrationBuilder.DropForeignKey(
                name: "FK_PedidoProduto_Produtos_ProdutoId1",
                table: "PedidoProduto");

            migrationBuilder.DropForeignKey(
                name: "FK_PosicoesProdutos_Campanha_CampanhaId1",
                table: "PosicoesProdutos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PedidoProduto",
                table: "PedidoProduto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Loja",
                table: "Loja");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Campanha",
                table: "Campanha");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Administrador",
                table: "Administrador");

            migrationBuilder.RenameTable(
                name: "PedidoProduto",
                newName: "PedidoProdutos");

            migrationBuilder.RenameTable(
                name: "Loja",
                newName: "Lojas");

            migrationBuilder.RenameTable(
                name: "Campanha",
                newName: "Campanhas");

            migrationBuilder.RenameTable(
                name: "Administrador",
                newName: "Administradores");

            migrationBuilder.RenameIndex(
                name: "IX_PedidoProduto_ProdutoId1",
                table: "PedidoProdutos",
                newName: "IX_PedidoProdutos_ProdutoId1");

            migrationBuilder.RenameIndex(
                name: "IX_PedidoProduto_PedidoId1",
                table: "PedidoProdutos",
                newName: "IX_PedidoProdutos_PedidoId1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PedidoProdutos",
                table: "PedidoProdutos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lojas",
                table: "Lojas",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Campanhas",
                table: "Campanhas",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Administradores",
                table: "Administradores",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PedidoProdutos_Pedidos_PedidoId1",
                table: "PedidoProdutos",
                column: "PedidoId1",
                principalTable: "Pedidos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PedidoProdutos_Produtos_ProdutoId1",
                table: "PedidoProdutos",
                column: "ProdutoId1",
                principalTable: "Produtos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PosicoesProdutos_Campanhas_CampanhaId1",
                table: "PosicoesProdutos",
                column: "CampanhaId1",
                principalTable: "Campanhas",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PedidoProdutos_Pedidos_PedidoId1",
                table: "PedidoProdutos");

            migrationBuilder.DropForeignKey(
                name: "FK_PedidoProdutos_Produtos_ProdutoId1",
                table: "PedidoProdutos");

            migrationBuilder.DropForeignKey(
                name: "FK_PosicoesProdutos_Campanhas_CampanhaId1",
                table: "PosicoesProdutos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PedidoProdutos",
                table: "PedidoProdutos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Lojas",
                table: "Lojas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Campanhas",
                table: "Campanhas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Administradores",
                table: "Administradores");

            migrationBuilder.RenameTable(
                name: "PedidoProdutos",
                newName: "PedidoProduto");

            migrationBuilder.RenameTable(
                name: "Lojas",
                newName: "Loja");

            migrationBuilder.RenameTable(
                name: "Campanhas",
                newName: "Campanha");

            migrationBuilder.RenameTable(
                name: "Administradores",
                newName: "Administrador");

            migrationBuilder.RenameIndex(
                name: "IX_PedidoProdutos_ProdutoId1",
                table: "PedidoProduto",
                newName: "IX_PedidoProduto_ProdutoId1");

            migrationBuilder.RenameIndex(
                name: "IX_PedidoProdutos_PedidoId1",
                table: "PedidoProduto",
                newName: "IX_PedidoProduto_PedidoId1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PedidoProduto",
                table: "PedidoProduto",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Loja",
                table: "Loja",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Campanha",
                table: "Campanha",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Administrador",
                table: "Administrador",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PedidoProduto_Pedidos_PedidoId1",
                table: "PedidoProduto",
                column: "PedidoId1",
                principalTable: "Pedidos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PedidoProduto_Produtos_ProdutoId1",
                table: "PedidoProduto",
                column: "ProdutoId1",
                principalTable: "Produtos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PosicoesProdutos_Campanha_CampanhaId1",
                table: "PosicoesProdutos",
                column: "CampanhaId1",
                principalTable: "Campanha",
                principalColumn: "Id");
        }
    }
}
