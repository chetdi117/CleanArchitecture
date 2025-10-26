using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Infrastructure.Handlers;
public class ErrorHandlerDecorator<TQuery, TResult> : IRequestHandler<TQuery, TResult>
    where TQuery : IRequest<TResult>
{
    private readonly IRequestHandler<TQuery, TResult> _decorated;
    private readonly ILogger<TQuery> _logger;

    public ErrorHandlerDecorator(ILogger<TQuery> logger,
           IRequestHandler<TQuery, TResult> decorated)
    {
        _logger = logger;
        _decorated = decorated;
    }

    public async Task<TResult> Handle(TQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return await _decorated.Handle(request, cancellationToken);
        }
        catch (Exception e)
        {
            _logger.LogDebug($"Query <{typeof(TQuery)}> get exception, <{ObjectHelper.ToJson(request)}>. Error: {e}");
            Console.WriteLine($"Query <{typeof(TQuery)}> get exception, <{ObjectHelper.ToJson(request)}>. Error: {e}");
        }

        return default!;
    }
}
