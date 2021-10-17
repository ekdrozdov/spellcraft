using UnityEngine;

[RequireComponent(typeof(Density))]
[RequireComponent(typeof(Fuel))]
[RequireComponent(typeof(Humidity))]
[RequireComponent(typeof(Temperature))]
public class TreeBreakable : MonoBehaviour, IBreakable
{
  public event IBreakable.BreakEventHandler BreakEvent;
  public GameObject StumpPrefab = null;
  public GameObject LogPrefab = null;

  public void Break(Vector3 impulse)
  {
    GameObject.Destroy(gameObject);

    Bounds bounds = GetComponent<MeshFilter>().mesh.bounds;
    var treeScale = transform.localScale;

    var stump = Instantiate(
      StumpPrefab,
      new Vector3(
        transform.position.x,
        transform.position.y - treeScale.y + treeScale.y * 0.1f,
        transform.position.z
      ),
      transform.rotation
    );
    stump.GetComponent<Transform>().localScale = new Vector3(treeScale.x, treeScale.y * 0.1f, treeScale.z);

    var log = Instantiate(
      LogPrefab,
      new Vector3(
        transform.position.x,
        transform.position.y - treeScale.y + treeScale.y * 0.9f + stump.transform.localScale.y * 2,
        transform.position.z
      ),
      transform.rotation
    );
    log.GetComponent<Transform>().localScale = new Vector3(treeScale.x, treeScale.y * 0.9f, treeScale.z);
    log.GetComponent<Mass>()?.GravitationalInteraction(impulse.magnitude, -impulse);

    InheritComponents(log, stump);
    BreakEvent?.Invoke(log);
  }

  private void InheritComponents(GameObject log, GameObject stump)
  {
    CommonInheritance(log);
    CommonInheritance(stump);
  }

  private void CommonInheritance(GameObject corpse)
  {
    corpse.GetComponent<Density>().Property = gameObject.GetComponent<Density>().Property;
    corpse.GetComponent<Fuel>().Property = gameObject.GetComponent<Fuel>().Property;
    corpse.GetComponent<Humidity>().Property = gameObject.GetComponent<Humidity>().Property;
    corpse.GetComponent<Temperature>().Property = gameObject.GetComponent<Temperature>().Property;
  }
}