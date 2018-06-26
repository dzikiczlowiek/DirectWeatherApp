namespace DirectWeather.Infrastructure.QueryHandlers
{
    using System.Threading.Tasks;

    public interface IQueryHandler<in TQuery, TResult>
        where TQuery : IQuery<TResult>
    {
        Task<TResult> ProcessAsync(TQuery query);
    }
}