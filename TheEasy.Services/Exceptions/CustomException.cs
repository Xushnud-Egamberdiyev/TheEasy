namespace TheEasy.Services.Exceptions;

public class CustomException : Exception
{
    public int stutusCode { get; set; }

    public CustomException(int code, string message)
    {
        this.stutusCode = code;
    }
}
