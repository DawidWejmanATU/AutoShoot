
using UnityEngine;
using UnityEngine.SceneManagement;

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
            if(GetComponent<PlayerMovement>() != null)
        GetComponent<PlayerMovement>().enabled = false;

        if(GetComponent<Patrol>() != null)
        GetComponent<Patrol>().enabled= false;
        if(GetComponent<Ninja>() != null)
        GetComponent<Ninja>().enabled = false;
        dead = true;
        Invoke("LoadMenuScene", 3f);
        }
        
    }
   }

  private void LoadMenuScene()
  {
    SceneManager.LoadScene("SampleScene");
  }
}
