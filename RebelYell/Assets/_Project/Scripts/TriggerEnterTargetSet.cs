using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(IHaveTarget))]
public class TriggerEnterTargetSet : MonoBehaviour
{
    IHaveTarget haveTarget;
    string targetTag = "Player";

    private void Start()
    {
        haveTarget = this.GetComponent<IHaveTarget>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == targetTag)
            haveTarget.target = other.gameObject;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == targetTag)
            haveTarget.target = null;
    }
}
