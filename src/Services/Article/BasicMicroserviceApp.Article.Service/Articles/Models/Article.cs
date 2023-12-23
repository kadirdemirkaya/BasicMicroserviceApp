using BasicMicroserviceApp.BuildingBlock.Base.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace BasicMicroserviceApp.Article.Service.Articles.Models
{
    [Table("Articles")]
    public class Article : BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public Guid AuthorId { get; set; }
    }
}
