using MediatR;

namespace OrderManagement.Domain.Repositories.Base;

public interface ICommand<TResponse> : IRequest<TResponse> { }
public interface ICommand : IRequest { }
