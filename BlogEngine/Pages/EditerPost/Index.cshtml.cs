using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BlogEngine.Models;
using BlogEngine.Services.Interfaces;



namespace BlogEngine.Pages.EditerPost;

public class EditerPostModel : PageModel
{
    [BindProperty]
    public PostModel Post { set; get; }
    public List<SelectListItem> SelectCategories { get; set; } = new();

    private readonly IPostService _postService;
    private readonly ICategoryService _categoryService;

    public EditerPostModel(ICategoryService categoryService,
    IPostService postService)
    {
        _categoryService = categoryService;
        _postService = postService;
    }

    public IActionResult OnGet(int? id)
    {
        if (id == null)
        {
            return RedirectToPage("/Index");
        }

        var post = Obtenir(id.Value);

        if (post == null)
        {
            return RedirectToPage("/Index");
        }

        Post = post;

        AssignerSelectCategories();

        return Page();
    }

    public IActionResult OnPost()
    {
        if (Post.TitleCache != Post.Title)
        {
            Verifier();
        }

        if (!ModelState.IsValid)
        {
            AssignerSelectCategories();

            return Page();
        }

        _postService.Modifier(Post);

        return RedirectToPage("/Index");
    }

    private void Verifier()
    {
        if (_postService.Verifier(Post.Title))
        {
            ModelState.AddModelError("Post.Title", "This post title already exists.");
        }
    }

    private PostModel? Obtenir(int id)
    {
        return _postService.Obtenir(id);
    }

    private void AssignerSelectCategories()
    {
        SelectCategories = _categoryService.ObtenirSelectCategories();
    }
}
