namespace BasicMicroserviceApp.Article.Service.Dtos
{
    public class UpdateArticleDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public Guid AuthorId { get; set; }
    }
}
