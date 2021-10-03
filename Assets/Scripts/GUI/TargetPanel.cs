using UnityEngine;
using Unity​Engine.UIElements;

public class TargetPanel : MonoBehaviour
{
  public UIDocument UIDocument;
  private Caster _caster;
  private ComponentPicker _componentPicker;
  private Label _targetName;
  private VisualElement _componentPickerContainer;

  void Start()
  {
    var root = UIDocument.rootVisualElement;
    _targetName = root.Q<Label>("target-name");
    _componentPickerContainer = root.Q<VisualElement>("component-picker-container");

    _componentPicker = gameObject.GetComponent<ComponentPicker>();
    _componentPickerContainer.Add(_componentPicker.Ui);

    _caster = gameObject.GetComponentInParent<Caster>();
    _caster.TargetUpdatedEvent += TargetUpdatedHandler;
    TargetUpdatedHandler(null);
  }

  private void TargetUpdatedHandler(GameObject target)
  {
    if (_caster.target == null)
    {
      _targetName.text = "No target selected";
      _componentPickerContainer.visible = false;
      return;
    }

    _targetName.text = _caster.target.name;
    _componentPickerContainer.visible = true;
  }
}
