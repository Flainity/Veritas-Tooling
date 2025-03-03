using System;
using System.Linq;
using System.Reflection;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ShineSuite.DependencyInjection;
using ShineSuite.Factory.Abstate;
using ShineSuite.Module.Abstate.View;
using ShineSuite.Module.Abstate.ViewModel;
using ShineSuite.View.Module;
using ShineSuite.View.Startup;
using ShineSuite.ViewModel;

namespace ShineSuite
{
    public partial class App : Application
    {
        public static IServiceProvider ServiceProvider { get; private set; }
        
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var builder = new HostBuilder()
                .ConfigureServices((ctx, services) =>
                {
                    var localRegistrations = Assembly.GetExecutingAssembly()
                        .GetTypes()
                        .Where(t => typeof(IServiceRegistration).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract)
                        .Select(Activator.CreateInstance)
                        .Cast<IServiceRegistration>();

                    foreach (var serviceRegistration in localRegistrations)
                    {
                        serviceRegistration.RegisterServices(services);
                    }
                    
                    var serviceRegistrations = Assembly.GetExecutingAssembly()
                        .GetReferencedAssemblies()
                        .Select(Assembly.Load)
                        .SelectMany(a => a.GetTypes())
                        .Where(t => typeof(IServiceRegistration).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract)
                        .Select(Activator.CreateInstance)
                        .Cast<IServiceRegistration>();

                    foreach (var serviceRegistration in serviceRegistrations)
                    {
                        serviceRegistration.RegisterServices(services);
                    }
                });

            var host = builder.Build();
            ServiceProvider = host.Services;
            
            var mainWindow = ServiceProvider.GetRequiredService<StartupWindow>();
            mainWindow.Show();
        }
        
        public static TEnum GetEnum<TEnum>(string text) where TEnum : struct
        {
            if (!typeof(TEnum).GetTypeInfo().IsEnum)
            {
                throw new InvalidOperationException("Generic parameter 'TEnum' must be an enum.");
            }
            return (TEnum)Enum.Parse(typeof(TEnum), text);
        }
    }
}