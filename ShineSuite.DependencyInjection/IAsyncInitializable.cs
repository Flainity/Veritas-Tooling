using System.Threading.Tasks;

namespace ShineSuite.DependencyInjection;

public interface IAsyncInitializable
{
    Task InitializeAsync();
}