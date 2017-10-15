using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace Tiresias.ModelMapper
{
    internal class DefaultMapperConfig : IMapperConfig
    {
        private readonly ConcurrentDictionary<Type, List<IMappingConfig>> _mappings =
            new ConcurrentDictionary<Type, List<IMappingConfig>>();

        public void AddMapping<TIn, TOut>(Func<TIn, TOut> mappingFunc)
        {
            var mapping = new Mapping<TIn, TOut>(mappingFunc);
            var mappingAlreadyAdded = false;
            _mappings.AddOrUpdate(
                typeof(TIn),
                type => new List<IMappingConfig> {mapping},
                (type, list) =>
                {
                    if (list.Any(map => mapping.OutType == typeof(TOut)))
                    {
                        mappingAlreadyAdded = true;
                    }
                    else
                    {
                        list.Add(mapping);
                    }
                    return list;
                });
            if (mappingAlreadyAdded)
            {
                throw new InvalidMappingException(
                    $"There already is a mapping added with {typeof(TIn)} as input and {typeof(TOut)} as output");
            }
        }

        public bool ContainsMappingFor<TIn, TOut>()
        {
            return _mappings.TryGetValue(typeof(TIn), out var configs) &&
                   configs.Any(map => map.OutType == typeof(TOut));
        }

        public TOut GetMapping<TIn, TOut>(TIn input)
        {
            if (!_mappings.TryGetValue(typeof(TIn), out var list))
            {
                throw new InvalidMappingException(
                    $"No mapping found with {typeof(TIn)} as input and {typeof(TOut)} as output");
            }
            var mapping = list.FirstOrDefault(map => map.OutType == typeof(TOut));
            if (mapping == null)
            {
                throw new InvalidMappingException(
                    $"No mapping found with {typeof(TIn)} as input and {typeof(TOut)} as output");
            }
            return ((Mapping<TIn, TOut>) mapping).Map(input);
        }
    }

    internal interface IMappingConfig
    {
        Type InType { get; }
        Type OutType { get; }
    }

    internal class Mapping<TIn, TOut> : IMappingConfig
    {
        private readonly Func<TIn, TOut> _mapping;
        public Type InType { get; }
        public Type OutType { get; }

        public Mapping(Func<TIn, TOut> mapping)
        {
            _mapping = mapping;
            InType = typeof(TIn);
            OutType = typeof(TOut);
        }

        public TOut Map(TIn source)
        {
            return _mapping.Invoke(source);
        }
    }
}