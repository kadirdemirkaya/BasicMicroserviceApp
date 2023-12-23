using BasicMicroserviceApp.BuildingBlock.Base.Abstractions;
using MediatR;

namespace BasicMicroserviceApp.Article.Service.Features.Commands.UpdateArticle
{
    public class UpdateArticleCommandHandler : IRequestHandler<UpdateArticleCommandRequest, UpdateArticleCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateArticleCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<UpdateArticleCommandResponse> Handle(UpdateArticleCommandRequest request, CancellationToken cancellationToken)
        {
            var article = await _unitOfWork.GetReadRepository<BasicMicroserviceApp.Article.Service.Articles.Models.Article>().GetAsync(a => a.Id == request.UpdateArticleDto.Id);

            article.Title = request.UpdateArticleDto.Title;
            article.Content = request.UpdateArticleDto.Content;

            return new() { Result = await _unitOfWork.SaveChangesAsync() > 0 };
        }
    }
}
