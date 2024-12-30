namespace PlantiaApp.Shared.Components.Authorization.Observer;

using PlantiaApp.Shared.Components.Authorization.Forms;


public interface IObserver
{
    void Update();
}

public interface IObservable
{
    void Subscribe(IObserver observer);
    void UnSubscribe(IObserver observer);
    void Notify();
}

public class SignUpFormObservable : IObservable
{
    private List<IObserver> observers = new List<IObserver>();

    public void Subscribe(IObserver observer)
    {
        observers.Add(observer);
    }

    public void UnSubscribe(IObserver observer)
    {
        observers.Remove(observer);
    }

    public void Notify()
    {
        foreach (var observer in observers)
        {
            observer.Update();
        }
    }
}



public class SignUpFormObserver : IObserver
{
    private readonly SignUpForm _form;
    public SignUpFormObserver(SignUpForm form)
    {
        _form = form;
    }
    public void Update()
    {
        _form.Update();
    }
}
