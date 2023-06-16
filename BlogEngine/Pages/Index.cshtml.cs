
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BlogEngine.Models;
using BlogEngine.Services.Interfaces;

namespace BlogEngine.Pages;

public class IndexModel : PageModel
{
    public List<CategoryModel> Categories { set; get; }
    public List<PostModel> Posts { set; get; }

    private readonly ICategoryService _categoryService;
    private readonly IPostService _postService;

    public IndexModel(ICategoryService categoryService,
    IPostService postService)
    {
        _categoryService = categoryService;
        _postService = postService;
    }

    public void OnGet()
    {
        Categories = _categoryService.ObtenirTous();

        Posts = _postService.ObtenirTous();
    }
}
