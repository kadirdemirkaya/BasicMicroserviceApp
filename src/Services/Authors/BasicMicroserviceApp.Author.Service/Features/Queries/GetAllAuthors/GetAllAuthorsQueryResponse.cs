using BasicMicroserviceApp.Author.Service.Dtos;

namespace BasicMicroserviceApp.Author.Service.Features.Queries.GetAllAuthors
{
    public class GetAllAuthorsQueryResponse
    {
        public List<GetAllAuthorsDto> GetAllAuthorsDtos { get; set; }
    }
}
