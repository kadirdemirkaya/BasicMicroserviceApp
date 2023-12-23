using BasicMicroserviceApp.Article.Service.Dtos;

namespace BasicMicroserviceApp.Article.Service.Features.Queries.GetAllArticles
{
    public class GetAllArticlesQueryResponse
    {
        public List<GetAllArticleDto> GetAllArticleDtos { get; set; }
    }
}
