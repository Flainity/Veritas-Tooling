using System.Threading.Tasks;

namespace ShineSuite.DependencyInjection;

public interface IAsyncViewModelFactory
{
    Task<T> CreateAsync<T>() where T : class;
}