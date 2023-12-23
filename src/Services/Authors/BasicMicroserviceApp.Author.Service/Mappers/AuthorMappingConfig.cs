using AutoMapper;
using BasicMicroserviceApp.Author.Service.Dtos;

namespace BasicMicroserviceApp.Author.Service.Mappers
{
    public class AuthorMappingConfig : Profile
    {
        public AuthorMappingConfig()
        {
            CreateMap<BasicMicroserviceApp.Author.Service.Author.Models.Author, CreateAuthorDto>().ReverseMap();
            CreateMap<BasicMicroserviceApp.Author.Service.Author.Models.Author, GetAllAuthorsDto>().ReverseMap();
        }
    }
}
