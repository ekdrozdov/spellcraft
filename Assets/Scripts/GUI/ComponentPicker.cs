using UnityEngine;
using Unity​Engine.UIElements;
using System.Collections.Generic;

public class ComponentPicker : MonoBehaviour
{
  public VisualTreeAsset Asset;
  public VisualElement Ui;
  private VisualElement _componentControlContainer;
  private Button _selectPrevComponentButton;
  private Button _selectNextComponentButton;
  private Label _pickedComponentName;
  private SkillsProvider _skillsProvider;
  private int _pickedComponentNumber = 0;

  void Start()
  {
    Ui = Asset.Instantiate();
    _componentControlContainer = Ui.Q<VisualElement>("component-control-container");
    _selectPrevComponentButton = Ui.Q<Button>("select-prev-component");
    _selectNextComponentButton = Ui.Q<Button>("select-next-component");
    _pickedComponentName = Ui.Q<Label>("picked-component-name");

    _selectPrevComponentButton.clickable.clicked += SelectPrevComponent;
    _selectNextComponentButton.clickable.clicked += SelectNextComponent;

    _componentControlContainer.visible = false;

    _skillsProvider = gameObject.GetComponentInParent<SkillsProvider>();
    _skillsProvider.SkillsUpdatedEvent += SkillsUpdatedEventHandler;
  }

  private void SkillsUpdatedEventHandler(List<IRenderable> skills)
  {
    if (skills.Count == 0)
    {
      _pickedComponentName.text = "No pickable components";
      _selectNextComponentButton.SetEnabled(false);
      _selectPrevComponentButton.SetEnabled(false);
      _componentControlContainer.visible = false;
      return;
    }
    SelectDefaultComponent(skills);
    _selectNextComponentButton.SetEnabled(true);
    _selectPrevComponentButton.SetEnabled(true);
  }

  private void SelectDefaultComponent(List<IRenderable> skills)
  {
    _pickedComponentNumber = 0;
    Pick();
  }

  private void SelectPrevComponent()
  {
    _pickedComponentNumber--;
    if (_pickedComponentNumber == -1)
    {
      _pickedComponentNumber = _skillsProvider.GetSkills().Count - 1;
    }
    Pick();
  }

  private void SelectNextComponent()
  {
    _pickedComponentNumber = (_pickedComponentNumber + 1) % _skillsProvider.GetSkills().Count;
    Pick();
  }

  private void Pick()
  {
    _componentControlContainer.Clear();
    var pickedSkill = _skillsProvider.GetSkills()[_pickedComponentNumber];
    _pickedComponentName.text = pickedSkill.Name;
    _componentControlContainer.Add(pickedSkill.Render());
    _componentControlContainer.visible = true;
  }
}
