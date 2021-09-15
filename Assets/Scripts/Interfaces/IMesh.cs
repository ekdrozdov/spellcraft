using System;
using UnityEngine;

public interface IMesh<TNode>
{
  float size { get; }
  float y { get; }
  void step();
}
