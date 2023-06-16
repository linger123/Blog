using BlogEngine.Domaine.Persistence;
using BlogEngine.Domaine.Entites; 

namespace BlogEngine.Domaine.Repositories.Categories;

public sealed class CategoryRepository : Repository<Category>,
 ICategoryRepository
{
    public CategoryRepository(BlogEngineContext context): base(context)
    {
    }

    public bool Verifier(string title)
    {
        return DbSet.Any(categorie => categorie.Title == title);
    }
}
