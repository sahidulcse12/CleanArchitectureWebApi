using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureWebApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiControllerBase : ControllerBase
    {
        private ISender _mediatr;
        protected ISender Mediatr => _mediatr ??= HttpContext.RequestServices.GetRequiredService<ISender>();
    }
}
