using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureWebApi.Application.Blogs.Commands.Update
{
    public class UpdateCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string Author { get; set; } = default!;
    }
}
