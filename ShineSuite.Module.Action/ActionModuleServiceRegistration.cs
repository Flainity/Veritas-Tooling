using Microsoft.Extensions.DependencyInjection;
using ShineSuite.DependencyInjection;
using ShineSuite.Module.Action.View;
using ShineSuite.Module.Action.ViewModel;

namespace ShineSuite.Module.Action;

public class ActionModuleServiceRegistration : IServiceRegistration
{
    public void RegisterServices(IServiceCollection services)
    {
        services.AddSingleton<ActionListView>();
        services.AddSingleton<ActionListModel>();

        services.AddTransient<ActionEditorView>();
        services.AddTransient<ActionEditorModel>();

        services.AddTransient<ActionPairView>();
        services.AddTransient<ActionPairModel>();
    }
}