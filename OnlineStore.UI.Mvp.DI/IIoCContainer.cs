using System.Linq.Expressions;

namespace OnlineStore.UI.Mvp.DI;

public interface IIoCContainer
{
    IIoCContainer Register<TService>(Lifetime lifetime = Lifetime.Transient, bool asSelf = false);

    IIoCContainer RegisterWithConstructor<TService>(string nameParameter, object parameter, Lifetime lifetime = Lifetime.Transient, bool asSelf = false);

    IIoCContainer Register<TService>(Action<TService> action, Lifetime lifetime = Lifetime.Transient, bool asSelf = false);
    
    IIoCContainer Register<TService, TArgument>(Expression<Func<TArgument, TService>> factory, Lifetime lifetime = Lifetime.Transient, bool asSelf = false);

    IIoCContainer RegisterGeneric<TService, TImplementation>(Lifetime lifetime = Lifetime.Transient, bool asSelf = false)
        where TImplementation : TService;

    IIoCContainer RegisterInstance<TInstance>(TInstance instance, Lifetime lifetime = Lifetime.Transient, bool asSelf = false)
        where TInstance : class;

    IIoCContainer RegisterGenericDecorator(Type service, Type implementation, bool asSelf = false);

    IIoCContainer RegisterView<TView, TImplementation>(Lifetime lifetime = Lifetime.Transient, bool asSelf = false)
        where TImplementation : TView;

    IIoCContainer Register<TService, TImplementation>(Lifetime lifetime = Lifetime.Transient, bool asSelf = false)
        where TImplementation : TService;

    TService Resolve<TService>();

    void Build();
}