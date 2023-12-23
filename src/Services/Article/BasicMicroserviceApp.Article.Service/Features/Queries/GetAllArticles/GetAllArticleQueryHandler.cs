using AutoMapper;
using BasicMicroserviceApp.Article.Service.Dtos;
using BasicMicroserviceApp.BuildingBlock.Base.Abstractions;
using MediatR;

namespace BasicMicroserviceApp.Article.Service.Features.Queries.GetAllArticles
{
    public class GetAllArticleQueryHandler : IRequestHandler<GetAllArticlesQueryRequest, GetAllArticlesQueryResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetAllArticleQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<GetAllArticlesQueryResponse> Handle(GetAllArticlesQueryRequest request, CancellationToken cancellationToken)
        {
            var articles = await _unitOfWork.GetReadRepository<BasicMicroserviceApp.Article.Service.Articles.Models.Article>().GetAllAsync();
            return new() { GetAllArticleDtos = _mapper.Map<List<GetAllArticleDto>>(articles) };
        }
    }
}
