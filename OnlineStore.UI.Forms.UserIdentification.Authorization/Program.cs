using Microsoft.Extensions.Configuration;
using OnlineStore.DataAccess;
using OnlineStore.DataAccess.Providers.Relational.Abstractions.Models;
using OnlineStore.Service;
using OnlineStore.UI.Forms.MainWindow;
using OnlineStore.UI.Forms.MainWindow.Tabs.ProductShowcase;
using OnlineStore.UI.Forms.MainWindow.Tabs.ShoppingCard;
using OnlineStore.UI.Forms.MainWindow.Tabs.UserAccount;
using OnlineStore.UI.Forms.UserIdentification.Registration;
using OnlineStore.UI.Mvp.Configuration.Microsoft;
using OnlineStore.UI.Mvp.Controller;
using OnlineStore.UI.Mvp.DI;
using OnlineStore.UI.Mvp.DI.Autofac;
using OnlineStore.UI.Mvp.Presenters.MainWindow;
using OnlineStore.UI.Mvp.Presenters.MainWindow.Tabs;
using OnlineStore.UI.Mvp.Presenters.UserIdentification;
using OnlineStore.UI.Mvp.Views.MainWindow;
using OnlineStore.UI.Mvp.Views.MainWindow.Tabs;
using OnlineStore.UI.Mvp.Views.UserIdentification;

namespace OnlineStore.UI.Forms.UserIdentification.Authorization;

internal static class Program
{
    private static readonly ApplicationContext _context = new ApplicationContext();

    [STAThread]
    private static void Main()
    {
        ApplicationConfiguration.Initialize();

        Application.SetCompatibleTextRenderingDefault(false);

        ApplicationController applicationController = new ApplicationController(new AutofacAdapter(), new MicrosoftConfiguration());
        applicationController.Configuration.SetBasePath(Directory.GetCurrentDirectory())
                                           .AddFile("configuration.yml", true, false)
                                           .AddEnviromentVariables()
                                           .Build();

        IConfigurationSection sqlServer = applicationController.Configuration.Root.GetSection("Databases:SqlServer");

        IDictionary<string, ConnectionParameters> parametersOfAllDatabases = new Dictionary<string, ConnectionParameters>
        {
            {
                sqlServer.Key,
                new ConnectionParameters()
                {
                    Provider = sqlServer.Key,
                    Server = sqlServer.GetSection("Server").Value!,
                    Port = Convert.ToInt32(sqlServer.GetSection("Port").Value),
                    Database = sqlServer.GetSection("Database").Value!,
                    IntegratedSecurity = Convert.ToBoolean(sqlServer.GetSection("IntegratedSecurity").Value),
                    Username = sqlServer.GetSection("Username").Value,
                    Password = sqlServer.GetSection("Password").Value,
                    TrustedConnection = Convert.ToBoolean(sqlServer.GetSection("TrustedConnection").Value),
                    TrustServerCertificate = Convert.ToBoolean(sqlServer.GetSection("TrustServerCertificate").Value),
                    ConnectionTimeout = TimeSpan.Parse(sqlServer.GetSection("ConnectionTimeout").Value!),
                    MaxPoolSize = Convert.ToInt32(sqlServer.GetSection("MaxPoolSize").Value)
                }
            },
        };

        applicationController.Container.Register<AuthorizationPresenter>(Lifetime.Singleton, asSelf: true)
                                       .Register<RegistrationPresenter>(Lifetime.Singleton, asSelf: true)
                                       .Register<MainWindowPresenter>(Lifetime.Singleton, asSelf: true)
                                       .Register<ShoppingCartPresenter>(Lifetime.Singleton, asSelf: true)
                                       .Register<ProductShowcasePresenter>(Lifetime.Singleton, asSelf: true)
                                       .Register<UserAccountPresenter>(Lifetime.Singleton, asSelf: true)
                                       .RegisterView<IAuthorizationView, AuthorizationForm>(Lifetime.Singleton)
                                       .RegisterView<IRegistrationView, RegistrationControl>()
                                       .RegisterView<IMainWindowView, MainWindowForm>(Lifetime.Singleton)
                                       .RegisterView<IUserAccountView, UserAccountControl>(Lifetime.Singleton)
                                       .RegisterView<IProductShowcaseView, ProductShowcaseControl>(Lifetime.Singleton)
                                       .RegisterView<IShoppingCartView, ShoppngCartControl>(Lifetime.Singleton)
                                       .RegisterWithConstructor<DatabaseFacade>(nameof(parametersOfAllDatabases), parametersOfAllDatabases, Lifetime.Singleton)
                                       .Register<ServiceFacade>()
                                       .RegisterInstance(_context, Lifetime.Singleton)
                                       .RegisterInstance<IApplicationController>(applicationController)
                                       .Build();

        applicationController.Run<AuthorizationPresenter>();
    }
}