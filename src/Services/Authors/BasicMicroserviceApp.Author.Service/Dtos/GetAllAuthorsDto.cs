namespace BasicMicroserviceApp.Author.Service.Dtos
{
    public class GetAllAuthorsDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public DateTime BornDate { get; set; } = DateTime.Now;
    }
}
