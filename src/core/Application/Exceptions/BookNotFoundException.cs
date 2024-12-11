using System.Runtime.Serialization;

namespace Application.Exceptions;

[Serializable]
public class BookNotFoundException : Exception
{
    public BookNotFoundException()
    {
    }

    protected BookNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public BookNotFoundException(string? message) : base(message)
    {
    }

    public BookNotFoundException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}