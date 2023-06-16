using BlogEngine.Domaine.Persistence;
using BlogEngine.Domaine.Entites;
using BlogEngine.Provider;

namespace BlogEngine.Domaine.Repositories.Posts;

public sealed class PostRepository : Repository<Post>,
 IPostRepository
{
    private IDateTimeProvider _dateTimeProvider;
    public PostRepository(BlogEngineContext context, IDateTimeProvider dateTimeProvider) : base(context)
    {
        _dateTimeProvider = dateTimeProvider;
    }


    public Post? Obtenir(int id, DateTime dateProduction)
    {
        return DbSet.FirstOrDefault(post => post.Id == id &&
        post.PublicationDate <= dateProduction);
    }

    public List<Post> ObtenirTous(DateTime dateProduction)
    {
        return DbSet.OrderByDescending(post => post.PublicationDate).Where(post => post.PublicationDate <= dateProduction)
        .ToList();
    }

    public List<Post> ObtenirParCategorie(int categoryId, DateTime dateProduction)
    {
        return DbSet.OrderByDescending(post => post.PublicationDate).Where(post => post.CategoryId == categoryId
        && post.PublicationDate <= dateProduction)
        .ToList();
    }

    public bool Verifier(string title)
    {
        return DbSet.Any(post => post.Title == title);
    }
}
