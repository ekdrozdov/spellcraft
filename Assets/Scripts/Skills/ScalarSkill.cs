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
    Power.Value--;
    ComponentValueUpdateEvent?.Invoke(Power.Value);
  }

  public void IncreacePower()
  {
    Power.Value++;
    ComponentValueUpdateEvent?.Invoke(Power.Value);
  }
}