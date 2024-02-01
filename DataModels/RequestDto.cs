namespace Fundify_API.DataModels
{
    public class RequestDto
    {

        public bool Succeeded { get; protected set; }
        public string? Message { get; protected set; } = string.Empty;
        public object? Result { get; protected set; } = null;

        public static RequestDto Success(string Message)
        {
            var result = new RequestDto { Succeeded = true, Message = Message };
            return result;
        }

        public static RequestDto Success(string Message, object? Result)
        {
            var result = new RequestDto { Succeeded = true, Message = Message, Result = Result };
            return result;
        }

        public static RequestDto Failed(string Message)
        {
            var result = new RequestDto { Succeeded = false, Message = Message };
            return result;
        }
    }
}
