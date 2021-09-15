using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempField : MonoBehaviour
{
  public float BaseLength = 10F;
  public int NodesCount = 100;
  public int InitTemp = 25;
  public float flowRate = 0.2F;
  private TempNode[,] _mesh;
  // Start is called before the first frame update
  void Start()
  {
    var _globalLength = transform.localScale * BaseLength;
    _mesh = createMesh(_globalLength.x, NodesCount, InitTemp);

    TempNode[] tempNodes = Object.FindObjectsOfType<TempNode>();
    _mesh[3, 3].MountedNeighbours.AddRange(tempNodes);

    // Setup mesh updates.
    InvokeRepeating("UpdateMesh", 1.0f, 1.0f);
  }

  // Update is called once per frame
  void Update()
  {
  }

  private TempNode[,] createMesh(float length, int size, float initValue)
  {
    float step = length / (size - 1);
    var offset = -(step * size) / 2;
    Vector3 localPosition = new Vector3(0, 0, 0);

    // Allocate memory, init positions and values.
    TempNode[,] meshXz = new TempNode[size, size];
    localPosition.x = offset;
    for (int i = 0; i < size; i++)
    {
      localPosition.z = offset;
      for (int j = 0; j < size; j++)
      {
        meshXz[i, j] = new TempNode(localPosition, initValue);
        localPosition.z += step;
      }
      localPosition.x += step;
    }

    // Init neighbours.
    for (int i = 0; i < size; i++)
    {
      for (int j = 0; j < size; j++)
      {
        if (i != 0)
        {
          var down = meshXz[i - 1, j];
          meshXz[i, j].Neighbours.Add(down);
        }
        if (i != size - 1)
        {
          var up = meshXz[i + 1, j];
          meshXz[i, j].Neighbours.Add(up);
        }
        if (j != 0)
        {
          var left = meshXz[i, j - 1];
          meshXz[i, j].Neighbours.Add(left);
        }
        if (j != size - 1)
        {
          var right = meshXz[i, j + 1];
          meshXz[i, j].Neighbours.Add(right);
        }
      }
    }
    return meshXz;
  }

  private void UpdateMesh()
  {
    var flowRate = 0.05F;

    // Compute deltas from mesh.
    for (int i = 0; i < NodesCount; i++)
    {
      for (int j = 0; j < NodesCount; j++)
      {
        var lackingMountedNeighbours = _mesh[i, j].MountedNeighbours.FindAll(delegate (TempNode node)
        {
          return (node.Value < _mesh[i, j].Value);
        });
        var lackingNeighbours = _mesh[i, j].Neighbours.FindAll(delegate (TempNode node)
        {
          return (node.Value < _mesh[i, j].Value);
        });
        lackingNeighbours.AddRange(lackingMountedNeighbours);
        if (lackingNeighbours.Count > 0)
        {
          var flowBudget = _mesh[i, j].Value * flowRate;
          var delta = flowBudget / lackingNeighbours.Count;
          lackingNeighbours.ForEach(delegate (TempNode node)
          {
            node.Delta += delta;
          });
          _mesh[i, j].Delta -= flowBudget;
        }
      }
    }

    // Compute deltas from mounts.
    for (int i = 0; i < NodesCount; i++)
    {
      for (int j = 0; j < NodesCount; j++)
      {
        _mesh[i, j].MountedNeighbours.ForEach(delegate (TempNode node)
        {
          if (node.Value > _mesh[i, j].Value)
          {
            var flowBudget = node.Value * flowRate;
            _mesh[i, j].Delta += flowBudget;
            node.Delta -= flowBudget;
          }
        });
      }
    }

    // Apply deltas.
    for (int i = 0; i < NodesCount; i++)
    {
      for (int j = 0; j < NodesCount; j++)
      {
        _mesh[i, j].Value += _mesh[i, j].Delta;
        _mesh[i, j].Delta = 0F;
        _mesh[i, j].MountedNeighbours.ForEach(delegate (TempNode node)
        {
          node.Value += node.Delta;
          node.Delta = 0F;
        });
      }
    }
  }
}
