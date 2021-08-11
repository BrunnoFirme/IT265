using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ITakeDamage), typeof(IDie))]
public class Health : MonoBehaviour
{
    public int maxHealth = 10;
    public int health {get => _health;}
    int _health = 1;
    ITakeDamage takeDamage;
    IDie die;
    public event Action HealthUpdate = delegate {};

    private void OnEnable()
    {
        takeDamage = this.GetComponent<ITakeDamage>();
        die = this.GetComponent<IDie>();
        takeDamage.OnTakeDamage += TakeDamage;
        _health = maxHealth;
    }

    private void OnDisable()
    {
        takeDamage.OnTakeDamage -= TakeDamage;
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        HealthUpdate();
        if (_health <= 0)
            die.Die();
    }

}
