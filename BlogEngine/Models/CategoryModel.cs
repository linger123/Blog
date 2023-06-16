using System.ComponentModel.DataAnnotations;
using BlogEngine.Domaine.Entites;
using System.Text.Json.Serialization;

namespace BlogEngine.Models;

public class CategoryModel
{
    [Key]
    public int Id { set; get; }

    [Required]
    [StringLength(150)]
    public string Title { set; get; } = null!;
    [JsonIgnore]
    public string TitleCache { set; get; } = string.Empty;

    public static implicit operator CategoryModel(Category category)
    {
        CategoryModel model = new CategoryModel();
        model.Id = category.Id;
        model.Title = category.Title;
        model.TitleCache = category.Title;

        return model;
    }

    public static implicit operator Category(CategoryModel model)
    {
        Category category = new Category();
        category.Id = model.Id;
        category.Title = model.Title;

        return category;
    }
}
