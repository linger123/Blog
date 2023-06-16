using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogEngine.Domaine.Entites;
using BlogEngine.Domaine.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BlogEngine.Domaine.Repositories;

public class Repository<TEntity> : IRepository<TEntity>
where TEntity : Entite
{
    private readonly BlogEngineContext _context;

    protected DbSet<TEntity> DbSet => _context.Set<TEntity>();

    public Repository(BlogEngineContext context)
    {
        _context = context;
    }

    public void Ajouter(TEntity entite)
    {
        _context.Add(entite);

        _context.SaveChanges();
    }

    public void Modifier(TEntity entite)
    {
        _context.Update(entite);

        _context.SaveChanges();
    }

    public virtual TEntity? Obtenir(int id)
    {
        return DbSet.FirstOrDefault(entite => entite.Id == id);
    }

    public virtual List<TEntity> ObtenirTous()
    {
        return DbSet.ToList();
    }
}
