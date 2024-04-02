using System.Linq.Expressions;

namespace OnlineStore.UI.Mvp.DI;

public interface IDIContainer
{
    IDIContainer Register<TService>(Lifetime lifetime = Lifetime.Transient, bool asSelf = false);

    IDIContainer RegisterWithConstructor<TService>(string nameParameter, object parameter, Lifetime lifetime = Lifetime.Transient, bool asSelf = false);

    IDIContainer Register<TService>(Action<TService> action, Lifetime lifetime = Lifetime.Transient, bool asSelf = false);
    
    IDIContainer Register<TService, TArgument>(Expression<Func<TArgument, TService>> factory, Lifetime lifetime = Lifetime.Transient, bool asSelf = false);

    IDIContainer RegisterGeneric<TService, TImplementation>(Lifetime lifetime = Lifetime.Transient, bool asSelf = false)
        where TImplementation : TService;

    IDIContainer RegisterInstance<TInstance>(TInstance instance, Lifetime lifetime = Lifetime.Transient, bool asSelf = false)
        where TInstance : class;

    IDIContainer RegisterGenericDecorator(Type service, Type implementation, bool asSelf = false);

    IDIContainer RegisterView<TView, TImplementation>(Lifetime lifetime = Lifetime.Transient, bool asSelf = false)
        where TImplementation : TView;

    IDIContainer Register<TService, TImplementation>(Lifetime lifetime = Lifetime.Transient, bool asSelf = false)
        where TImplementation : TService;

    TService Resolve<TService>();

    void Build();
}