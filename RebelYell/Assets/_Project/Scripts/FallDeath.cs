using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(IDie))]
public class FallDeath : MonoBehaviour
{
    public int minY = -50;
    IDie death;

    private void Start()
    {
        death = this.GetComponent<IDie>();
    }

    private void Update()
    {
        if (this.transform.position.y < minY)
            death.Die();
    }
}
