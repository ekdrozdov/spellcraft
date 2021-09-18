using UnityEngine;

public class PlayerJumpController : MonoBehaviour
{
  private CharacterController controller;
  private Vector3 playerVelocity;
  private bool groundedPlayer;
  private float playerSpeed = 2.0f;
  public float _rotationSpeed = 180;
  private Vector3 rotation;

  private void Start()
  {
    controller = gameObject.AddComponent<CharacterController>();
  }

  public void Update()
  {
    this.rotation = new Vector3(0, Input.GetAxisRaw("Horizontal") * _rotationSpeed * Time.deltaTime, 0);

    Vector3 move = new Vector3(0, 0, Input.GetAxisRaw("Vertical") * Time.deltaTime);
    move = this.transform.TransformDirection(move);
    controller.Move(move * playerSpeed);
    this.transform.Rotate(this.rotation);
  }
}