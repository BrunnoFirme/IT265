using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTakeDamage : MonoBehaviour, ITakeDamage
{
    public event Action<int> OnTakeDamage = delegate { };

    public void TakeDamage(int damage)
    {
        OnTakeDamage(damage);
    }
}