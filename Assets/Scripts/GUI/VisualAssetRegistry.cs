using UnityEditor;
using UnityEngine.UIElements;

class VisualAssetRegistry
{
  private static VisualTreeAsset scalarControlAsset = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Scripts/GUI/ScalarComponentController.uxml");
  public static VisualElement GetScalarControl()
  {
    return scalarControlAsset.Instantiate();
  }
}