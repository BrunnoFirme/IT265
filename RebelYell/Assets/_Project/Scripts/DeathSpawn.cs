using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(IDie))]
public class DeathSpawn : MonoBehaviour
{
    public GameObject spawnObject;
    IDie death;

    private void OnEnable()
    {
        death = this.GetComponent<IDie>();
        death.OnDeath += Spawn;
    }

    private void OnDisable()
    {
        death.OnDeath -= Spawn;
    }

    void Spawn()
    {
        Instantiate(spawnObject, this.transform.position, spawnObject.transform.rotation);
    }
}
