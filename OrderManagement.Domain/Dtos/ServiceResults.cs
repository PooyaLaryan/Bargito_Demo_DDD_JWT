namespace OrderManagement.Domain.Dtos;

public class ServiceResults<T>
{
    public T? Data { get; set; }
    public string? ErrorMessage { get; set; }

    public static ServiceResults<T> Success(T data) => new() { Data = data };
    public static ServiceResults<T> Fail(string error) => new() { ErrorMessage = error };
}
