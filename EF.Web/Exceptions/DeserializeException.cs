namespace EF.Web.Exceptions
{
    public class DeserializeException : Exception
    {
    
    public DeserializeException(string message)
        : base(message) { message = "Ошибка десериализации!"; }
    }
}