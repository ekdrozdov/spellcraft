using UnityEngine;
using Unity​Engine.UIElements;
using UnityEditor;

public class DensitySkill : MonoBehaviour
{
  [Range(0.01f, 100)]
  public float Power = 1;
  private Density _targetDensity;

  public void Increase()
  {
    _targetDensity.Value += Power;
  }
  public void Descrease()
  {
    _targetDensity.Value -= Power;
  }
  public VisualElement Render()
  {
    var uiAsset = (VisualTreeAsset)AssetDatabase.LoadAssetAtPath("Assets/Scripts/GUI/PropertyDescriptionContainer.uxml", typeof(VisualTreeAsset));
    return uiAsset.Instantiate();
  }
}