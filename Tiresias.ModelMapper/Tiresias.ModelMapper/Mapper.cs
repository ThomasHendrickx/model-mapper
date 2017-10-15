using System;

namespace Tiresias.ModelMapper
{
    public static class Mapper
    {
        private static IMapperConfig _config;
        
        public static void Initialize(Action<IMapperConfig> addConfigurationAction)
        {
            _config = new DefaultMapperConfig();
            addConfigurationAction?.Invoke(_config);
        }
    }
}