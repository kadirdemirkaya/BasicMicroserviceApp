using AutoMapper;
using BasicMicroserviceApp.Author.Service.Abstractions;
using BasicMicroserviceApp.BuildingBlock.Base.Abstractions;
using MediatR;

namespace BasicMicroserviceApp.Author.Service.Features.Commands.AddArticleToAuthor
{
    public class AddArticleToAuthorCommandHandler : IRequestHandler<AddArticleToAuthorCommandRequest, AddArticleToAuthorCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuthorService _authorService;
        private readonly IMapper _mapper;
        public AddArticleToAuthorCommandHandler(IUnitOfWork unitOfWork, IAuthorService authorService, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _authorService = authorService;
            _mapper = mapper;
        }

        public async Task<AddArticleToAuthorCommandResponse> Handle(AddArticleToAuthorCommandRequest request, CancellationToken cancellationToken)
        {
            if (await _unitOfWork.GetReadRepository<BasicMicroserviceApp.Author.Service.Author.Models.Author>().AnyAsync(a => a.Id == request.AuthorId))
                return new() { Result = await _authorService.AddArticleForAuthorAsync(request.AuthorId, request.AddArticleDto) };
            return new() { Result = false };
        }
    }
}
