using Unity​Engine.UIElements;

public interface IRenderable
{
  string Name { get; }
  VisualElement Render();
}