using BasicMicroserviceApp.Author.Service.Dtos;
using MediatR;

namespace BasicMicroserviceApp.Author.Service.Features.Commands.AddArticleToAuthor
{
    public class AddArticleToAuthorCommandRequest : IRequest<AddArticleToAuthorCommandResponse>
    {
        public Guid AuthorId { get; set; }
        public AddArticleDto AddArticleDto { get; set; }
    }
}
