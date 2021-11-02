using MediatR;
using Microsoft.EntityFrameworkCore;
using StockPlatform.Application.Common.Exceptions;
using StockPlatform.Application.Interfaces;
using StockPlatform.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace StockPlatform.Application.StockPlatform.Commands.UpdatePhoto
{
    public class UpdatePhotoCommandHandler : IRequestHandler<UpdatePhotoCommand>
    {
        private readonly IStockPlatformDbContext _dbContext;
        public UpdatePhotoCommandHandler(IStockPlatformDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Unit> Handle(UpdatePhotoCommand request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Photos.FirstOrDefaultAsync(photo =>
                photo.PhotoId == request.PhotoId, cancellationToken);
            if (entity == null || entity.PhotoId != request.PhotoId)
            {
                throw new NotFoundException(nameof(Photo), request.PhotoId);
            }

            entity.Title = request.Title;
            entity.ContentLink = request.ContentLink;
            entity.Height = request.Height;
            entity.Width = request.Width;
            entity.Cost = request.Cost;
            entity.NumberPurchases = request.NumberPurchases;

            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
