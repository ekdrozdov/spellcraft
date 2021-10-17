using UnityEngine;

public class VectorSkill
{
  public delegate void ComponentValueUpdateEventHandler(Vector3 value);
  public event ComponentValueUpdateEventHandler ComponentValueUpdateEvent;
  public IVectorProperty Target;
  public IVectorPower Power;

  public VectorSkill(IVectorProperty target, IVectorPower power)
  {
    Target = target;
    Power = power;
  }

  public void Decreace()
  {
    Target.Property -= Power.Value;
    ComponentValueUpdateEvent?.Invoke(Target.Property);
  }

  public void Increace()
  {
    Target.Property += Power.Value;
    ComponentValueUpdateEvent?.Invoke(Target.Property);
  }

  public void DecreacePower()
  {
    Power.Value -= Vector3.one;
    ComponentValueUpdateEvent?.Invoke(Power.Value);
  }

  public void IncreacePower()
  {
    Power.Value += Vector3.one;
    ComponentValueUpdateEvent?.Invoke(Power.Value);
  }
}