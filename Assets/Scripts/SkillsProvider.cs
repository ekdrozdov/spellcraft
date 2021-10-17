using System.Collections.Generic;
using UnityEngine;

public class SkillsProvider : MonoBehaviour
{
  public delegate void SkillsUpdatedEventHandler(CategorizedSkills skills);
  public event SkillsUpdatedEventHandler SkillsUpdatedEvent;
  public CategorizedSkills _categorizedSkills = new CategorizedSkills();
  private Caster _caster;
  private List<IScalarPower> _scalarPowers;

  void Start()
  {
    _caster = gameObject.GetComponentInParent<Caster>();
    _scalarPowers = new List<IScalarPower>(GetComponents<IScalarPower>());
    _caster.TargetUpdatedEvent += TargetUpdatedHandler;
  }

  private void TargetUpdatedHandler(GameObject target)
  {
    _categorizedSkills.ScalarSkills.Clear();
    _categorizedSkills.MassSkills.Clear();
    if (_caster.target == null)
    {
      SkillsUpdatedEvent?.Invoke(_categorizedSkills);
      return;
    }

    var scalarProperties = new List<IScalarProperty>(target.GetComponents<IScalarProperty>());

    scalarProperties.ForEach(targetProperty =>
    {
      var power = _scalarPowers.Find(power => power.TargetPropertyName == targetProperty.PropertyName);
      if (power != null)
      {
        _categorizedSkills.ScalarSkills.Add(new ScalarSkill(targetProperty, power));
      }
    });

    SkillsUpdatedEvent?.Invoke(_categorizedSkills);
  }
}