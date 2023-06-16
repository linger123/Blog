using BlogEngine.Services.Interfaces;
using BlogEngine.Domaine.Repositories.Categories;
using BlogEngine.Models;
using BlogEngine.Domaine.Entites; 
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BlogEngine.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public void Ajouter(CategoryModel model)
    {
        Category category = model;

        _categoryRepository.Ajouter(category);
    }

    public void Modifier(CategoryModel model)
    {
        Category category = model;

        _categoryRepository.Modifier(category);
    }

    public CategoryModel? Obtenir(int id)
    {
        var category = _categoryRepository.Obtenir(id);

        if (category is not null)
        {
            CategoryModel model = category;

            return model;
        }

        return null;
    }

    public List<CategoryModel> ObtenirTous()
    {
        return _categoryRepository.ObtenirTous().Select(category => (CategoryModel)category).ToList();
    }

    public bool Verifier(string title)
    {
        return _categoryRepository.Verifier(title);
    }

    public List<SelectListItem> ObtenirSelectCategories()
    {
        return ObtenirTous().Select(a =>
                                 new SelectListItem
                                 {
                                     Value = a.Id.ToString(),
                                     Text = a.Title
                                 }).ToList();
    }
}
