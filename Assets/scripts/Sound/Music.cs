
using UnityEngine;

public class Music : MonoBehaviour
{
   private void Awake(){
    GameObject[] musicOBJ = GameObject.FindGameObjectsWithTag("GameMusic");
    if(musicOBJ.Length > 1){
        Destroy(this.gameObject);
    }
    DontDestroyOnLoad(this.gameObject);
   }
}
