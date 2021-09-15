using System.Collections.Generic;
using UnityEngine;

public class TempNode : MonoBehaviour
{
  public Vector3 LocalPosition { get; }
  public List<TempNode> Neighbours { get; set; } = new List<TempNode>(4);
  public float Value;
  public float Delta { get; set; }
  public List<TempNode> MountedNeighbours { get; set; } = new List<TempNode>();

  public TempNode(Vector3 position, float val = 0F)
  {
    LocalPosition = position;
    Value = val;
    Delta = 0;
  }
}