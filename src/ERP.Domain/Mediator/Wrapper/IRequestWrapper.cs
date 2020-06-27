using ERP.Domain.Responses;
using MediatR;

namespace ERP.Domain.Mediator.Wrapper
{
    public interface IRequestWrapper<T> : IRequest<RespContainer<T>> { }
    public interface IHandlerWrapper<TIn, TOut> : IRequestHandler<TIn, RespContainer<TOut>> where TIn : IRequestWrapper<TOut> { }
}