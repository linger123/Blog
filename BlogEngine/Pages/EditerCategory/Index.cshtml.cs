using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BlogEngine.Models;
using BlogEngine.Services.Interfaces;


namespace BlogEngine.Pages.EditerCategory;

public class EditerCategoryModel : PageModel
{
    [BindProperty]
    public CategoryModel Category { set; get; }

    private readonly ICategoryService _categoryService;
    public EditerCategoryModel(ICategoryService categoryService)
    {
         _categoryService = categoryService;
    }
    public IActionResult OnGet(int? id)
    {
        if (id == null)
        {
            return RedirectToPage("/Index");
        }

        var category = Obtenir(id.Value);

        if (category == null)
        {
            return RedirectToPage("/Index");
        }

        Category = category;

        return Page();
    }

    public IActionResult OnPost()
    {
        if (Category.TitleCache != Category.Title)
        {
            Verifier();
        }
        
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _categoryService.Modifier(Category);

        return RedirectToPage("/Index");
    }

    protected void Verifier()
    {
        if (_categoryService.Verifier(Category.Title))
        {
            ModelState.AddModelError("Category.Title", "This category title already exists.");
        }
    }

    private CategoryModel? Obtenir(int id)
    {
        return _categoryService.Obtenir(id);
    }
}
