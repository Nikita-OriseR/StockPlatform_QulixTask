using MediatR;
using System;

namespace StockPlatform.Application.StockPlatform.Queries.GetEntityList
{
    public class GetEntitiesListQuery : IRequest<EntitiesListVm>
    {
        public Guid AuthorId { get; set; }
        public Guid PhotoId { get; set; }
        public Guid TextId { get; set; }
    }
}
