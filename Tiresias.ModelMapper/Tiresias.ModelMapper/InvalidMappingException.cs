using System;

namespace Tiresias.ModelMapper
{
    public class InvalidMappingException : Exception
    {
        public InvalidMappingException(string message) 
            : base(message)
        {            
        }

        public InvalidMappingException(string message, Exception innerException) 
            : base(message, innerException)
        {            
        }
    }
}