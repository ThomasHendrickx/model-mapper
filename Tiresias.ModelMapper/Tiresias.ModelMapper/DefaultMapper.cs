namespace Tiresias.ModelMapper
{
    public class DefaultMapper : IMapper
    {
        public TOut Map<TIn, TOut>(TIn input)
        {
            return Mapper.Config.GetMapping<TIn, TOut>(input);
        }
    }
}