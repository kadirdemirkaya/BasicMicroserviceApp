using BasicMicroserviceApp.Author.Service.Dtos;

namespace BasicMicroserviceApp.Author.Service.Abstractions
{
    public interface IAuthorService
    {
        Task<bool> AddArticleForAuthorAsync(Guid authorId, AddArticleDto addArticleDto);
    }
}
