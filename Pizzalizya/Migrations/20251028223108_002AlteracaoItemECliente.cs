using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pizzalizya.Migrations
{
    /// <inheritdoc />
    public partial class _002AlteracaoItemECliente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Itens_Pedidos_PedidoId",
                table: "Itens");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Clientes_ClienteId",
                table: "Pedidos");

            migrationBuilder.DropIndex(
                name: "IX_Pedidos_ClienteId",
                table: "Pedidos");

            migrationBuilder.DropIndex(
                name: "IX_Itens_PedidoId",
                table: "Itens");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "PedidoId",
                table: "Itens");

            migrationBuilder.CreateIndex(
                name: "IX_Itens_IdPai",
                table: "Itens",
                column: "IdPai");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_IdPai",
                table: "Clientes",
                column: "IdPai",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Pedidos_IdPai",
                table: "Clientes",
                column: "IdPai",
                principalTable: "Pedidos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Itens_Pedidos_IdPai",
                table: "Itens",
                column: "IdPai",
                principalTable: "Pedidos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Pedidos_IdPai",
                table: "Clientes");

            migrationBuilder.DropForeignKey(
                name: "FK_Itens_Pedidos_IdPai",
                table: "Itens");

            migrationBuilder.DropIndex(
                name: "IX_Itens_IdPai",
                table: "Itens");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_IdPai",
                table: "Clientes");

            migrationBuilder.AddColumn<long>(
                name: "ClienteId",
                table: "Pedidos",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "PedidoId",
                table: "Itens",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_ClienteId",
                table: "Pedidos",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Itens_PedidoId",
                table: "Itens",
                column: "PedidoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Itens_Pedidos_PedidoId",
                table: "Itens",
                column: "PedidoId",
                principalTable: "Pedidos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Clientes_ClienteId",
                table: "Pedidos",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
