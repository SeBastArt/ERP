using System;

namespace ERP.Domain.Requests
{
    public interface IUserContainer
    {
        public UserData User { get; set; }
    }

    public class ReqContainer<T> : IUserContainer
    {
        public ReqContainer(T data)
        {
            Data = data;
            User = new UserData();
        }
        public T Data { get; set; }
        public UserData User { get; set; }
    }

    public class UserData
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
    }
}
