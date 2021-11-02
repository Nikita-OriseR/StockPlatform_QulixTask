using MediatR;
using System;

namespace StockPlatform.Application.StockPlatform.Queries.GetPhotoList
{
    public class GetPhotoListQuery : IRequest<PhotoListVm>
    {
        public Guid PhotoId { get; set; }
    }
}
