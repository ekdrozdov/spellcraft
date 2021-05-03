using System;
using UnityEngine;

public interface ISpellSlot : IObservable<ITargetedProperty>
{
  ITargetedProperty TargetedProperty { get; }
  void Target(IPropertyContainer target, GameObject go);
  void ClearTarget();
  void ApplyUpdate(bool isIncrease);
  void TargetNextProperty();
  void TargetPrevProperty();
}
