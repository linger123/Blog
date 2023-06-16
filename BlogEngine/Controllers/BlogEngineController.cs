using Microsoft.AspNetCore.Mvc;
using BlogEngine.Models;
using BlogEngine.Constantes;
using BlogEngine.Services.Interfaces;

namespace BlogEngine.Controllers;

[ApiController]
[Route(ApiRoutes.RouteBase)]
public class BlogEngineController : ControllerBase
{
    private readonly ICategoryService _categoryService;
    private readonly IPostService _postService;
    
    public BlogEngineController(ICategoryService categoryService,
    IPostService postService)
    {
        _categoryService = categoryService;
        _postService = postService;
    }

    [HttpGet(ApiRoutes.BlogEngine.GetPosts)]
    public IActionResult GetPosts()
    {
        var posts = _postService.ObtenirPostValides();

        return posts.Any() ? CreerReponse(posts) : CreerReponse();
    }

    [HttpGet(ApiRoutes.BlogEngine.GetPost)]
    public IActionResult GetPost(int ID)
    {
        var post = _postService.ObtenirPostValide(ID);

        return post is not null ? CreerReponse(post) : CreerReponse();
    }

    [HttpGet(ApiRoutes.BlogEngine.GetCategories)]
    public IActionResult GetCategories()
    {
        var categories = _categoryService.ObtenirTous();

        return categories.Any() ? CreerReponse(categories) : CreerReponse();
    }

    [HttpGet(ApiRoutes.BlogEngine.GetCategorie)]
    public IActionResult GetCategorie(int ID)
    {
        var categorie = _categoryService.Obtenir(ID);

        return categorie is not null ? CreerReponse(categorie) : CreerReponse();
    }

    [HttpGet(ApiRoutes.BlogEngine.GetPostsByCategorie)]
    public IActionResult GetPostsByCategorie(int ID)
    {
        var posts = _postService.ObtenirPostValidesParCategorie(ID);

        return posts.Any() ? CreerReponse(posts) : CreerReponse();
    }

    protected IActionResult CreerReponse() => Ok(new Resultat(204));
    protected IActionResult CreerReponse<T>(T donnees) => Ok(new Resultat<T>(donnees, 200));
}
