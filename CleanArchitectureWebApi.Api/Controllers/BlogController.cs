using Microsoft.AspNetCore.Mvc;
using CleanArchitectureWebApi.Domain.Entities.Blog;
using CleanArchitectureWebApi.Application.Common.Interfaces.Repositories;
using CleanArchitectureWebApi.Application.DTOs;

namespace CleanArchitectureWebApi.Api.Controllers
{
    [Route("api/blog")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IBlogService _blogService;
        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        [HttpGet("getAll")]
        public async Task<ActionResult<Blog>> GetAll()
        {
            var item = await _blogService.GetAll();
            return Ok(item);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Blog>> GetById(int id)
        {
            var blog = await _blogService.GetById(id);
            if(blog is null)
            {
                return NotFound("Student not found.");
            }
            return Ok(blog);
        }

        [HttpPost("add")]
        public async Task AddBlog(BlogDto blog)
        {
            await _blogService.Add(blog);
        }

        [HttpPut("{id}")]
        public async Task Update(int id, BlogDto blog)
        {
            var blogList = await _blogService.GetById(id);
            if(blogList is null)
            {
                return;
            }
            await _blogService.Update(id,blog);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            var blog = await _blogService.GetById(id);
            if(blog is null)
            {
                return;
            }
            await _blogService.Delete(id);
        }
    }
}
