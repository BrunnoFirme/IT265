using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public int damage = 10;
    public float durationBetweenBullets = 0.5f;
    public float speed = 5;
    public GameObject prefab;

    public GameObject barrelEnd;

    bool canFire = true;

    public void Fire()
    {
        if (canFire)
        {
            GameObject bullet = Instantiate(prefab, barrelEnd.transform.position, prefab.transform.rotation);
            bullet.GetComponent<Rigidbody>().AddForce(barrelEnd.transform.forward * speed);
            bullet.GetComponent<IDealDamage>().damage = 5;
            canFire = false;
            StartCoroutine(Wait());
        }
    }

    public void Update()
    {
        if (Input.GetMouseButton(0))
            Fire();
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(durationBetweenBullets);
        canFire = true;
    }
}