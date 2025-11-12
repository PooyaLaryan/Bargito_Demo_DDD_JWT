using MediatR;

namespace OrderManagement.Domain.Repositories.Base;

public interface IQuery<TResponse> : IRequest<TResponse> { }