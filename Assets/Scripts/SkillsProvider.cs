using System.Collections.Generic;
using UnityEngine;

public class SkillsProvider : MonoBehaviour
{
  public delegate void SkillsUpdatedEventHandler(CategorizedSkills skills);
  public event SkillsUpdatedEventHandler SkillsUpdatedEvent;
  public CategorizedSkills _categorizedSkills = new CategorizedSkills();
  private Caster _caster;
  private List<IScalarPower> _scalarPowers;
  private List<IMassPower> _massPowers;
  private List<IVectorPower> _vectorPowers;

  void Start()
  {
    _caster = gameObject.GetComponentInParent<Caster>();
    _scalarPowers = new List<IScalarPower>(GetComponents<IScalarPower>());
    _massPowers = new List<IMassPower>(GetComponents<IMassPower>());
    _vectorPowers = new List<IVectorPower>(GetComponents<IVectorPower>());
    _caster.TargetUpdatedEvent += TargetUpdatedHandler;
  }

  private void TargetUpdatedHandler(GameObject target)
  {
    _categorizedSkills.ScalarSkills.Clear();
    _categorizedSkills.MassSkills.Clear();
    _categorizedSkills.VectorSkills.Clear();

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

    var massProperties = new List<IMassProperty>(target.GetComponents<IMassProperty>());
    massProperties.ForEach(targetProperty =>
    {
      var power = _massPowers.Find(power => power.TargetPropertyName == targetProperty.PropertyName);
      if (power != null)
      {
        _categorizedSkills.MassSkills.Add(new MassSkill(targetProperty, power));
      }
    });

    var vectorProperties = new List<IVectorProperty>(target.GetComponents<IVectorProperty>());
    vectorProperties.ForEach(targetProperty =>
    {
      var power = _vectorPowers.Find(power => power.TargetPropertyName == targetProperty.PropertyName);
      if (power != null)
      {
        _categorizedSkills.VectorSkills.Add(new VectorSkill(targetProperty, power));
      }
    });

    SkillsUpdatedEvent?.Invoke(_categorizedSkills);
  }
}