using MediatR;

namespace BasicMicroserviceApp.Author.Service.Features.Commands.DeleteUser
{
    public class DeleteAuthorCommandRequest : IRequest<DeleteAuthorCommandResponse>
    {
        public Guid Id { get; set; }
    }
}
