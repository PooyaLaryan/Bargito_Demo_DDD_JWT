using MediatR;

namespace OrderManagement.Domain.Repositories.Base;

public interface ICommandRequest<TResponse> : IRequest<TResponse> { }
public interface ICommandRequest : IRequest { }
