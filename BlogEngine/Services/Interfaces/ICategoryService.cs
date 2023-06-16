using System.Collections.Generic;
using BlogEngine.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BlogEngine.Services.Interfaces;

public interface ICategoryService
{
    void Ajouter(CategoryModel model);
    void Modifier(CategoryModel model);
    CategoryModel? Obtenir(int id);
    List<CategoryModel> ObtenirTous();
    bool Verifier(string title);
    List<SelectListItem> ObtenirSelectCategories();
}
