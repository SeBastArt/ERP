namespace ERP.Domain.Responses
{
    public static class RespContainer
    {
        //default for integers
        public static RespContainer<T> Fail<T>(T data = default, string message = "")
        {
            return new RespContainer<T>(data, true, message);
        }

        public static RespContainer<T> Ok<T>(T data = default, string message = "")
        {
            return new RespContainer<T>(data, false, message);
        }
    }

    public class RespContainer<T>
    {
        public RespContainer(T data, bool error, string msg = "")
        {
            Data = data;
            Messages = msg;
            Error = error;
        }
        public T Data { get; set; }
        public string Messages { get; set; }
        public bool Error { get; set; }
    }
}
