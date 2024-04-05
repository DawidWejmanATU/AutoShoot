
using Unity.VisualScripting;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Transform previousRoom;
    [SerializeField] private Transform NewRoom;

    [SerializeField] private CameraControler cam;

    private void OntriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if(collision.transform.position.x < transform.position.x)
                cam.MoveToNewRoom(NewRoom);
                else
                cam.MoveToNewRoom(previousRoom);
        }
    }


}
