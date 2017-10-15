using System;

namespace Tiresias.ModelMapper
{
    public interface IMapperConfig
    {
        void AddMapping<TIn, TOut>(Func<TIn, TOut> mappingFunc);
        bool ContainsMappingFor<TIn, TOut>();
    }
}