using UnityEngine;
using Unity​Engine.UIElements;

public class VectorSkillController : IUpdatebleController
{
  private VisualElement _ui;
  private VectorSkill _skill;
  public VisualElement Ui => _ui;

  public VectorSkillController(VectorSkill skill)
  {
    _skill = skill;
    _ui = VisualAssetRegistry.GetVectorControl();

    _ui.Q<Button>("prop-sub").clickable.clicked += _skill.Decreace;
    _ui.Q<Button>("prop-add").clickable.clicked += _skill.Increace;
    _ui.Q<Button>("power-sub").clickable.clicked += _skill.DecreacePower;
    _ui.Q<Button>("power-add").clickable.clicked += _skill.IncreacePower;

    _skill.ComponentValueUpdateEvent += ComponentValueUpdateEventHandler;
    Update();
  }

  public void Update()
  {
    ComponentValueUpdateEventHandler(Vector3.zero);
  }

  private void ComponentValueUpdateEventHandler(Vector3 value)
  {
    _ui.Q<Label>("property-value").text = _skill.Target.Property.ToString();
    _ui.Q<Label>("power-value").text = _skill.Power.Value.ToString();
  }
}
