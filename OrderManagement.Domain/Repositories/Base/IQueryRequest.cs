using MediatR;

namespace OrderManagement.Domain.Repositories.Base;

public interface IQueryRequest<TResponse> : IRequest<TResponse> { }
public interface IQueryRequest : IRequest { }