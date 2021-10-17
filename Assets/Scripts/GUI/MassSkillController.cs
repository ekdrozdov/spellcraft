using Unity​Engine.UIElements;

public class MassSkillController : IUpdatebleController
{
  private VisualElement _ui;
  private MassSkill _skill;
  public VisualElement Ui => _ui;

  public MassSkillController(MassSkill skill)
  {
    _skill = skill;
    _ui = VisualAssetRegistry.GetMassControl();

    _ui.Q<Button>("power-sub").clickable.clicked += _skill.DecreacePower;
    _ui.Q<Button>("power-add").clickable.clicked += _skill.IncreacePower;
    _ui.Q<Button>("push").clickable.clicked += _skill.Push;
    _ui.Q<Button>("pull").clickable.clicked += _skill.Pull;
    _ui.Q<Button>("toss").clickable.clicked += _skill.Toss;

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
