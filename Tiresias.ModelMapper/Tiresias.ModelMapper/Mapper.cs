using System;

namespace Tiresias.ModelMapper
{
    public static class Mapper
    {
        internal static DefaultMapperConfig Config;
        
        public static void Initialize(Action<IMapperConfig> addConfigurationAction)
        {
            if (Config == null)
            {
                Config = new DefaultMapperConfig();
            }
            addConfigurationAction?.Invoke(Config);
        }

        public static TOut Map<TIn, TOut>(TIn input)
        {
            return Config.GetMapping<TIn, TOut>(input);
        }
        
    }
}
 