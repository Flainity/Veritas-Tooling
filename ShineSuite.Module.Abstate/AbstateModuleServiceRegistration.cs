using Microsoft.Extensions.DependencyInjection;
using ShineSuite.DependencyInjection;
using ShineSuite.Module.Abstate.View;
using ShineSuite.Module.Abstate.ViewModel;

namespace ShineSuite.Module.Abstate;

public class AbstateModuleServiceRegistration : IServiceRegistration
{
    public void RegisterServices(IServiceCollection services)
    {
        services.AddScoped<AbstateGeneralView>();
        services.AddSingleton<AbstateGeneralModel>();

        services.AddScoped<AbstateListView>();
        services.AddSingleton<AbstateListModel>();
    }
}