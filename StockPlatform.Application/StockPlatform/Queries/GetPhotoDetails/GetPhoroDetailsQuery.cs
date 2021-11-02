using MediatR;
using System;

namespace StockPlatform.Application.StockPlatform.Queries.GetPhotoDetails
{
    public class GetPhotoDetailsQuery : IRequest<PhotoDetailsVm>
    {
        public Guid PhotoId { get; set; }
    }
}
