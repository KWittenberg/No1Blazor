using No1B.Enums;

namespace No1B.DTOs;

public class Response<T>
{
    public HttpStatusCode HttpStatusCode { get; set; }

    public string Message { get; set; } = string.Empty;

    public T? Data { get; set; }
}