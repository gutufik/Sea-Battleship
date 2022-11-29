using System;
using System.Runtime.Serialization;

namespace Core
{
    /// <summary>
    /// Ошибка при загрузке расстановки кораблей
    /// </summary>
    class LoadingArrangementException : Exception
    {
        public LoadingArrangementException()
        {
        }

        public LoadingArrangementException(string message) : base(message)
        {
        }

        public LoadingArrangementException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected LoadingArrangementException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
