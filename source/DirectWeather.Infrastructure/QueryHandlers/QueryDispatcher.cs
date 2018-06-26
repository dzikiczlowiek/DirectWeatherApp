namespace DirectWeather.Infrastructure.QueryHandlers
{
    using System.Threading.Tasks;

    using Autofac;

    public class QueryDispatcher : IQueryDispatcher
    {
        private readonly ILifetimeScope lifetimeScope;

        public QueryDispatcher(ILifetimeScope lifetimeScope)
        {
            this.lifetimeScope = lifetimeScope;
        }

        public async Task<TResult> ProcessAsync<TResult>(IQuery<TResult> query)
        {
            using (var messageScope = lifetimeScope.BeginLifetimeScope())
            {
                var handlerType = typeof(IQueryHandler<,>).MakeGenericType(query.GetType(), typeof(TResult));
                dynamic handler = messageScope.Resolve(handlerType);
                return await handler.ProcessAsync((dynamic)query);
            }
        }
    }
}