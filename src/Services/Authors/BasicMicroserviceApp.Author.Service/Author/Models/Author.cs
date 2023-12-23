using BasicMicroserviceApp.BuildingBlock.Base.Models;
using System.ComponentModel.DataAnnotations;

namespace BasicMicroserviceApp.Author.Service.Author.Models
{
    public class Author : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Description { get; set; }

        public DateTime BornDate { get; set; } = DateTime.Now;
    }
}
