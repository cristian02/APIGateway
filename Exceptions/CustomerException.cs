using System.Net;
namespace GlobalErrorApi.Exceptions;
public class CustomerException : Exception
{
    public string customerMessage { get; set; }
    public HttpStatusCode statusCode { get; set; }
}