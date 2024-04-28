using Autofac;
using System.Linq.Expressions;

namespace OnlineStore.UI.Mvp.DI.Autofac;

public sealed class AutofacAdapter : IIoCContainer
{
    private readonly ContainerBuilder _containerBuilder;
    private IContainer _container;

    public AutofacAdapter()
        => _containerBuilder = new ContainerBuilder();

    public IIoCContainer Register<TService>(Lifetime lifetime = Lifetime.Transient, bool asSelf = false)
    {
        switch (lifetime)
        {
            case Lifetime.Transient:
                _containerBuilder.RegisterType<TService>().Named<TService>($"{nameof(TService)}")
                    .AsSelf();
                break;
            case Lifetime.Singleton:
                _containerBuilder.RegisterType<TService>().Named<TService>($"{nameof(TService)}")
                    .AsSelf()
                    .SingleInstance();
                break;
        }

        return this;
    }

    public IIoCContainer RegisterWithConstructor<TService>(string nameParameter, object parameter, Lifetime lifetime = Lifetime.Transient, bool asSelf = false)
    {
        switch (lifetime)
        {
            case Lifetime.Transient:
                _containerBuilder.RegisterType<TService>().Named<TService>($"{nameof(TService)}")
                    .AsSelf()
                    .WithParameter(nameParameter, parameter);
                break;
            case Lifetime.Singleton:
                _containerBuilder.RegisterType<TService>().Named<TService>($"{nameof(TService)}")
                    .AsSelf()
                    .SingleInstance()
                    .WithParameter(nameParameter, parameter);
                break;
        }

        return this;
    }

    public IIoCContainer Register<TService, TImplementation>(Lifetime lifetime = Lifetime.Transient, bool asSelf = false)
        where TImplementation : TService
    {
        switch (lifetime)
        {
            case Lifetime.Transient:
                _containerBuilder.RegisterType<TImplementation>().Named<TImplementation>($"{nameof(TService)} - {nameof(TImplementation)}")
                    .AsSelf()
                    .As<TService>();
                break;
            case Lifetime.Singleton:
                _containerBuilder.RegisterType<TImplementation>().Named<TImplementation>($"{nameof(TService)} - {nameof(TImplementation)}")
                    .AsSelf()
                    .As<TService>()
                    .SingleInstance();
                break;
        }

        return this;
    }

    public IIoCContainer Register<TService>(Action<TService> action, Lifetime lifetime, bool asSelf = false)
    {
        switch (lifetime)
        {
            case Lifetime.Transient:
                _containerBuilder.RegisterType<TService>().Named<TService>($"{nameof(TService)}")
                    .AsSelf();
                break;
            case Lifetime.Singleton:
                _containerBuilder.RegisterType<TService>().Named<TService>($"{nameof(TService)}")
                    .AsSelf()
                    .SingleInstance();
                break;
        }

        return this;
    }

    public IIoCContainer Register<TService, TArgument>(Expression<Func<TArgument, TService>> factory, Lifetime lifetime = Lifetime.Transient, bool asSelf = false)
    {
        switch (lifetime)
        {
            case Lifetime.Transient:
                _containerBuilder.Register(serviceFacotry => factory).Named<TService>($"Func {nameof(TService)} - {nameof(TArgument)}")
                    .AsSelf();
                break;
            case Lifetime.Singleton:
                _containerBuilder.Register(service => factory).Named<TService>($"Func {nameof(TService)} - {nameof(TArgument)}")
                    .AsSelf()
                    .SingleInstance();
                break;
        }

        return this;
    }

    public IIoCContainer RegisterGeneric<TService>(Lifetime lifetime = Lifetime.Transient, bool asSelf = false)
    {
        switch (lifetime)
        {
            case Lifetime.Transient:
                _containerBuilder.RegisterGeneric(typeof(TService)).Named<TService>($"{nameof(TService)}")
                    .AsSelf();
                break;
            case Lifetime.Singleton:
                _containerBuilder.RegisterGeneric(typeof(TService)).Named<TService>($"{nameof(TService)}")
                    .AsSelf()
                    .SingleInstance();
                break;
        }

        return this;
    }

    public IIoCContainer RegisterGeneric<TService, TImplementation>(Lifetime lifetime = Lifetime.Transient, bool asSelf = false)
        where TImplementation : TService
    {
        switch (lifetime)
        {
            case Lifetime.Transient:
                _containerBuilder.RegisterGeneric(typeof(TImplementation)).Named<TService>($"{nameof(TService)} - {nameof(TImplementation)}")
                    .AsSelf();
                break;
            case Lifetime.Singleton:
                _containerBuilder.RegisterGeneric(typeof(TImplementation)).Named<TService>($"{nameof(TService)} - {nameof(TImplementation)}")
                    .AsSelf()
                    .As<TService>()
                    .SingleInstance();
                break;
        }

        return this;
    }

    public IIoCContainer RegisterInstance<TInstance>(TInstance instance, Lifetime lifetime = Lifetime.Transient, bool asSelf = false)
        where TInstance : class
    {
        switch (lifetime)
        {
            case Lifetime.Transient:
                _containerBuilder.RegisterInstance(instance).Named<TInstance>($"{nameof(TInstance)}")
                    .As<TInstance>();
                break;
            case Lifetime.Singleton:
                _containerBuilder.RegisterInstance(instance).Named<TInstance>($"{nameof(TInstance)}")
                    .As<TInstance>()
                    .SingleInstance();
                break;
        }

        return this;
    }

    public IIoCContainer RegisterView<TView, TImplementation>(Lifetime lifetime = Lifetime.Transient, bool asSelf = false)
        where TImplementation : TView
    {
        switch (lifetime)
        {
            case Lifetime.Transient:
                _containerBuilder.RegisterType<TImplementation>().Named<TImplementation>($"{nameof(TView)} - {nameof(TImplementation)}")
                    .As<TView>()
                    .AsSelf()
                    .InstancePerDependency();
                break;
            case Lifetime.Singleton:
                _containerBuilder.RegisterType<TImplementation>().Named<TImplementation>($"{nameof(TView)} - {nameof(TImplementation)}")
                    .As<TView>()
                    .AsSelf()
                    .SingleInstance();
                break;
        }

        return this;
    }

    public TService Resolve<TService>()
    {
        using ILifetimeScope lifetimeScope = _container.BeginLifetimeScope();

        if (!lifetimeScope.IsRegistered<TService>())
            throw new ArgumentNullException($"{typeof(TService)} не зарегистрирован");

        var g = lifetimeScope.Resolve<TService>();

        return g;
    }

    public void Build()
        => _container = _containerBuilder.Build();

    public IIoCContainer RegisterGenericDecorator(Type service, Type implementation, bool asSelf = false)
    {
        _containerBuilder.RegisterGenericDecorator(service, implementation);

        return this;
    }
}