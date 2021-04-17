public class EmptyProperty : SimpleObservable<IObservableProperty>, IObservableProperty
{
  public string Name => "No property selected";

  public int Value => 0;

  public void Update(int delta)
  {
  }
}
