using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDamage : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    float health, maxHealth = 3f;
    void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;

        if(health <= 0)
        {
            Destroy(gameObject);
            ScoreScript.scoreValue += 1;
        }
    }
}
