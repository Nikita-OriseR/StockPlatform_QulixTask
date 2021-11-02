using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StockPlatform.Application.Interfaces;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StockPlatform.Application.StockPlatform.Queries.GetEntityList
{
    public class GetEntitiesListQueryHandler : IRequestHandler<GetEntitiesListQuery, EntitiesListVm>
    {
        private readonly IStockPlatformDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetEntitiesListQueryHandler(IStockPlatformDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<EntitiesListVm> Handle(GetEntitiesListQuery request, CancellationToken cancellationToken)
        {
            var authorsQuery =
                await _dbContext.Authors
                .Where(author => author.AuthorId == request.AuthorId)
                .ProjectTo<EntitiesLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            var photosQuery =
                await _dbContext.Photos
                .Where(photo => photo.PhotoId == request.PhotoId)
                .ProjectTo<EntitiesLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            var textsQuery =
                await _dbContext.Texts
                .Where(text => text.TextId == request.TextId)
                .ProjectTo<EntitiesLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new EntitiesListVm { Authors = authorsQuery, Photos = photosQuery, Texts = textsQuery };
        }
    }
}
