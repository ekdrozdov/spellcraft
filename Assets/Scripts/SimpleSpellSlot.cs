using System;
using System.Collections.Generic;
using UnityEngine;

public class SimpleSpellSlot : SimpleObservable<ITargetedProperty>, ISpellSlot
{
  private readonly IPropertyContainer _caster;

  private LinkedList<ITargetedProperty> _targetedProperties = new LinkedList<ITargetedProperty>();

  private LinkedListNode<ITargetedProperty> _node;

  private IMatcher _matcher;

  private NotifierObserver<IObservableProperty> _notifierObserver;

  private IDisposable _targetSub;
  private IDisposable _casterSub;
  private string _lastSelectedPropName = String.Empty;
  private GameObject _target;

  public ITargetedProperty TargetedProperty { get; private set; } = new EmptyTargetedProperty();

  public SimpleSpellSlot(IMatcher matcher, IPropertyContainer caster)
  {
    _matcher = matcher;
    _caster = caster;
    _notifierObserver = new NotifierObserver<IObservableProperty>(PropertyUpdateNofity);
    ClearTarget();
  }

  public void ApplyUpdate(bool isIncrease)
  {
    if (_target == null)
    {
      ClearTarget();
    }
    TargetedProperty.TargetProp.Update((isIncrease ? 1 : -1) * TargetedProperty.CasterProp.Value);
  }

  public void Target(IPropertyContainer target, GameObject go)
  {
    _target = go;
    _targetedProperties = new LinkedList<ITargetedProperty>(_matcher.Match(_caster.ListProperties(), target.ListProperties()));
    if (_targetedProperties.Count == 0)
    {
      _targetedProperties.AddLast(new EmptyTargetedProperty());
    }
    _node = _targetedProperties.First;
    if (_lastSelectedPropName != String.Empty)
    {
      var i = _targetedProperties.First;
      do
      {
        if (i.Value.CasterProp.Name == _lastSelectedPropName)
        {
          _node = i;
          break;
        }
        i = i.Next;
      } while (i != null);
    }
    TargetedProperty = _node.Value;
    UpdateSubscription();
    Notify(TargetedProperty);
  }

  public void TargetNextProperty()
  {
    if (_target == null)
    {
      ClearTarget();
    }
    if (_node.Next == null)
    {
      _node = _targetedProperties.First;
    }
    else
    {
      _node = _node.Next;
    }
    TargetedProperty = _node.Value;
    _lastSelectedPropName = TargetedProperty.CasterProp.Name;
    UpdateSubscription();
    Notify(TargetedProperty);
  }

  public void TargetPrevProperty()
  {
    if (_target == null)
    {
      ClearTarget();
    }
    if (_node.Previous == null)
    {
      _node = _targetedProperties.Last;
    }
    else
    {
      _node = _node.Previous;
    }
    TargetedProperty = _node.Value;
    _lastSelectedPropName = TargetedProperty.CasterProp.Name;
    UpdateSubscription();
    Notify(TargetedProperty);
  }

  public void ClearTarget()
  {
    _targetedProperties = new LinkedList<ITargetedProperty>();
    _targetedProperties.AddLast(new EmptyTargetedProperty());
    _node = _targetedProperties.First;
    TargetedProperty = _node.Value;
    UpdateSubscription();
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