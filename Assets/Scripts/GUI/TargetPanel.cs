using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Unity​Engine.UIElements;

public class TargetPanel : MonoBehaviour
{
  public UIDocument UIDocument;
  Button button;
  Label label;
  TextField textField;
  // Start is called before the first frame update
  void Start()
  {
    var root = UIDocument.rootVisualElement;
    var uiAsset = (VisualTreeAsset)AssetDatabase.LoadAssetAtPath("Assets/Scripts/GUI/PropertyDescriptionContainer.uxml", typeof(VisualTreeAsset));

    // VisualElement ui = uiAsset.Instantiate();
    // root.Q<VisualElement>("component-control-container").Add(ui);

    // // add event handler
    // button.clickable.clicked += Button_clicked;
  }

  private void Button_clicked()
  {
    label.text = textField.text;
  }
}
