using MediatR;

namespace BasicMicroserviceApp.Article.Service.Features.Queries.GetAllArticles
{
    public class GetAllArticlesQueryRequest : IRequest<GetAllArticlesQueryResponse>
    {
    }
}
