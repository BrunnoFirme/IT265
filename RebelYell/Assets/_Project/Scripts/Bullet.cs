using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IDealDamage
{
    public int damage { get => _damage; set => _damage = value; }
    int _damage;

    private void OnCollisionEnter(Collision collision)
    {
        ITakeDamage dam = collision.collider.GetComponent<ITakeDamage>();
        if (dam != null)
            dam.TakeDamage(damage);
        Destroy(this.gameObject);
    }
}
