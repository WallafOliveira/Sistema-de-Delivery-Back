using Sistema_de_delivery_back.Domain.Entities;
using Sistema_de_delivery_back.Domain.Interfaces;
using Sistema_de_delivery_back.Infrastructure.Data;

namespace Sistema_de_delivery_back.Infrastructure.Repositories
{
    public class ProdutoRepository : IProdutoRepository

    {
            private readonly ApplicationDbContext _context;

            public ProdutoRepository(ApplicationDbContext context)
            {
                _context = context;
            }

            public void Adicionar(Produto produto)
            {
                _context.Produtos.Add(produto);
                _context.SaveChanges(); // Síncrono, conforme a interface
            }

            public void Atualizar(Produto produto)
            {
                _context.Produtos.Update(produto);
                _context.SaveChanges();
            }

            public Produto ObterPorId(Guid id)
            {
                return _context.Produtos.FirstOrDefault(p => p.Id == id);
            }

            public IEnumerable<Produto> ObterTodos()
            {
                return _context.Produtos.ToList();
            }

            public IEnumerable<Produto> ObterPorRestauranteId(Guid restauranteId)
            {
                return _context.Produtos
                               .Where(p => p.RestauranteId == restauranteId)
                               .ToList();
            }
        }
    
}
