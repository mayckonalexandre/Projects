namespace Application.Exceptions;

public class Exceptions
{
    public class NotFoundException(string message) : Exception(message)
    {
    }

    public class NoContentException(string message) : Exception(message)
    {
    }

    public class ConflitException(string message) : Exception(message)
    {
    }

    public class ValidationAppException : Exception
    {
        public Dictionary<string, string[]> Errors { get; }

        public ValidationAppException(Dictionary<string, string[]> errors)
            : base("Validation failed")
        {
            Errors = errors;
        }
    }
}
