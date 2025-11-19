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

        public async Task<PedidoDto> ObterPedido(Guid idPedido)
        {
            var pedido = await _context.Pedidos.AsNoTracking().AsSplitQuery().Where(x => x.IdExterno == idPedido).Include(p => p.Cliente).Include(p => p.ItensPedido)
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
                    ItensPedido = p.ItensPedido
                        .Select(i => new ItemDto
                        {
                            IdExterno = i.IdExterno,
                            NomeItem = i.NomeItem,
                            TipoItem = i.TipoItem,
                            ValorUnitario = i.ValorUnitario
                        })
                        .ToList(),
                    Delivery = p.Delivery,
                })
                .FirstOrDefaultAsync();

            return pedido;
        }


        public async Task<Pedido> ObterPedidoInterno(Guid idPedido)
        {
            var pedidoInterno = await _context.Pedidos.Where(x => x.IdExterno == idPedido).FirstOrDefaultAsync();

            return pedidoInterno;
        }

        public async Task<IEnumerable<PedidoDto>> ObterPedidos(Guid idEmpresa)
        {
            if (idEmpresa == Guid.Empty)
                return new List<PedidoDto>();

            var pedidos = await _context.Pedidos.AsNoTracking().AsSplitQuery().Where(p => p.IdEmpresa == idEmpresa).Include(p => p.Cliente).Include(p => p.ItensPedido)
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

        public async Task<bool> ExcluirPedido(Guid idPedido)
        {
            var pedido = await _context.Pedidos.Where(x => x.IdExterno == idPedido).FirstOrDefaultAsync(); 

            if (pedido == null)
                return false;

            _context.Pedidos.Remove(pedido);
            
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
