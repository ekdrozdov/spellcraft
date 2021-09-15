using System;
using System.Collections.Generic;
using UnityEngine;

public interface ITempNode
{
  Vector3 LocalPosition { get; }
  List<ITempNode> Neighbours { get; set; }
  float Value { get; set; }
  float Delta { get; set; }
  List<ITempNode> MountedNeighbours { get; set; }
}
