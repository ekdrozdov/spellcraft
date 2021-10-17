using Unity​Engine.UIElements;

public interface IUpdatebleController
{
  VisualElement Ui { get; }
  void Update();
}

public class ScalarSkillController : IUpdatebleController
{
  private VisualElement _ui;
  private ScalarSkill _skill;
  public VisualElement Ui => _ui;

  public ScalarSkillController(ScalarSkill skill)
  {
    _skill = skill;
    _ui = VisualAssetRegistry.GetScalarControl();

    _ui.Q<Button>("prop-sub").clickable.clicked += _skill.Decreace;
    _ui.Q<Button>("prop-add").clickable.clicked += _skill.Increace;
    _ui.Q<Button>("power-sub").clickable.clicked += _skill.DecreacePower;
    _ui.Q<Button>("power-add").clickable.clicked += _skill.IncreacePower;

    _skill.ComponentValueUpdateEvent += ComponentValueUpdateEventHandler;
    Update();
  }

  public void Update()
  {
    ComponentValueUpdateEventHandler(0);
  }

  private void ComponentValueUpdateEventHandler(float value)
  {
    _ui.Q<Label>("property-value").text = _skill.Target.Property.ToString();
    _ui.Q<Label>("power-value").text = _skill.Power.Value.ToString();
  }
}
