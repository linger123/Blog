using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogEngine.Domaine.Entites;

namespace BlogEngine.Domaine.Repositories;

public interface IRepository<TEntity>
where TEntity : Entite
{
    void Ajouter(TEntity entite);
    void Modifier(TEntity entite);
    TEntity? Obtenir(int id);
    List<TEntity> ObtenirTous();
}
