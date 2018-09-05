using System;

class ButtonObservableContent : Avalonia.Reactive.AvaloniaObservable<object>
{
    public ButtonObservableContent(Func<IObserver<object>, IDisposable> subscribe, string description) : base(subscribe, description)
    {

    }

    public override bool Equals(object obj)
    {
        return base.Equals(obj);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public override string ToString()
    {
        return base.ToString();
    }

    protected override IDisposable SubscribeCore(IObserver<object> observer)
    {
        return base.SubscribeCore(observer);
    }
}