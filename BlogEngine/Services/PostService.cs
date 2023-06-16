using System.Collections.Generic;
using System.Linq;
using BlogEngine.Services.Interfaces;
using BlogEngine.Domaine.Repositories.Posts;
using BlogEngine.Domaine.Entites; 
using BlogEngine.Provider;
using BlogEngine.Models;


namespace BlogEngine.Services;

public class PostService : IPostService
{
    private readonly IPostRepository _postRepository;
    private IDateTimeProvider _dateTimeProvider;
    public PostService(IPostRepository postRepository, IDateTimeProvider dateTimeProvider)
    {
        _postRepository = postRepository;
        _dateTimeProvider = dateTimeProvider;
    }

    public void Ajouter(PostModel model)
    {
        Post post = model;

        _postRepository.Ajouter(post);
    }

    public void Modifier(PostModel model)
    {
        Post post = model;

        _postRepository.Modifier(post);
    }

    public PostModel? Obtenir(int id)
    {
        var post = _postRepository.Obtenir(id);

        if (post is not null)
        {
            PostModel model = post;

            return model;
        }

        return null;
    }

    public PostModel? ObtenirPostValide(int id)
    {
        var post = _postRepository.Obtenir(id, _dateTimeProvider.DateProduction);

        if (post is not null)
        {
            PostModel model = post;

            return model;
        }

        return null;
    }

    public List<PostModel> ObtenirTous()
    {
        return _postRepository.ObtenirTous().Select(post => (PostModel)post).ToList();
    }

    public List<PostModel> ObtenirPostValides()
    {
        return _postRepository.ObtenirTous(_dateTimeProvider.DateProduction)
        .Select(post => (PostModel)post).ToList();
    }

    public List<PostModel> ObtenirPostValidesParCategorie(int categoryId)
    {
        return _postRepository.ObtenirParCategorie(categoryId, _dateTimeProvider.DateProduction)
        .Select(post => (PostModel)post).ToList();
    }

    public bool Verifier(string title)
    {
        return _postRepository.Verifier(title);
    }
}
