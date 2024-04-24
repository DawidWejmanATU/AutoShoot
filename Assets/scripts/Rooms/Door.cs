using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Transform previousRoom;
    [SerializeField] private Transform nextRoom;
    [SerializeField] private CameraController cam;

    private void OnTriggerEnter2D(Collider2D collision)
{
    if (collision.tag == "Player")
    {
        if (cam == null || nextRoom == null || previousRoom == null)
        {
            Debug.LogError("One or more required objects are null.");
            return;
        }

        if (collision.transform.position.x < transform.position.x)
        {
            cam.MoveToNewRoom(nextRoom);
            if (nextRoom.GetComponent<Room>() != null)
            {
                nextRoom.GetComponent<Room>().ActiveRoom(true);
            }
            if (previousRoom.GetComponent<Room>() != null)
            {
                previousRoom.GetComponent<Room>().ActiveRoom(false);
            }
        }
        else
        {
            cam.MoveToNewRoom(previousRoom);
            if (previousRoom.GetComponent<Room>() != null)
            {
                previousRoom.GetComponent<Room>().ActiveRoom(true);
            }
            if (nextRoom.GetComponent<Room>() != null)
            {
                nextRoom.GetComponent<Room>().ActiveRoom(false);
            }
        }
    }
}
}