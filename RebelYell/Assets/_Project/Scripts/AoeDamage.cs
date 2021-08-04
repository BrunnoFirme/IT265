using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AoeDamage : MonoBehaviour, IDealDamage
{
    public float radius = 5;
    public int damage = 20;

    int IDealDamage.damage { get => _damge; set => _damge = value; }
    int _damge;

    public void DealDamage()
    {
        Collider[] colliders = Physics.OverlapSphere(this.transform.position, radius);
        foreach (Collider collider in colliders)
        {
            ITakeDamage takeDamage = collider.GetComponent<ITakeDamage>();
            if (takeDamage != null)
                takeDamage.TakeDamage(damage);
        }
    }
}