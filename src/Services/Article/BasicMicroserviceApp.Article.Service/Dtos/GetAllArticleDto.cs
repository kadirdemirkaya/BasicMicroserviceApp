namespace BasicMicroserviceApp.Article.Service.Dtos
{
    public class GetAllArticleDto
    {
        public string Title { get; set; }
        public string Content { get; set; }

        public Guid AuthorId { get; set; }
    }
}
