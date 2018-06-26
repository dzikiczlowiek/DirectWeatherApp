namespace DirectWeather.Infrastructure.Mappers
{
    public interface IStringMapper<out TResult> : IMapper<TResult, string>
    {
    }
}