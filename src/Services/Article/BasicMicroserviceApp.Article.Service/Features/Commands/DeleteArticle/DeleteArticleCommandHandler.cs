using BasicMicroserviceApp.BuildingBlock.Base.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicMicroserviceApp.Article.Service.Features.Commands.DeleteArticle
{
    public class DeleteArticleCommandHandler : IRequestHandler<DeleteArticleCommandRequest, DeleteArticleCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteArticleCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<DeleteArticleCommandResponse> Handle(DeleteArticleCommandRequest request, CancellationToken cancellationToken)
        {
            return new() { Result = await _unitOfWork.GetWriteRepository<BasicMicroserviceApp.Article.Service.Articles.Models.Article>().DeleteByIdAsync(request.Id) };
        }
    }
}
