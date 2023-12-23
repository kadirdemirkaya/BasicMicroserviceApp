using BasicMicroserviceApp.BuildingBlock.Base.Abstractions;
using MediatR;

namespace BasicMicroserviceApp.Author.Service.Features.Commands.DeleteUser
{
    public class DeleteAuthorCommandHandler : IRequestHandler<DeleteAuthorCommandRequest, DeleteAuthorCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteAuthorCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<DeleteAuthorCommandResponse> Handle(DeleteAuthorCommandRequest request, CancellationToken cancellationToken)
        {
            return new() { Result = await _unitOfWork.GetWriteRepository<BasicMicroserviceApp.Author.Service.Author.Models.Author>().DeleteByIdAsync(request.Id) };
        }
    }
}
