namespace Application.Exceptions;

public class Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message) { }
    }

    public class NoContentException : Exception
    {
        public NoContentException(string message) : base(message) { }
    }
}
