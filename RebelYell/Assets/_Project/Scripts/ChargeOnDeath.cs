using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(IDie))]
public class ChargeOnDeath : MonoBehaviour
{
    IDie death;
    public float radius = 25;

    private void OnEnable()
    {
        death = this.GetComponent<IDie>();
        death.OnDeath += CHARGE;
    }

    private void OnDisable()
    {
        death.OnDeath -= CHARGE;
    }

    public void CHARGE()
    {
        Collider[] colliders = Physics.OverlapSphere(this.transform.position, radius);
        foreach (var item in colliders)
        {
            Energy energy = item.GetComponent<Energy>();
            if (energy != null)
            {
                energy.charge = energy.maxCharge;
                energy.UpdateEnergy();
            }
            
        }
    }
}
