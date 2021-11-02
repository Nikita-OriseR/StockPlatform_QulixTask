﻿using MediatR;
using Serilog;
using StockPlatform.Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace StockPlatform.Application.Common.Behaviors
{
    public class LoggingBehavior<TRequest, TResponse>
        : IPipelineBehavior<TRequest, TResponse> where TRequest
        : IRequest<TResponse>
    {
        private ICurrentUserService _currentUserService;

        public LoggingBehavior(ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
        }
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken,
            RequestHandlerDelegate<TResponse> next)
        {
            var requestName = typeof(TRequest).Name;
            var userId = _currentUserService.UserId;

            Log.Information("Notes request: {Name} {@UserId} {@Request}",
                requestName, userId, request);

            var response = await next();
            return response;
        }
    }
}
