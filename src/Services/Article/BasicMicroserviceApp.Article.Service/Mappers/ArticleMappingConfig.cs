using AutoMapper;
using BasicMicroserviceApp.Article.Service.Dtos;

namespace BasicMicroserviceApp.Article.Service.Mappers
{
    public class ArticleMappingConfig : Profile
    {
        public ArticleMappingConfig()
        {
            CreateMap<BasicMicroserviceApp.Article.Service.Articles.Models.Article, AddArticleDto>().ReverseMap();
            CreateMap<BasicMicroserviceApp.Article.Service.Articles.Models.Article, GetAllArticleDto>().ReverseMap();
            CreateMap<BasicMicroserviceApp.Article.Service.Articles.Models.Article, UpdateArticleDto>().ReverseMap();
        }
    }
}
