using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(IDie))]
public class DeathDestroy : MonoBehaviour
{
    IDie die;

    private void Destroy()
    {
        Destroy(this.gameObject);
    }

    private void OnEnable()
    {
        die = this.GetComponent<IDie>();
        die.OnDeath += Destroy;
    }

    private void OnDisable()
    {
        die.OnDeath -= Destroy;
    }
}
