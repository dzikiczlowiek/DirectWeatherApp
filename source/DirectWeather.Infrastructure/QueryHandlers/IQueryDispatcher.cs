namespace DirectWeather.Infrastructure.QueryHandlers
{
    using System.Threading.Tasks;

    public interface IQueryDispatcher
    {
        Task<TResult> ProcessAsync<TResult>(IQuery<TResult> query);
    }
}