using System.Collections.Generic;
using System.Linq;

public interface IMatcher
{
  IEnumerable<ITargetedProperty> ListTargetedProperties();
  IEnumerable<ITargetedProperty> Match(IEnumerable<IObservableProperty> casterProps, IEnumerable<IObservableProperty> targetProps);
}

public class SimpleMatcher : IMatcher
{
  private IEnumerable<SimpleTargetedProperty> _spellContainers;

  public IEnumerable<ITargetedProperty> ListTargetedProperties()
  {
    return _spellContainers;
  }

  public IEnumerable<ITargetedProperty> Match(IEnumerable<IObservableProperty> casterProps, IEnumerable<IObservableProperty> targetProps)
  {
    return _spellContainers = from casterProp in casterProps
                              join targetProp in targetProps on casterProp.Name equals targetProp.Name
                              select new SimpleTargetedProperty(casterProp, targetProp);
  }
}
