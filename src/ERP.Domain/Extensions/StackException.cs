using System;
using System.Collections.Generic;

namespace ERP.Domain.Extensions
{
    /// <summary>
    /// BadRequestException
    /// </summary>
    public class StackException : Exception
    {
        public List<string> Errors { get; set; }

        public StackException() : base()
        {
            Errors = new List<string>();
        }

        public StackException(string message) : base(message)
        {
            Errors = new List<string>();
        }

        public StackException(string message, Exception innerException) : base(message, innerException)
        {
            Errors = new List<string>();
        }
    }
}
