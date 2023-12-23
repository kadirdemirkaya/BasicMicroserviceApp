using ArticleService;
using BasicMicroserviceApp.Author.Service.Abstractions;
using BasicMicroserviceApp.Author.Service.Dtos;
using Grpc.Net.Client;
using Microsoft.Extensions.Configuration;

namespace BasicMicroserviceApp.Author.Service.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IConfiguration _configuration;
        public AuthorService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<bool> AddArticleForAuthorAsync(Guid authorId, AddArticleDto addArticleDto)
        {
            var channel = GrpcChannel.ForAddress(_configuration["ArticleConnectionUrl"]);
            var client = new GrpcArticle.GrpcArticleClient(channel);
            var request = new AddArticleToAuthorRequest() { Articlemodel = new() { AuthorId = authorId.ToString(), Content = addArticleDto.Content, Title = addArticleDto.Title } };

            try
            {
                var reply = await client.AddArticleToAuthorAsync(request);
                return reply.Result;
            }
            catch (Exception ex)
            {
                Serilog.Log.Error("Grpc communication error : " + ex.Message);
            }

            return default;
        }
    }
}
