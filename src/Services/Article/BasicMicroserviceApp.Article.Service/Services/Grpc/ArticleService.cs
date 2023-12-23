using ArticleService;
using BasicMicroserviceApp.BuildingBlock.Base.Abstractions;
using Grpc.Core;

namespace BasicMicroserviceApp.Article.Service.Services.Grpc
{
    public class ArticleService : GrpcArticle.GrpcArticleBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ArticleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public override async Task<AddArticleToAuthorResponse> AddArticleToAuthor(AddArticleToAuthorRequest request, ServerCallContext context)
        {
            AddArticleToAuthorResponse response = new();

            response.Result = await _unitOfWork.GetWriteRepository<BasicMicroserviceApp.Article.Service.Articles.Models.Article>().CreateAsync(new() { AuthorId = Guid.Parse(request.Articlemodel.AuthorId), Content = request.Articlemodel.Content, Title = request.Articlemodel.Title, Id = Guid.NewGuid() });

            response.Result = await _unitOfWork.SaveChangesAsync() > 0;

            return await Task.FromResult(response);
        }
    }
}
