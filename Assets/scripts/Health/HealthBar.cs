

using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
 [SerializeField] private Health playerHealth;
 [SerializeField] private Image TotalhealthBar;//image for total health 
 [SerializeField] private Image currenthealthBar;//current health veriable

 private void Start()
 {
    TotalhealthBar.fillAmount = playerHealth.currentHealth / 10;// at the start its just division 3/10(only 10 harts)
 }
 private void Update()
 {
    currenthealthBar.fillAmount = playerHealth.currentHealth / 10;
 }
}
