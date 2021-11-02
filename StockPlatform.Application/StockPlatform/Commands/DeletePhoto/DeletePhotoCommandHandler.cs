using MediatR;
using StockPlatform.Application.Common.Exceptions;
using StockPlatform.Application.Interfaces;
using StockPlatform.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace StockPlatform.Application.StockPlatform.Commands.DeletePhoto
{
    public class DeletePhotoCommandHandler : IRequestHandler<DeletePhotoCommand>
    {
        private readonly IStockPlatformDbContext _dbContext;
        public DeletePhotoCommandHandler(IStockPlatformDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Unit> Handle(DeletePhotoCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Photos
                .FindAsync(new object[] { request.PhotoId }, cancellationToken);
            if (entity == null || entity.PhotoId != request.PhotoId)
            {
                throw new NotFoundException(nameof(Author), request.PhotoId);
            }

            _dbContext.Photos.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
