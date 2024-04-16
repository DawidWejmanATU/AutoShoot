
using UnityEngine;

public class Health : MonoBehaviour
{
   [SerializeField] private float startingHealth;
   public float currentHealth { get; private set;}
   private Animator anim;
   private bool dead;

   private void Awake()
   {
    currentHealth = startingHealth;
    anim = GetComponent<Animator>();
   }
   public void TakeDmg(float _dmg)
   {
    currentHealth = Mathf.Clamp(currentHealth - _dmg,0,startingHealth);
    //currentHealth -= _dmg;

    if(currentHealth > 0)
    {
        //Player Hurt
        anim.SetTrigger("hurt");
    }
    else
    {
        //still alive???
        if(!dead){
            anim.SetTrigger("die");
        GetComponent<PlayerMovement>().enabled = false;
        dead = true;
        }
        
    }
   }

  
}
