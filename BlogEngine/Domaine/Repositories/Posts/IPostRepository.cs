using BlogEngine.Domaine.Entites; 

namespace BlogEngine.Domaine.Repositories.Posts;

public interface IPostRepository: IRepository<Post>
{
    Post? Obtenir(int id, DateTime dateProduction);
    List<Post> ObtenirParCategorie(int categoryId, DateTime dateProduction);
    List<Post> ObtenirTous(DateTime dateProduction);
    bool Verifier(string title);
}
