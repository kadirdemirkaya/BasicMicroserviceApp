namespace BasicMicroserviceApp.Author.Service.Dtos
{
    public class AddArticleDto
    {
        public string Title { get; set; }
        public string Content { get; set; }

        public Guid AuthorId { get; set; }
    }
}
