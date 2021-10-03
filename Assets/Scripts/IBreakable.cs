using UnityEngine;

public interface IBreakable
{
  delegate void BreakEventHandler(GameObject corpse);
  event BreakEventHandler BreakEvent;
  void Break(Vector3 impulse);
}