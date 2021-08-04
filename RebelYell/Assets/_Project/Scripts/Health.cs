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

    private void OnEnable()
    {
        takeDamage = this.GetComponent<ITakeDamage>();
        die = this.GetComponent<IDie>();
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
        if (_health <= 0)
            die.Die();
    }

}
