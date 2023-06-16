using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BlogEngine.Models;
using BlogEngine.Services.Interfaces;

namespace BlogEngine.Pages.CreerCategory;

public class CreerCategoryModel : PageModel
{
    [BindProperty]
    public CategoryModel Category { set; get; }

    private readonly ICategoryService _categoryService;
    public CreerCategoryModel(ICategoryService categoryService)
    {
         _categoryService = categoryService;
    }

    public void OnGet()
    {
    }

    public IActionResult OnPost()
    {
        Verifier();

        if (!ModelState.IsValid)
        {
            return Page();
        }

        _categoryService.Ajouter(Category);

        return RedirectToPage("/Index");
    }

    protected void Verifier()
    {
        if (_categoryService.Verifier(Category.Title))
        {
            ModelState.AddModelError("Category.Title", "This category title already exists.");
        }
    }
}
