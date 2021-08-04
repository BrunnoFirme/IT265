using System;

public interface IDie
{
    void Die();
    event Action OnDeath;
}
