using CleanArchitectureWebApi.Application.Common.Interfaces.Repositories;
using CleanArchitectureWebApi.Application.DTOs;
using CleanArchitectureWebApi.Domain.Entities.Blog;
using CleanArchitectureWebApi.Infrastructure.Data.DbContexts;

namespace CleanArchitectureWebApi.Infrastructure.Services
{
    public class BlogService : IBlogService
    {
        private readonly IRepository<Blog> _blogRepository;
        private readonly BlogDbContext _context;

        public BlogService(IRepository<Blog> blogRepository, BlogDbContext context)
        {
            _blogRepository = blogRepository;
            _context = context;
        }
        public async Task Add(BlogDto blog)
        {
            var newBlog = new Blog
            {
                Name = blog.Name,
                Description = blog.Description,
                Author = blog.Author,
            };
            await _blogRepository.AddAsync(newBlog);
        }

        public async Task Delete(int id)
        {
            await _blogRepository.DeleteAsync(id);
        }

        public async Task<IList<BlogDto>> GetAll()
        {
            var listOfBlogs = await _blogRepository.GetAllAsync();
            var blogDtos = new List<BlogDto>();
            foreach (var item in blogDtos)
            {
                var blogDto = new BlogDto
                {
                    Id = item.Id,
                    Name = item.Name,
                    Description = item.Description,
                    Author = item.Author,
                };
                blogDtos.Add(blogDto);
            }
            return blogDtos;
        }

        public async Task<BlogDto?> GetById(int id)
        {
            var blog = await _blogRepository.GetByIdAsync(id);

            var blogDto = new BlogDto
            {
                Id = blog!.Id,
                Author = blog.Author,
                Description = blog.Description,
                Name = blog.Name
            };

            return blogDto;
        }

        public async Task Update(int id, BlogDto blog)
        {
            var blogList = await _blogRepository.GetByIdAsync(id);
            if (blogList is null)
            {
                return;
            }
            blogList.Name = blog.Name;
            blogList.Description = blog.Description;
            blogList.Author = blog.Author;

            await _blogRepository.UpdateAsync(id, blogList);
        }
    }
}
