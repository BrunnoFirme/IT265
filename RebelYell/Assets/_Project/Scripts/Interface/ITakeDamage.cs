using System;

public interface ITakeDamage
{
    void TakeDamage(int damage);
    event Action<int> OnTakeDamage;
}