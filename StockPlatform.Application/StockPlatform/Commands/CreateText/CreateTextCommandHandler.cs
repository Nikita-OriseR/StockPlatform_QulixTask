using MediatR;
using StockPlatform.Application.Interfaces;
using StockPlatform.Domain;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StockPlatform.Application.StockPlatform.Commands.CreateText
{
    public class CreateTextCommandHandler : IRequestHandler<CreateTextCommand, Guid>
    {
        private readonly IStockPlatformDbContext _dbContext;
        public CreateTextCommandHandler(IStockPlatformDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Guid> Handle(CreateTextCommand request, CancellationToken cancellationToken)
        {
            var text = new Text
            {
                TextId = request.TextId,
                Title = request.Title,
                Content = request.Content,
                Size = request.Size,
                CreationDate = request.CreationDate,
                Cost = request.Cost,
                Author = request.Author,
                NumberPurchases = request.NumberPurchases
            };

            await _dbContext.Texts.AddAsync(text, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return text.TextId;
        }
    }
}
