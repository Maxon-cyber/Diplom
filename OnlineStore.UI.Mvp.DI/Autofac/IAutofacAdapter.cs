namespace OnlineStore.UI.Mvp.DI.Autofac;

internal interface IAutofacAdapter
{
    IDIContainer RegisterGeneric<TService>(Lifetime lifetime);

    IDIContainer RegisterGeneric<TService, TImplementation>(Lifetime lifetime)
        where TImplementation : TService;
}