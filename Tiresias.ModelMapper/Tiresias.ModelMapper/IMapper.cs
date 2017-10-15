namespace Tiresias.ModelMapper
{
    public interface IMapper
    {
        TOut Map<TIn, TOut>(TIn input);
    }
}