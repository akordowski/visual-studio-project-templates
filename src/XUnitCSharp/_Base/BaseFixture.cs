using Microsoft.Extensions.DependencyInjection;

namespace XUnitCSharp;

public abstract class BaseFixture : BaseDisposable
{
    public IServiceCollection Services { get; } = new ServiceCollection();

    private IServiceProvider? _serviceProvider;

    public IServiceProvider GetServiceProvider(ITestOutputHelper? testOutputHelper = null)
    {
        if (_serviceProvider is not null)
        {
            return _serviceProvider;
        }

        AddServices();

        return _serviceProvider = Services.BuildServiceProvider();
    }

    protected virtual void AddServices() { }

    protected override void Cleanup()
    {
        ((ServiceProvider?)_serviceProvider)?.Dispose();
        Services.Clear();
    }
}
