using Microsoft.Extensions.DependencyInjection;
using ShineSuite.DependencyInjection;
using ShineSuite.Module.Skill.View;
using ShineSuite.Module.Skill.ViewModel;

namespace ShineSuite.Module.Skill;

public class SkillModuleServiceRegistration : IServiceRegistration
{
    public void RegisterServices(IServiceCollection services)
    {
        services.AddTransient<ActiveSkillListView>();
        services.AddTransient<ActiveSkillListViewModel>();

        services.AddTransient<ActiveSkillGeneralView>();
        services.AddTransient<ActiveSkillGeneralViewModel>();

        services.AddTransient<ActiveSkillStepView>();
        services.AddTransient<ActiveSkillStepModel>();
    }
}