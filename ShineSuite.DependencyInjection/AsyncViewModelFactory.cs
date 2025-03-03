using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace ShineSuite.DependencyInjection;

public class AsyncViewModelFactory(IServiceProvider serviceProvider) : IAsyncViewModelFactory
{
    public async Task<T> CreateAsync<T>() where T : class
    {
        // Hole das ViewModel über den ServiceProvider
        var viewModel = serviceProvider.GetRequiredService<T>();

        if (viewModel is IAsyncInitializable asyncInitializable)
        {
            // Initialisiere das ViewModel asynchron, falls es die IAsyncInitializable-Schnittstelle implementiert
            await asyncInitializable.InitializeAsync();
        }

        return viewModel;
    }
}