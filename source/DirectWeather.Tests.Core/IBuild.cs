namespace DirectWeather.Tests.Core
{
    public interface IBuild<out T>
    {
        T Build();
    }
}