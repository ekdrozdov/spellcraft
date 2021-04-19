using System;

public class IntLimiter
{
  private int _min { get; }

  private int _max { get; }

  public IntLimiter(int min, int max)
  {
    _min = min;
    _max = max;
  }

  public int Fit(int value)
  {
    return Math.Max(Math.Min(value, _max), _min);
  }
}