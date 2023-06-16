namespace BlogEngine.Constantes;

public static class ApiRoutes
{
    /// <summary>
    /// route base.
    /// </summary>
    public const string RouteBase = "api/[controller]";

    public static class BlogEngine
    {
        /// <summary>
        ///obtenir posts.
        /// </summary>
        public const string GetPosts = "posts";


        /// <summary>
        ///obtenir post.
        /// </summary>
        public const string GetPost = "posts/{ID}";

        /// <summary>
        ///obtenir categories.
        /// </summary>
        public const string GetCategories = "categories";

        /// <summary>
        ///obtenir categorie.
        /// </summary>
        public const string GetCategorie = "categories/{ID}";

        /// <summary>
        ///obtenir posts par categorie.
        /// </summary>
        public const string GetPostsByCategorie = "categories/{ID}/posts";
    }
}
