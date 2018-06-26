namespace DirectWeather.Tests.Core
{
    public abstract class FixtureBase<TElements>
        where TElements : IFixtureElements
    {
        public TElements AssertThat => FixtureElements;

        protected TElements FixtureElements { get; set; }
    }
}