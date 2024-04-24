
using Unity.VisualScripting;
using UnityEngine;

public class Ninja : MonoBehaviour
{
   [SerializeField] private float AttackCooldown;
   [SerializeField] private float range;
   [SerializeField] private int dmg;
   [SerializeField] private float colliderDistance;
   private float cooldownT = Mathf.Infinity;
   [SerializeField]private BoxCollider2D boxCollider;
   [SerializeField] private LayerMask playerLayer;

   private Animator anim;
   private Health playerH;
   private Patrol enemy_patrol;

   private void Awake()
   {
      anim = GetComponent<Animator>();
      enemy_patrol = GetComponentInParent<Patrol>();
       
   }

   private void Update()
   {
    cooldownT += Time.deltaTime;
    if(enemy_patrol !=null &&PlayerInSight())
    {
        
      if(cooldownT >= AttackCooldown)
      {
      cooldownT = 0;
      anim.SetTrigger("attack");
      }
    
    }
      else
      {
         if(enemy_patrol != null)
         enemy_patrol.enabled = true;
      }
    if(enemy_patrol != null)
      enemy_patrol.enabled = !PlayerInSight();
   }

  
   private bool PlayerInSight()
   {
    RaycastHit2D hit = 
    Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x* colliderDistance,
    new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y,boxCollider.bounds.size.z),
    0, Vector2.left, 0, playerLayer);
    
    if(hit.collider != null)
      playerH = hit.transform.GetComponent<Health>();

    return hit.collider !=null;
   
   }
   private void OnDrawGizmos(){
       Gizmos.color = Color.red;
   Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
   new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y,boxCollider.bounds.size.z));
   }
   
   private void DamagePlayer()
   {
      if(PlayerInSight())
      playerH.TakeDmg(dmg);
   }
}
