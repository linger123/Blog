using System;
using System.ComponentModel.DataAnnotations;
using BlogEngine.Domaine.Entites;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.Json.Serialization;

namespace BlogEngine.Models;

public class PostModel
{
    [Key]
    public int Id { set; get; }

    [Key]
    [Display(Name = "Category")]
    public int CategoryId { set; get; }

    [Required]
    [StringLength(150)]
    public string Title { set; get; } = null!;
    
    [Required]
    public string Content { set; get; } = null!;

    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
    [DataType(DataType.Date)]
    [Required]
    [Display(Name = "Pub Date")]
    public DateTime? PublicationDate { set; get; }

    [JsonIgnore]
    public string TitleCache { set; get; } = string.Empty;

    public static implicit operator PostModel(Post post)
    {
        PostModel model = new PostModel();
        model.Id = post.Id;
        model.CategoryId = post.CategoryId;
        model.Title = post.Title;
        model.Content = post.Content;
        model.PublicationDate = post.PublicationDate;
        model.TitleCache = post.Title;

        return model;
    }

    public static implicit operator Post(PostModel model)
    {
        Post post = new Post();
        post.Id = model.Id;
        post.CategoryId = model.CategoryId;
        post.Title = model.Title;
        post.Content = model.Content;
        post.PublicationDate = model.PublicationDate.Value;

        return post;
    }
}
