using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StockPlatform.Application.Interfaces;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StockPlatform.Application.StockPlatform.Queries.GetPhotoList
{
    public class GetPhotoListQueryHandler : IRequestHandler<GetPhotoListQuery, PhotoListVm>
    {
        private readonly IStockPlatformDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetPhotoListQueryHandler(IStockPlatformDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<PhotoListVm> Handle(GetPhotoListQuery request, CancellationToken cancellationToken)
        {
            var photosQuery =
                await _dbContext.Photos
                .Where(photo => photo.PhotoId == request.PhotoId)
                .ProjectTo<PhotoLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new PhotoListVm { Photos = photosQuery };
        }
    }
}
