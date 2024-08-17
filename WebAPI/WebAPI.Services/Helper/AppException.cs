using System.Runtime.Serialization;

namespace WebAPI.Services
{
    [Serializable]
    public class AppException : System.Exception
    {
        public AppException(string message) : base(message)
        {
            Console.WriteLine(message);
        }

        public AppException(string message, System.Exception innerException) : base(message, innerException)
        {
            Console.WriteLine(message);
        }

        public AppException()
        {
        }

        protected AppException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}