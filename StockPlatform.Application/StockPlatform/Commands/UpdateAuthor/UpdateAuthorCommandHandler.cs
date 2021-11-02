using MediatR;
using Microsoft.EntityFrameworkCore;
using StockPlatform.Application.Common.Exceptions;
using StockPlatform.Application.Interfaces;
using StockPlatform.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace StockPlatform.Application.StockPlatform.Commands.UpdateAuthor
{
    class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand>
    {
        private readonly IStockPlatformDbContext _dbContext;
        public UpdateAuthorCommandHandler(IStockPlatformDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Unit> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Authors.FirstOrDefaultAsync(author =>
                author.AuthorId == request.AuthorId, cancellationToken);
            if (entity == null || entity.AuthorId != request.AuthorId)
            {
                throw new NotFoundException(nameof(Author), request.AuthorId);
            }

            entity.Name = request.Name;
            entity.Nickname = request.Nickname;
            entity.Age = request.Age;

            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
