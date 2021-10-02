using UnityEngine;
using Unity​Engine.UIElements;

public class TargetPanel : MonoBehaviour
{
  public UIDocument UIDocument;
  private Caster caster;

  private Label _targetName;
  private VisualElement _componentPickerContainer;
  private VisualElement _componentControlContainer;

  void Start()
  {
    var root = UIDocument.rootVisualElement;
    _targetName = root.Q<Label>("target-name");
    _componentPickerContainer = root.Q<VisualElement>("component-picker-container");
    _componentControlContainer = root.Q<VisualElement>("component-control-container");

    UpdateTargetNotify();

    // var uiAsset = (VisualTreeAsset)AssetDatabase.LoadAssetAtPath("Assets/Scripts/GUI/PropertyDescriptionContainer.uxml", typeof(VisualTreeAsset));

    // VisualElement ui = uiAsset.Instantiate();
    // root.Q<VisualElement>("component-control-container").Add(ui);

    // // add event handler
    // button.clickable.clicked += Button_clicked;
  }

  void UpdateTargetNotify()
  {
    if (caster.target == null)
    {
      _targetName.text = "No target selected";
      _componentPickerContainer.visible = false;
      _componentControlContainer.visible = false;
      return;
    }

    _targetName.text = caster.target.name;
  }
}
