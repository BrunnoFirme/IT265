using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnterArray : MonoBehaviour
{
    public GameObject[] enemies;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            foreach (var enemy in enemies)
            {
                if (enemy != null)
                    enemy.GetComponent<IHaveTarget>().target = other.gameObject;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            foreach (var enemy in enemies)
            {
                if (enemy != null)
                    enemy.GetComponent<IHaveTarget>().target = null;
            }
        }
    }
}
