using System;

namespace EpicShop.Core.Infrastructure.Exceptions
{
    public class EntityNotFoundExceptions : Exception
    {
        public EntityNotFoundExceptions():base("Entity not found in the database")
        {
            
        }
    }
}