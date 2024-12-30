namespace PlantiaApp.Shared.Core.Events;

using PlantiaApp.Shared.Core.Interfaces;
using PlantiaApp.Shared.Components.Authorization.Interfaces;


public abstract class BaseProducer : IProducer
{
    private List<ISubscriber>? Subscribers;

    public BaseProducer()
    {
        Subscribers = new();
    }

    public void Attach(ISubscriber subscriber)
    {
        Subscribers!.Add(subscriber);
    }

    public void Detach(ISubscriber subscriber)
    {
        Subscribers!.Remove(subscriber);
    }

    public void Notify()
    {
        foreach (var subscriber in Subscribers!)
        {
            subscriber.Update(this);
        }
    }
}

