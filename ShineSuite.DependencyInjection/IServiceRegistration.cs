using Microsoft.Extensions.DependencyInjection;

namespace ShineSuite.DependencyInjection;

public interface IServiceRegistration
{
    void RegisterServices(IServiceCollection services);
}