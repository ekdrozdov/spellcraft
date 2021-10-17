public class ScalarSkill
{
  public delegate void ComponentValueUpdateEventHandler(float value);
  public event ComponentValueUpdateEventHandler ComponentValueUpdateEvent;
  public IScalarProperty Target;
  public IScalarPower Power;

  public ScalarSkill(IScalarProperty target, IScalarPower power)
  {
    Target = target;
    Power = power;
  }

  public void Decreace()
  {
    Target.Value -= Power.Value;
    ComponentValueUpdateEvent?.Invoke(Target.Value);
  }

  public void Increace()
  {
    Target.Value += Power.Value;
    ComponentValueUpdateEvent?.Invoke(Target.Value);
  }
}