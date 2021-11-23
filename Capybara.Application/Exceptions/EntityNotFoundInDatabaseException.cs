using System;

namespace Capybara.Application.Exceptions
{
    public class EntityNotFoundInDatabaseException : Exception
    {
        private const string message = "Entity cannot be found in database";

        public EntityNotFoundInDatabaseException()
            : base(message)
        {
        }

        public EntityNotFoundInDatabaseException(Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
