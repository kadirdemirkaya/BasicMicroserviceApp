using BasicMicroserviceApp.Article.Service.Dtos;
using MediatR;

namespace BasicMicroserviceApp.Article.Service.Features.Commands.UpdateArticle
{
    public class UpdateArticleCommandRequest : IRequest<UpdateArticleCommandResponse>
    {
        public UpdateArticleDto UpdateArticleDto { get; set; }
    }
}
