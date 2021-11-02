using MediatR;
using StockPlatform.Application.Interfaces;
using StockPlatform.Domain;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StockPlatform.Application.StockPlatform.Commands.CreatePhoto
{
    public class CreatePhotoCommandHandler : IRequestHandler<CreatePhotoCommand, Guid>
    {
        private readonly IStockPlatformDbContext _dbContext;
        public CreatePhotoCommandHandler(IStockPlatformDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Guid> Handle(CreatePhotoCommand request, CancellationToken cancellationToken)
        {
            var photo = new Photo
            {
                PhotoId = request.PhotoId,
                Title = request.Title,
                ContentLink = request.ContentLink,
                Height = request.Height,
                Width = request.Width,
                CreationDate = request.CreationDate,
                Author = request.Author,
                Cost = request.Cost,
                NumberPurchases = request.NumberPurchases
            };

            await _dbContext.Photos.AddAsync(photo, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return photo.PhotoId;
        }
    }
}
