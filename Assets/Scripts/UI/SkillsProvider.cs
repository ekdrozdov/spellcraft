using UnityEngine;

public class SkillsProvider : MonoBehaviour
{
  // private MassSkill _massSkill;
  private DensitySkill _densitySkill;
  void Start()
  {
    // _massSkill = GetComponent<MassSkill>();
    _densitySkill = GetComponent<DensitySkill>();
  }

  // VisualElement GetVisualElement(UIDocument uIDocument)
  // {

  // }
}