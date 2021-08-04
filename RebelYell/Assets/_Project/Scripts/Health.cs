using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ITakeDamage))]
public class Health : MonoBehaviour
{
    public int maxHealth = 10;
    int _health = 1;
    ITakeDamage takeDamage;

    private void OnEnable()
    {
        takeDamage = this.GetComponent<ITakeDamage>();
        takeDamage.OnTakeDamage += TakeDamage;
    }

    private void OnDisable()
    {
        takeDamage.OnTakeDamage -= TakeDamage;
    }

    void Start()
    {
        _health = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        if ( _health <= 0)
            Die();
    }

    void Die()
    {
        Destroy(this.gameObject);
    }

}
