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
  private List<VisualElement> _skillControllers;
  private List<string> _skillControllerNames;

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

  private void SkillsUpdatedEventHandler(CategorizedSkills skills)
  {
    _skillControllers = new List<VisualElement>();
    _skillControllerNames = new List<string>();
    skills.ScalarSkills.ForEach(s =>
    {
      var scalarBuilder = new ScalarSkillControllerBuilder();
      _skillControllers.Add(scalarBuilder.Build(s));
      _skillControllerNames.Add(s.Target.PropertyName);
    });

    if (_skillControllers.Count == 0)
    {
      _pickedComponentName.text = "No pickable components";
      _selectNextComponentButton.SetEnabled(false);
      _selectPrevComponentButton.SetEnabled(false);
      _componentControlContainer.visible = false;
      return;
    }
    SelectDefaultComponent();
    _selectNextComponentButton.SetEnabled(true);
    _selectPrevComponentButton.SetEnabled(true);
  }

  private void SelectDefaultComponent()
  {
    _pickedComponentNumber = 0;
    Pick();
  }

  private void SelectPrevComponent()
  {
    _pickedComponentNumber--;
    if (_pickedComponentNumber == -1)
    {
      _pickedComponentNumber = _skillControllers.Count - 1;
    }
    Pick();
  }

  private void SelectNextComponent()
  {
    _pickedComponentNumber = (_pickedComponentNumber + 1) % _skillControllers.Count;
    Pick();
  }

  private void Pick()
  {
    _componentControlContainer.Clear();
    var pickedSkill = _skillControllers[_pickedComponentNumber];
    _pickedComponentName.text = _skillControllerNames[_pickedComponentNumber];
    _componentControlContainer.Add(pickedSkill);
    _componentControlContainer.visible = true;
  }
}
