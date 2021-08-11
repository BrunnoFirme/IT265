using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DDOS : MonoBehaviour
{
    public GameObject sphere;
    public GameObject particle;
    public float amount = 5;
    public float radius = 5;

    private void Start()
    {
        Stun();
    }

    void Stun()
    {
        Collider[] colliders = Physics.OverlapSphere(this.transform.position, radius);
        foreach (var other in colliders)
        {
            if (other.GetComponent<IStun>() != null)
            {
                other.GetComponent<IStun>().Stun(amount);
                Instantiate(particle, other.transform.position, Quaternion.identity, other.transform);
            }
        }
    }
}
