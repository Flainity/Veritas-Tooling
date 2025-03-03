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
        services.AddTransient<ShineSuiteView>();
        services.AddTransient<ShineSuiteViewModel>();
        
        services.AddSingleton<StartupWindow>();
        services.AddSingleton<StartupWindowModel>();
        
        services.AddTransient<WelcomeModuleView>();
        
        services.AddTransient<SkillModuleView>();
        
        services.AddTransient<AbstateModuleView>();
        services.AddTransient<AbstateModuleModel>();
        
        services.AddTransient<ActionModuleView>();
        services.AddTransient<ActionModuleModel>();

        services.AddSingleton<SettingsPage>();
        
        services.AddTransient<IAbstateModuleViewFactory, AbstateModuleViewFactory>();
    }
}