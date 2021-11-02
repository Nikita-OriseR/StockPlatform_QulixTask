using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StockPlatform.Application.Common.Exceptions;
using StockPlatform.Application.Interfaces;
using StockPlatform.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace StockPlatform.Application.StockPlatform.Queries.GetPhotoDetails
{
    public class GetPhotoDetailsQueryHandler : IRequestHandler<GetPhotoDetailsQuery, PhotoDetailsVm>
    {
        private readonly IStockPlatformDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetPhotoDetailsQueryHandler(IStockPlatformDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<PhotoDetailsVm> Handle(GetPhotoDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Photos.FirstOrDefaultAsync(photo =>
                photo.PhotoId == request.PhotoId, cancellationToken);
            if (entity is null || entity.PhotoId != request.PhotoId)
            {
                throw new NotFoundException(nameof(Author), request.PhotoId);
            }

            return _mapper.Map<PhotoDetailsVm>(entity);
        }
    }
}
