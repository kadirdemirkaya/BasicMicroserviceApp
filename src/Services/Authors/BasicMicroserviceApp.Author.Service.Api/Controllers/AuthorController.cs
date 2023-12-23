using BasicMicroserviceApp.Author.Service.Dtos;
using BasicMicroserviceApp.Author.Service.Features.Commands.AddArticleToAuthor;
using BasicMicroserviceApp.Author.Service.Features.Commands.CreateAuthor;
using BasicMicroserviceApp.Author.Service.Features.Commands.DeleteUser;
using BasicMicroserviceApp.Author.Service.Features.Queries.GetAllAuthors;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BasicMicroserviceApp.Author.Service.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("Create-Author")]
        public async Task<IActionResult> CreateAuthor([FromBody] CreateAuthorDto createAuthorDto)
        {
            CreateAuthorCommandRequest createAuthorCommandRequest = new() { CreateAuthorDto = createAuthorDto };
            CreateAuthorCommandResponse createAuthorCommandResponse = await _mediator.Send(createAuthorCommandRequest);
            return createAuthorCommandResponse.Result is true ? Ok(true) : BadRequest(false);
        }

        [HttpGet]
        [Route("Get-All-Authors")]
        public async Task<IActionResult> GetAllAuthors()
        {
            GetAllAuthorsQueryRequest getAllAuthorsQueryRequest = new();
            GetAllAuthorsQueryResponse getAllAuthorsQueryResponse = await _mediator.Send(getAllAuthorsQueryRequest);
            return Ok(getAllAuthorsQueryResponse.GetAllAuthorsDtos);
        }

        [HttpDelete]
        [Route("Delete-Author")]
        public async Task<IActionResult> DeleteAuthor([FromHeader] Guid Id)
        {
            DeleteAuthorCommandRequest deleteAuthorCommandRequest = new() { Id = Id };
            DeleteAuthorCommandResponse deleteAuthorCommandResponse = await _mediator.Send(deleteAuthorCommandRequest);
            return deleteAuthorCommandResponse.Result is true ? Ok(true) : BadRequest(false);
        }

        [HttpPost]
        [Route("Add-Article-To-Author/{authorId:guid}")]
        public async Task<IActionResult> AddArticleToAuthor([FromRoute] Guid authorId, [FromBody] AddArticleDto addArticleDto)
        {
            AddArticleToAuthorCommandRequest addArticleToAuthorCommandRequest = new() { AuthorId = authorId, AddArticleDto = addArticleDto };
            AddArticleToAuthorCommandResponse addArticleToAuthorCommandResponse = await _mediator.Send(addArticleToAuthorCommandRequest);
            return addArticleToAuthorCommandResponse.Result is true ? Ok(true) : BadRequest(false);
        }
    }
}
