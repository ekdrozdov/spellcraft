using UnityEngine;

public class MassSkill
{
  public delegate void ComponentValueUpdateEventHandler(float value);
  public event ComponentValueUpdateEventHandler ComponentValueUpdateEvent;
  public IMassProperty Target;
  public IMassPower Power;

  public MassSkill(IMassProperty target, IMassPower power)
  {
    Target = target;
    Power = power;
  }

  public void DecreacePower()
  {
    Power.Value--;
    ComponentValueUpdateEvent?.Invoke(Power.Value);
  }

  public void IncreacePower()
  {
    Power.Value++;
    ComponentValueUpdateEvent?.Invoke(Power.Value);
  }

  public void Push()
  {
    Target.RelativeImpulse(Power.Value, Power.position);
  }

  public void Pull()
  {
    Target.RelativeImpulse(-Power.Value, Power.position);
  }

  public void Toss()
  {
    Target.AbsoluteImpulse(Power.Value, Vector3.up);
  }
}