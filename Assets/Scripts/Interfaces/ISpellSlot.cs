using System;

public interface ISpellSlot : IObservable<ITargetedProperty>
{
  ITargetedProperty TargetedProperty { get; }
  void Target(IPropertyContainer target);
  void ClearTarget();
  void ApplyUpdate(bool isIncrease);
  void TargetNextProperty();
  void TargetPrevProperty();
}
