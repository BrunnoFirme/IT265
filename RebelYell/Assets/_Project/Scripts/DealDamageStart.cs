using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(IDealDamage))]
public class DealDamageStart : MonoBehaviour
{
    private void Start()
    {
        IDealDamage dealDamage = this.GetComponent<IDealDamage>();
        dealDamage.DealDamage();
    }
}
