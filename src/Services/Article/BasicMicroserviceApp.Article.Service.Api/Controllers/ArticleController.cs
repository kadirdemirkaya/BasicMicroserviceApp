using BasicMicroserviceApp.Article.Service.Dtos;
using BasicMicroserviceApp.Article.Service.Features.Commands.AddArticle;
using BasicMicroserviceApp.Article.Service.Features.Commands.DeleteArticle;
using BasicMicroserviceApp.Article.Service.Features.Commands.UpdateArticle;
using BasicMicroserviceApp.Article.Service.Features.Queries.GetAllArticles;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BasicMicroserviceApp.Article.Service.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ArticleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("Add-Article")]
        public async Task<IActionResult> AddArticle([FromBody] AddArticleDto addArticleDto)
        {
            AddArticleCommandRequest addArticleCommandRequest = new() { AddArticleDto = addArticleDto };
            AddArticleCommandResponse addArticleCommandResponse = await _mediator.Send(addArticleCommandRequest);
            return addArticleCommandResponse.Result is true ? Ok(true) : BadRequest(false);
        }

        [HttpGet]
        [Route("Get-All-Articles")]
        public async Task<IActionResult> GetAllArticles()
        {
            GetAllArticlesQueryRequest getAllArticlesQueryRequest = new();
            GetAllArticlesQueryResponse getAllArticlesQueryResponse = await _mediator.Send(getAllArticlesQueryRequest);
            return Ok(getAllArticlesQueryResponse.GetAllArticleDtos);
        }

        [HttpPut]
        [Route("Update-Article")]
        public async Task<IActionResult> UpdateArticle([FromBody] UpdateArticleDto updateArticleDto)
        {
            UpdateArticleCommandRequest updateArticleCommandRequest = new UpdateArticleCommandRequest() { UpdateArticleDto = updateArticleDto };
            UpdateArticleCommandResponse updateArticleCommandResponse = await _mediator.Send(updateArticleCommandRequest);
            return updateArticleCommandResponse.Result is true ? Ok(true) : BadRequest(false);
        }

        [HttpDelete]
        [Route("Delete-Articles")]
        public async Task<IActionResult> DeleteArticle([FromHeader] Guid Id)
        {
            DeleteArticleCommandRequest deleteArticleCommandRequest = new() { Id = Id };
            DeleteArticleCommandResponse deleteArticleCommandResponse = await _mediator.Send(deleteArticleCommandRequest);
            return deleteArticleCommandResponse.Result is true ? Ok(true) : BadRequest(false);
        }
    }
}
