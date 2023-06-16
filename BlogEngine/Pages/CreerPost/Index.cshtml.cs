using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BlogEngine.Models;
using BlogEngine.Services.Interfaces;

namespace BlogEngine.Pages.CreerPost;


public class CreerPostModel : PageModel
{
    [BindProperty]
    public PostModel Post { set; get; }

    public List<SelectListItem> SelectCategories { get; set; } = new();

    private readonly IPostService _postService;
    private readonly ICategoryService _categoryService;

    public CreerPostModel(ICategoryService categoryService,
    IPostService postService)
    {
        _categoryService = categoryService;
        _postService = postService;
    }

    public void OnGet()
    {
        Post = new PostModel
        {
            PublicationDate = null!
        };

        AssignerSelectCategories();
    }

    public IActionResult OnPost()
    {
        Verifier();

        if (!ModelState.IsValid)
        {
            AssignerSelectCategories();

            return Page();
        }

        _postService.Ajouter(Post);

        return RedirectToPage("/Index");
    }

    private void Verifier()
    {
        if (_postService.Verifier(Post.Title))
        {
            ModelState.AddModelError("Post.Title", "This post title already exists.");
        }
    }

    private void AssignerSelectCategories()
    {
        SelectCategories = _categoryService.ObtenirSelectCategories();
    }
}
