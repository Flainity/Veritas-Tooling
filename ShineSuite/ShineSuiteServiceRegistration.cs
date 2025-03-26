using Microsoft.Extensions.DependencyInjection;
using ShineSuite.DependencyInjection;
using ShineSuite.Factory.Abstate;
using ShineSuite.View.Module;
using ShineSuite.View.Page;
using ShineSuite.View.Startup;
using ShineSuite.ViewModel;

namespace ShineSuite;

public class ShineSuiteServiceRegistration : IServiceRegistration
{
    public void RegisterServices(IServiceCollection services)
    {
        services.AddSingleton<ShineSuiteView>();
        services.AddSingleton<ShineSuiteViewModel>();
        
        services.AddSingleton<StartupWindow>();
        services.AddSingleton<StartupWindowModel>();
        
        services.AddSingleton<WelcomeModuleView>();
        
        services.AddSingleton<SkillModuleView>();
        
        services.AddSingleton<AbstateModuleView>();
        services.AddSingleton<AbstateModuleModel>();
        
        services.AddSingleton<ActionModuleView>();
        services.AddSingleton<ActionModuleModel>();

        services.AddSingleton<SettingsPage>();
        
        services.AddTransient<IAbstateModuleViewFactory, AbstateModuleViewFactory>();
    }
}