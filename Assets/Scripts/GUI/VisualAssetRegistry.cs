using UnityEditor;
using UnityEngine.UIElements;

class VisualAssetRegistry
{
  private static VisualTreeAsset scalarControlAsset = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Scripts/GUI/Layout/ScalarComponentController.uxml");
  private static VisualTreeAsset vectorControlAsset = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Scripts/GUI/Layout/VectorComponentController.uxml");
  private static VisualTreeAsset massControlAsset = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Scripts/GUI/Layout/MassComponentController.uxml");

  public static VisualElement GetScalarControl()
  {
    return scalarControlAsset.Instantiate();
  }
  public static VisualElement GetVectorControl()
  {
    return vectorControlAsset.Instantiate();
  }
  public static VisualElement GetMassControl()
  {
    return massControlAsset.Instantiate();
  }
}