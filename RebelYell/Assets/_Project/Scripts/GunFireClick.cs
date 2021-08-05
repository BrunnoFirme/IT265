using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFireClick : MonoBehaviour
{
    Gun gun;
    private void Start()
    {
        gun = this.GetComponent<Gun>();
    }
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            gun.Fire();
        }
    }
}
