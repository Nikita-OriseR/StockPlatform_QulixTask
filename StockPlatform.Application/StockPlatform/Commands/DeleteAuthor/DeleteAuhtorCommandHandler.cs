using MediatR;
using StockPlatform.Application.Common.Exceptions;
using StockPlatform.Application.Interfaces;
using StockPlatform.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace StockPlatform.Application.StockPlatform.Commands.DeleteAuthor
{
    public class DeleteAuthorCommandHandler : IRequest<DeleteAuthorCommand>
    {
        private readonly IStockPlatformDbContext _dbContext;
        public DeleteAuthorCommandHandler(IStockPlatformDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Unit> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Authors
                .FindAsync(new object[] { request.AuthorId }, cancellationToken);
            if (entity == null || entity.AuthorId != request.AuthorId)
            {
                throw new NotFoundException(nameof(Author), request.AuthorId);
            }

            _dbContext.Authors.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
