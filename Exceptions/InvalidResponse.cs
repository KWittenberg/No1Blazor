namespace No1B.Exceptions;

public class InvalidResponse : Exception
{
    public InvalidResponse() : this("Invalid Response")
    {
    }

    public InvalidResponse(string message) : base(message)
    {
    }

    //public InvalidResponse(string message, string details) : base(message, details)
    //{
    //}

    //public InvalidResponse(string details, TmdbErrorModel data) : base(No1DomainErrorCodes.InvalidResponse, "Invalid Response", details)
    //{
    //    WithData("TmdbResponse", data);
    //}
}