using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingEntity : MonoBehaviour, IDamageable
{
    // Variables
    public float startingHealth;
    protected float health;
    protected bool dead;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        health = startingHealth;
    }

    // TakeHit method
    public void TakeHit(float damage, RaycastHit hit)
    {
        health -= damage;
        if (health <= 0 && !dead)
        {
            Die();
        }
    }

    // Die method
    protected void Die()
    {
        dead = true;
        GameObject.Destroy(gameObject);
    }
}
