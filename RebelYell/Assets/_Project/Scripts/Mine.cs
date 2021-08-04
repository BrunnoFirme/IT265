using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider),typeof(IDie))]
public class Mine : MonoBehaviour
{
    public string triggerTag = "Player";
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == triggerTag)
        {
            this.GetComponent<IDie>().Die();
        }
    }
}
