using Microsoft.EntityFrameworkCore;
using Pizzalizya.Data;
using Pizzalizya.Domain.Entities;
using Pizzalizya.Domain.Enums;
using Pizzalizya.Dto;
using Pizzalizya.Repositories.Interfaces;

namespace Pizzalizya.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        public PizzalizyaContext _context;
        public PedidoRepository(PizzalizyaContext context)
        {
            _context = context;
        }

        public async Task<bool> CriarPedidoAsync(Pedido pedido)
        {
            if (pedido is null)
                return false;

            await _context.Pedidos.AddAsync(pedido);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<PedidoDto>> ObterPedidos(Guid idEmpresa)
        {
            if (idEmpresa == Guid.Empty)
                return new List<PedidoDto>();

            var pedidos = await _context.Pedidos.Where(p => p.IdEmpresa == idEmpresa).Include(p => p.Cliente).Include(p => p.ItensPedido)
                .Select(p => new PedidoDto
                {
                    IdExterno = p.IdExterno,
                    DataPedido = p.DataPedido,
                    Cliente = new ClienteDto
                    {
                        IdExterno = p.Cliente.IdExterno,
                        Nome = p.Cliente.Nome,
                        Cpf = p.Cliente.Cpf
                    },
                    ValorPedido = p.ValorPedido,
                    MetodoPagamento = p.MetodoPagamento,
                    ItensPedido = p.ItensPedido.Select(p => new ItemDto
                    {
                        IdExterno = p.IdExterno,
                        NomeItem = p.NomeItem,
                        TipoItem = p.TipoItem,
                        ValorUnitario = p.ValorUnitario
                    }).ToList() ?? new List<ItemDto>(),
                    Delivery = p.Delivery,
                }).ToListAsync();

            return pedidos;


        }
    }
}
