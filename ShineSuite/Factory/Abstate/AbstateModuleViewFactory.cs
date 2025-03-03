using System;
using Microsoft.Extensions.DependencyInjection;
using ShineSuite.View.Module;

namespace ShineSuite.Factory.Abstate;

public class AbstateModuleViewFactory : IAbstateModuleViewFactory
{
    public AbstateModuleView Create()
    {
        return App.ServiceProvider.GetRequiredService<AbstateModuleView>();
    }
}