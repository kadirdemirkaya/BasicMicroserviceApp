using BasicMicroserviceApp.Article.Service.Dtos;
using MediatR;

namespace BasicMicroserviceApp.Article.Service.Features.Commands.AddArticle
{
    public class AddArticleCommandRequest : IRequest<AddArticleCommandResponse>
    {
        public AddArticleDto AddArticleDto { get; set; }
    }
}
