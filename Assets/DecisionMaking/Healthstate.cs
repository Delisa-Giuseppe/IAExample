using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healthstate : MonoBehaviour {

    public int team = 0;
    public float health = 10;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<Bullet>())
        {
            Destroy(other.gameObject);
            health--;

            if(health == 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
