using Sistema_de_delivery_back.Domain.Entities;
using Sistema_de_delivery_back.Domain.Interfaces;
using Sistema_de_delivery_back.Infrastructure.Data;

namespace Sistema_de_delivery_back.Infrastructure.Repositories;

public class RestauranteRepository : IRestauranteRepository
{
    private readonly ApplicationDbContext _context;

    public RestauranteRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public void Adicionar(Restaurante restaurante)
    {
        _context.Restaurantes.Add(restaurante);
        _context.SaveChanges();
    }

    public void Atualizar(Restaurante restaurante)
    {
        _context.Restaurantes.Update(restaurante);
        _context.SaveChanges();
    }

    public List<Restaurante> ListarTodos()
    {
        return _context.Restaurantes.ToList();
    }

    public List<Restaurante> ListarAbertos()
    {
        return _context.Restaurantes.Where(r => r.EstaAberto).ToList();
    }

    public Restaurante? BuscarPorId(Guid id)
    {
        return _context.Restaurantes.Find(id);
    }
}
