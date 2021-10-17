using Unity​Engine.UIElements;

public interface ISkillControllerBuilder<T>
{
  VisualElement Build(T skill);
}

public class ScalarSkillControllerBuilder : ISkillControllerBuilder<ScalarSkill>
{
  private VisualElement _ui;
  private ScalarSkill _skill;

  public VisualElement Build(ScalarSkill skill)
  {
    _skill = skill;
    _ui = VisualAssetRegistry.GetScalarControl();

    _ui.Q<Button>("prop-sub").clickable.clicked += _skill.Decreace;
    _ui.Q<Button>("prop-add").clickable.clicked += _skill.Increace;

    _ui.Q<Label>("power-value").text = _skill.Power.Value.ToString();
    _ui.Q<Label>("property-value").text = _skill.Target.Value.ToString();

    _skill.ComponentValueUpdateEvent += ComponentValueUpdateEventHandler;
    return _ui;
  }

  private void ComponentValueUpdateEventHandler(float value)
  {
    _ui.Q<Label>("property-value").text = _skill.Target.Value.ToString();
  }
}
