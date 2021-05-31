using System.Collections.Generic;
using MediatR;

namespace TimeKeeper.Shared.Api.Features.Category
{
    public class GetActive
    {
        public record Query : IRequest<IEnumerable<Model>>
        {
            
        }

        public record Model
        {            
            public int Id { get; set; }
            public string Name { get; set; }
        }
    }
}
