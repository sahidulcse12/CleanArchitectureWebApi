using Microsoft.AspNetCore.Mvc;
using CleanArchitectureWebApi.Application.Blogs.Queries.GetBlogs;
using CleanArchitectureWebApi.Application.Blogs.Queries.GetById;
using CleanArchitectureWebApi.Application.Blogs.Commands.Create;
using CleanArchitectureWebApi.Application.Blogs.Commands.Update;
using CleanArchitectureWebApi.Application.Blogs.Commands.Delete;

namespace CleanArchitectureWebApi.Api.Controllers
{
    [Route("api/blog")]
    [ApiController]
    public class BlogController : ApiControllerBase
    {
        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var item = await Mediatr.Send(new GetBlogQuery());
            return Ok(item);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var blog = await Mediatr.Send(new GetBlogByIdQuery() { BlogId = id });
            if (blog is null)
            {
                return NotFound("Student not found.");
            }
            return Ok(blog);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddBlog(CreateCommand command)
        {
            await Mediatr.Send(command);
            return Ok("Blog is created successfully");
            
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            await Mediatr.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await Mediatr.Send(new DeleteCommand { Id = id });
            return Ok(result);
        }
    }
}
