using System;
using System.Collections.Generic;

public interface ISpellSlot : IObservable<ITargetedProperty>
{
    ITargetedProperty TargetedProperty { get; }
    void Target(IPropertyContainer target);
    void ApplyUpdate(bool isIncrease);
    void TargetNextProperty();
    void TargetPrevProperty();
}

public class SimpleSpellSlot : SimpleObservable<ITargetedProperty>, ISpellSlot
{
    private IPropertyContainer _caster;

    private LinkedList<ITargetedProperty> _targetedProperties = new LinkedList<ITargetedProperty>();

    private LinkedListNode<ITargetedProperty> _node;

    private IMatcher _matcher;

    private NotifierObserver<IObservableProperty> _notifierObserver;

    private IDisposable _targetSub;
    private IDisposable _casterSub;

    public ITargetedProperty TargetedProperty { get; private set; } = new EmptyTargetedProperty();

    public SimpleSpellSlot(IMatcher matcher, IPropertyContainer caster)
    {
        Console.WriteLine($"Hello");
        _matcher = matcher;
        _caster = caster;
        _notifierObserver = new NotifierObserver<IObservableProperty>(PropertyUpdateNofity);
    }

    public void ApplyUpdate(bool isIncrease)
    {
        TargetedProperty.TargetProp.Update((isIncrease ? 1 : -1) * TargetedProperty.CasterProp.Value);
    }

    public void Target(IPropertyContainer target)
    {
        _targetedProperties = new LinkedList<ITargetedProperty>(_matcher.Match(_caster.ListProperties(), target.ListProperties()));
        if (_targetedProperties.Count == 0)
        {
            _targetedProperties.AddLast(new EmptyTargetedProperty());
        }
        //print();
        Console.WriteLine($"count {_targetedProperties.Count}");
        _node = _targetedProperties.First;
        TargetedProperty = _node.Value;
        UpdateSubscription();
        Notify(TargetedProperty);
    }

    public void TargetNextProperty()
    {
        if (_node.Next == null)
        {
            _node = _targetedProperties.First;
        }
        else
        {
            _node = _node.Next;
        }
        TargetedProperty = _node.Value;
        UpdateSubscription();
        Notify(TargetedProperty);
    }

    public void TargetPrevProperty()
    {
        if (_node.Previous == null)
        {
            _node = _targetedProperties.Last;
        }
        else
        {
            _node = _node.Previous;
        }
        UpdateSubscription();
        TargetedProperty = _node.Value;
        Notify(TargetedProperty);
    }

    private void PropertyUpdateNofity()
    {
        Notify(TargetedProperty);
    }

    private void UpdateSubscription()
    {
        _targetSub?.Dispose();
        _casterSub?.Dispose();
        _targetSub = TargetedProperty.TargetProp.Subscribe(_notifierObserver);
        _casterSub = TargetedProperty.CasterProp.Subscribe(_notifierObserver);
    }
}