using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BlogEngine.Domaine.Entites;

namespace BlogEngine.Domaine.Persistence;

public class BlogEngineContext : DbContext
{
    public new DbSet<TEntity> Set<TEntity>()
         where TEntity : Entite
         => base.Set<TEntity>();
         
    public BlogEngineContext(DbContextOptions<BlogEngineContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Id).IsRequired();
            entity.Property(c => c.Title).IsRequired();
        });

        modelBuilder.Entity<Post>(entity =>
        {
           entity.HasKey(p => p.Id);
           entity.Property(p => p.Id).IsRequired();
           entity.Property(p => p.CategoryId).IsRequired();
           entity.Property(p => p.Title).IsRequired();
           entity.Property(p => p.PublicationDate).IsRequired();
           entity.Property(p => p.Content).IsRequired();
        });
    }
}
