using JetBrains.Annotations;
using UnityEngine;

public class Room : MonoBehaviour
{
   [SerializeField] private GameObject[] enemies;
   private Vector3[] iniPositions;

   private void Awake()
   {
    iniPositions = new Vector3[enemies.Length];
    for(int i = 0; i < enemies.Length; i++)
    {
        if(enemies[i] != null)
        iniPositions[i] = enemies[i].transform.position;
    }
    
    
   }
   public void ActiveRoom(bool _status)
    {
        for(int i = 0; i < enemies.Length; i++)
        {
            if(enemies[i] !=null)
            {
                enemies[i].SetActive(_status);
                enemies[i].transform.position = iniPositions[i];
            }
        }
    }
}
