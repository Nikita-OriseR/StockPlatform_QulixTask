using MediatR;
using StockPlatform.Application.Common.Exceptions;
using StockPlatform.Application.Interfaces;
using StockPlatform.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace StockPlatform.Application.StockPlatform.Commands.DeleteText
{
    public class DeleteTextCommandHandler : IRequest<DeleteTextCommand>
    {
        private readonly IStockPlatformDbContext _dbContext;
        public DeleteTextCommandHandler(IStockPlatformDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Unit> Handle(DeleteTextCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Texts
                .FindAsync(new object[] { request.TextId }, cancellationToken);
            if (entity == null || entity.TextId != request.TextId)
            {
                throw new NotFoundException(nameof(Author), request.TextId);
            }

            _dbContext.Texts.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
