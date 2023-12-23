using MediatR;

namespace BasicMicroserviceApp.Article.Service.Features.Commands.DeleteArticle
{
    public class DeleteArticleCommandRequest: IRequest<DeleteArticleCommandResponse>
    {
        public Guid Id { get; set; }
    }
}
