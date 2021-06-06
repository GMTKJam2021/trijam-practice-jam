using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : MonoBehaviour
{

    [SerializeField]
    public float Damage { get; private set; }

    private void Awake()
    {
        Debug.Assert(Damage > 0);
    }
}
