using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(IDie))]
public class DieSpawn : MonoBehaviour
{
    public GameObject spawnObject;
    public Transform spawnTransform;
    IDie die;

    void Spawn()
    {
        if (spawnTransform == null)
            spawnTransform = this.transform;

        Instantiate(spawnObject, spawnTransform.position, spawnTransform.rotation);
    }

    private void OnEnable()
    {
        die = this.GetComponent<IDie>();
        die.OnDeath += Spawn;
    }

    private void OnDisable()
    {
        die.OnDeath -= Spawn;
    }

}
