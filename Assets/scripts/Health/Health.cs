
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
   [SerializeField] private float startingHealth;
   public float currentHealth { get; private set;}// curent health getter and setter
   private Animator anim;// animation veriable 
   private bool dead;//bool if character is dead or not 

   private void Awake()
   {
    currentHealth = startingHealth;
    anim = GetComponent<Animator>();//component to the animation
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
