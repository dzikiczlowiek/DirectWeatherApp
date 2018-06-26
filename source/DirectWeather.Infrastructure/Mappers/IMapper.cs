namespace DirectWeather.Infrastructure.Mappers
{
    public interface IMapper<out TResult, in TSource>
    {
        TResult Map(TSource source);
    }
}