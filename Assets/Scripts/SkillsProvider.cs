using UnityEngine;
using System.Collections.Generic;

public class SkillsProvider : MonoBehaviour
{
  public delegate void SkillsUpdatedEventHandler(List<IRenderable> skills);
  public event SkillsUpdatedEventHandler SkillsUpdatedEvent;
  private Caster _caster;
  private DensitySkill _densitySkill;
  private DurabilitySkill _durabilitySkill;
  private FuelSkill _fuelSkill;
  private HumiditySkill _humiditySkill;
  private MassSkill _massSkill;
  private TemperatureSkill _temperatureSkill;
  private List<IRenderable> _renderableSkills = new List<IRenderable>();

  void Start()
  {
    _caster = gameObject.GetComponentInParent<Caster>();
    _densitySkill = GetComponent<DensitySkill>();
    _durabilitySkill = GetComponent<DurabilitySkill>();
    _fuelSkill = GetComponent<FuelSkill>();
    _humiditySkill = GetComponent<HumiditySkill>();
    _massSkill = GetComponent<MassSkill>();
    _temperatureSkill = GetComponent<TemperatureSkill>();

    _caster.TargetUpdatedEvent += TargetUpdatedHandler;
  }

  public List<IRenderable> GetSkills()
  {
    return _renderableSkills;
  }

  private void TargetUpdatedHandler(GameObject target)
  {
    _renderableSkills.Clear();
    if (_caster.target == null)
    {
      SkillsUpdatedEvent.Invoke(_renderableSkills);
      return;
    }

    var targetDensity = target.GetComponent<Density>();
    if (targetDensity != null && _densitySkill != null)
    {
      _densitySkill.Bind(targetDensity);
      _renderableSkills.Add(_densitySkill);
    }

    var targetDurability = target.GetComponent<Durability>();
    if (targetDurability != null && _durabilitySkill != null)
    {
      _durabilitySkill.Bind(targetDurability);
      _renderableSkills.Add(_durabilitySkill);
    }

    var targetFuel = target.GetComponent<Fuel>();
    if (targetFuel != null && _fuelSkill != null)
    {
      _fuelSkill.Bind(targetFuel);
      _renderableSkills.Add(_fuelSkill);
    }

    var targetHumidity = target.GetComponent<Humidity>();
    if (targetHumidity != null && _humiditySkill != null)
    {
      _humiditySkill.Bind(targetHumidity);
      _renderableSkills.Add(_humiditySkill);
    }

    var targetMass = target.GetComponent<Mass>();
    if (targetMass != null && _massSkill != null)
    {
      _massSkill.Bind(targetMass);
      _renderableSkills.Add(_massSkill);
    }

    var targetTemperature = target.GetComponent<Temperature>();
    if (targetTemperature != null && _temperatureSkill != null)
    {
      _temperatureSkill.Bind(targetTemperature);
      _renderableSkills.Add(_temperatureSkill);
    }

    SkillsUpdatedEvent.Invoke(_renderableSkills);
  }
}