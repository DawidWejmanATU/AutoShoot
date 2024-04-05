
using UnityEngine;

public class CameraControler : MonoBehaviour
{
  [SerializeField] private float speed;
  private float currentPositionX;

  private Vector3 velocity = Vector3.zero;

  private void update()
  {
    transform.position = Vector3.SmoothDamp(transform.position, new Vector3(currentPositionX, transform.position.y, transform.position.z),
     ref velocity, speed * Time.deltaTime);
  }

  public void MoveToNewRoom(Transform _newRoom)
  {
    currentPositionX = _newRoom.position.x;

  }
}
