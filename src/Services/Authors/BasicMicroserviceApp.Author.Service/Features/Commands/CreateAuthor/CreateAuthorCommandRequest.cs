using BasicMicroserviceApp.Author.Service.Dtos;
using MediatR;

namespace BasicMicroserviceApp.Author.Service.Features.Commands.CreateAuthor
{
    public class CreateAuthorCommandRequest : IRequest<CreateAuthorCommandResponse>
    {
        public CreateAuthorDto CreateAuthorDto { get; set; }
    }
}
