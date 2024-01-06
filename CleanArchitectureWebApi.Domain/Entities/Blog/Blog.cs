
namespace CleanArchitectureWebApi.Domain.Entities.Blog
{
    public class Blog
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string Author { get; set; } = default!;
    }
}
