using System;

namespace Tiresias.ModelMapper
{
    internal class DefaultMapperConfig : IMapperConfig    
    {
        public void AddMapping<TIn, TOut>(Func<TIn, TOut> mappingFunc)
        {
            throw new NotImplementedException();
        }

        public bool ContainsMappingFor<TIn, TOut>()
        {
            throw new NotImplementedException();
        }
    }
}