
using UnityEngine;

public class Enemy_Damage : MonoBehaviour
{
    [SerializeField] protected float damage;
    
    protected private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.tag == "Player")
        collision.GetComponent<Health>().TakeDmg(damage);
    }
}
