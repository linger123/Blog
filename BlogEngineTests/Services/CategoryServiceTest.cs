using BlogEngine.Services;
using BlogEngine.Domaine.Repositories.Categories;
using BlogEngine.Models;
using BlogEngine.Domaine.Entites;

namespace BlogEngineTests.Services;

public class CategoryServiceTest
{
   
    [Fact]
    public void Ajouter_EnToutTemps_EffectuerAvecSucces()
    {
        // Arranger
        var model = new CategoryModel { Title = "Title 1" };
        var category = new Category { Title = "Title 1" };
        var mockCategoryRepository = new Mock<ICategoryRepository>();

        var service = new CategoryService(mockCategoryRepository.Object);

        // Agir
        service.Ajouter(model);

        // Affirmer
        mockCategoryRepository.Verify(s =>
         s.Ajouter(It.Is<Category>(c => c.Title == category.Title)));
    }

    [Fact]
    public void Modifier_EnToutTemps_ModifierDeRepositoryAppeleAvecSucces()
    {
        // Arranger
        var model = new CategoryModel { Id = 1, Title = "Title 1" };
        var category = new Category { Id = 1, Title = "Title 1" };
        var mockCategoryRepository = new Mock<ICategoryRepository>();

        var service = new CategoryService(mockCategoryRepository.Object);

        // Agir
        service.Modifier(model);

        // Affirmer
        mockCategoryRepository.Verify(s =>
         s.Modifier(It.Is<Category>(c => c.Id == category.Id && c.Title == category.Title)));
    }

    [Fact]
    public void Obtenir_AucuneCategorieCorrespondante_RetourneNull()
    {
        // Arranger
        var mockCategoryRepository = new Mock<ICategoryRepository>();
        mockCategoryRepository.Setup(r => r.Obtenir(It.IsAny<int>())).Returns((Category)null!);

        var service = new CategoryService(mockCategoryRepository.Object);

        // Agir
        var model = service.Obtenir(1);

        // Affirmer
        Assert.Null(model);
    }

    [Fact]
    public void Obtenir_CategorieCorrespondanteTrouve_RetourneUneCategorie()
    {
        // Arranger
        var mockCategoryRepository = new Mock<ICategoryRepository>();
        var category = new Category { Id = 1, Title = "Title 1" };
        mockCategoryRepository.Setup(r => r.Obtenir(It.IsAny<int>())).Returns(category);

        var service = new CategoryService(mockCategoryRepository.Object);

        // Agir
        var model = service.Obtenir(1)!;

        // Affirmer
        Assert.Equal(category.Id, model.Id);
        Assert.Equal(category.Title, model.Title);
    }

    [Fact]
    public void ObtenirTous_AucuneCategorie_RetourneListeVide()
    {
        // Arranger
        var mockCategoryRepository = new Mock<ICategoryRepository>();
        mockCategoryRepository.Setup(r => r.ObtenirTous()).Returns(new List<Category>());

        var service = new CategoryService(mockCategoryRepository.Object);

        // Agir
        var categories = service.ObtenirTous();

        // Affirmer
        Assert.Empty(categories);
    }

    [Fact]
    public void ObtenirTous_CategoriesExistantes_RetourneListeContenantUneCategory()
    {
        // Arranger
        var mockCategoryRepository = new Mock<ICategoryRepository>();
        var category = new Category { Id = 1, Title = "Title 1" };
        mockCategoryRepository.Setup(r => r.ObtenirTous()).Returns(new List<Category> { category });

        var service = new CategoryService(mockCategoryRepository.Object);

        // Agir
        var categories = service.ObtenirTous();

        // Affirmer
        Assert.Equal(1, categories.Count);
        Assert.Equal(category.Id, categories.ElementAt(0).Id);
        Assert.Equal(category.Title, categories.ElementAt(0).Title);
    }

    [Fact]
    public void Verifier_AucuneCategorieCorrespondant_RetourneFalse()
    {
        // Arranger
        var mockCategoryRepository = new Mock<ICategoryRepository>();
        mockCategoryRepository.Setup(r => r.Verifier(It.IsAny<string>())).Returns(false);
        var service = new CategoryService(mockCategoryRepository.Object);

        // Agir
        var existe = service.Verifier("Title");

        // Affirmer
        Assert.False(existe);
    }

    [Fact]
    public void Verifier_CategorieCorrespondantTrouve_RetourneTrue()
    {
        // Arranger
        var mockCategoryRepository = new Mock<ICategoryRepository>();
        mockCategoryRepository.Setup(r => r.Verifier(It.IsAny<string>())).Returns(true);
        var service = new CategoryService(mockCategoryRepository.Object);

        // Agir
        var existe = service.Verifier("Title");

        // Affirmer
        Assert.True(existe);
    }

    [Fact]
    public void ObtenirSelectCategories_CategoriesExistantes_RetourneListeSelectContenantUnItem()
    {
        // Arranger
        var mockCategoryRepository = new Mock<ICategoryRepository>();
        var category = new Category { Id = 1, Title = "Title 1" };
        mockCategoryRepository.Setup(r => r.ObtenirTous()).Returns(new List<Category> { category });

        var service = new CategoryService(mockCategoryRepository.Object);

        // Agir
        var categories = service.ObtenirSelectCategories();

        // Affirmer
        Assert.Equal(1, categories.Count);
        Assert.Equal(category.Id.ToString(), categories.ElementAt(0).Value);
        Assert.Equal(category.Title, categories.ElementAt(0).Text);
    }
}
