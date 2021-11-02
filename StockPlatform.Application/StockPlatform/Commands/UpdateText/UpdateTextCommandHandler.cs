using MediatR;
using Microsoft.EntityFrameworkCore;
using StockPlatform.Application.Common.Exceptions;
using StockPlatform.Application.Interfaces;
using StockPlatform.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace StockPlatform.Application.StockPlatform.Commands.UpdateText
{
    public class UpdateTextCommandHandler : IRequestHandler<UpdateTextCommand>
    {
        private readonly IStockPlatformDbContext _dbContext;
        public UpdateTextCommandHandler(IStockPlatformDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Unit> Handle(UpdateTextCommand request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Texts.FirstOrDefaultAsync(text =>
                text.TextId == request.TextId, cancellationToken);
            if (entity is null || entity.TextId != request.TextId)
            {
                throw new NotFoundException(nameof(Photo), request.TextId);
            }

            entity.Title = request.Title;
            entity.Content = request.Content;
            entity.Size = request.Size;
            entity.Cost = request.Cost;
            entity.NumberPurchases = request.NumberPurchases;

            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
