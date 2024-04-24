
using UnityEngine;

public class Patrol : MonoBehaviour
{   [Header ("Patrol Points")]
    [SerializeField] Transform lEdge;
    [SerializeField] Transform REdge;
    // Start is called before the first frame update
    [Header ("Enemy")]
    [SerializeField] private Transform enemy;
    [Header("Movement prameters")]
    [SerializeField] private float speed;
    private Vector3 initScale;
    private bool moveLeft;
    [SerializeField] private float idleTime;//how long enemy will stay patroling(duration) 
    private float idleT;//how long he stayed there.

    [Header("Enemy Animator")]
    [SerializeField]private Animator anim;
    private void Awake()
    {
        initScale = enemy.localScale;
    }
    private void Update(){
        if(moveLeft){
            if(enemy.position.x >= lEdge.position.x)
            MoveInD(-1);
            else 
            ChangeDirection();
        }
        else
        {
            if(enemy.position.x <= REdge.position.x)
            MoveInD(1);
            else
            ChangeDirection();
        }
    }
     private void OnDisable()
   {
      anim.SetBool("moving", false);
   }

    private void ChangeDirection()
    {
        anim.SetBool("moving", false);
        idleT += Time.deltaTime;

        if(idleT > idleTime)
        moveLeft = !moveLeft;
    }
    private void MoveInD(int _direction)
    {
        idleT = 0;
        anim.SetBool("moving", true);
        enemy.localScale = new Vector3(Mathf.Abs(initScale.x) * _direction, initScale.y, initScale.z);
        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * _direction * speed, enemy.position.y, enemy.position.z);
    }
}
