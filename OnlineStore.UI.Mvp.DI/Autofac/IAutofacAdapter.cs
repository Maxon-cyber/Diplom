namespace OnlineStore.UI.Mvp.DI.Autofac;

internal interface IAutofacAdapter
{
    IIoCContainer RegisterGeneric<TService>(Lifetime lifetime);

    IIoCContainer RegisterGeneric<TService, TImplementation>(Lifetime lifetime)
        where TImplementation : TService;
}