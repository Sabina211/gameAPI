using System.Runtime.Serialization;

namespace GameAPI.Domain.Exceptions
{
    public class EntityNotFoundException : Exception, ISerializable
    {
        public EntityNotFoundException(string message = "Не удалось найти объект") : base(message)
        {
        }
    }
}
