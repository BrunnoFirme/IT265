using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(IDie))]
public class DeathSpawn : MonoBehaviour
{
    public GameObject spawnObject;
    IDie death;

    public bool MatchRotation = false;

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
        if (!MatchRotation)
            Instantiate(spawnObject, this.transform.position, spawnObject.transform.rotation);
        else
            Instantiate(spawnObject, this.transform.position, this.transform.rotation);
    }
}
