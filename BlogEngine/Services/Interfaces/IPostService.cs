using System.Collections.Generic;
using BlogEngine.Models;

namespace BlogEngine.Services.Interfaces;

public interface IPostService
{
    void Ajouter(PostModel model);
    void Modifier(PostModel model);
    PostModel? Obtenir(int id);
    PostModel? ObtenirPostValide(int id);
    List<PostModel> ObtenirTous();
    List<PostModel> ObtenirPostValides();
    List<PostModel> ObtenirPostValidesParCategorie(int categoryId);
    bool Verifier(string title);
}
