using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : MonoBehaviour
{
    [SerializeField]
    private float damage;
    [SerializeField]
    private bool deleteAfterDamaging = true;
    [SerializeField]
    private bool destroyAfterImpact;

    public float GetDamage(bool permitDelete = true)
    {
        if (permitDelete && deleteAfterDamaging)
        {
            gameObject.SetActive(false);
        }

        return damage;
    }

    private void SetDamage(float value)
    {
        damage = value;
    }

    private void Awake()
    {
        Debug.Assert(GetDamage(false) > 0);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (destroyAfterImpact)
        {
            gameObject.SetActive(false);
        }
    }
}
