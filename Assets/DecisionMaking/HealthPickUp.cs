using UnityEngine;
public class HealthPickUp : MonoBehaviour
{
    public float bonusHealth = 5;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<Healthstate>())
        {
            other.GetComponent<Healthstate>().health += bonusHealth;
            Destroy(gameObject);
        }
    }
}
