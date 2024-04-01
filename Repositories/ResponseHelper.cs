using No1B.DTOs;
using No1B.Enums;

namespace No1B.Repositories;

public static class ResponseHelper
{
    public static Response<T> CreateResponse<T>(HttpStatusCode status, string message, T? data)
    {
        return new Response<T> { HttpStatusCode = status, Message = message, Data = data };
    }

    public static Response<T> ErrorResponse<T>(HttpStatusCode status, string message)
    {
        return new Response<T> { HttpStatusCode = status, Message = message };
    }
}