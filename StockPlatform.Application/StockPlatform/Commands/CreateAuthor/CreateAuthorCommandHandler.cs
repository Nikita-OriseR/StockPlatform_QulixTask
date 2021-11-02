using MediatR;
using StockPlatform.Application.Interfaces;
using StockPlatform.Domain;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StockPlatform.Application.StockPlatform.Commands.CreateAuthor
{
    public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, Guid>
    {
        private readonly IStockPlatformDbContext _dbContext;
        public CreateAuthorCommandHandler(IStockPlatformDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Guid> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = new Author
            {
                AuthorId = request.AuthorId,
                Name = request.Name,
                Nickname = request.Nickname,
                Age = request.Age,
                AccountСreationDate = request.AccountСreationDate
            };

            await _dbContext.Authors.AddAsync(author, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return author.AuthorId;
        }
    }
}