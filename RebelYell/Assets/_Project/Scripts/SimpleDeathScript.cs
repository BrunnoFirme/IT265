using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleDeathScript : MonoBehaviour, IDie
{
    public event Action OnDeath = delegate { };

    public void Die()
    {
        OnDeath();
    }
}
