using AutoMapper;
using BasicMicroserviceApp.BuildingBlock.Base.Abstractions;
using MediatR;

namespace BasicMicroserviceApp.Article.Service.Features.Commands.AddArticle
{
    public class AddArticleCommandHandler : IRequestHandler<AddArticleCommandRequest, AddArticleCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public AddArticleCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<AddArticleCommandResponse> Handle(AddArticleCommandRequest request, CancellationToken cancellationToken)
        {
            var article = _mapper.Map<BasicMicroserviceApp.Article.Service.Articles.Models.Article>(request.AddArticleDto);
            bool dbResult = await _unitOfWork.GetWriteRepository<BasicMicroserviceApp.Article.Service.Articles.Models.Article>().CreateAsync(article);
            dbResult = await _unitOfWork.SaveChangesAsync() > 0;
            return new() { Result = dbResult };
        }
    }
}
