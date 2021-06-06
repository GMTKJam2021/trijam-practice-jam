using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private float maxHealth;
    private float health;
    public bool IsDead { get; private set; }

    private void Awake()
    {
        health = maxHealth;
    }

    private void DealDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            health = 0;
            if (!IsDead)
            {
                Die();
            }
        }
    }

    private void Die()
    {
        IsDead = true;

        // play animations

        // TODO: replace this
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Damager damager = other.collider.GetComponent<Damager>();
        if (damager != null)
        {
            DealDamage(damager.GetDamage());
        }
    }
}
