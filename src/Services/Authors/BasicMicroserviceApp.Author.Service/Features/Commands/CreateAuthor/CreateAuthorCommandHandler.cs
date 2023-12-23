using AutoMapper;
using BasicMicroserviceApp.BuildingBlock.Base.Abstractions;
using MediatR;

namespace BasicMicroserviceApp.Author.Service.Features.Commands.CreateAuthor
{
    public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommandRequest, CreateAuthorCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CreateAuthorCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CreateAuthorCommandResponse> Handle(CreateAuthorCommandRequest request, CancellationToken cancellationToken)
        {
            await _unitOfWork.GetWriteRepository<BasicMicroserviceApp.Author.Service.Author.Models.Author>().CreateAsync(_mapper.Map<BasicMicroserviceApp.Author.Service.Author.Models.Author>(request.CreateAuthorDto));
            return new() { Result = await _unitOfWork.SaveChangesAsync() > 0 };
        }
    }
}
