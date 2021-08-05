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
            GameObject bullet = Instantiate(prefab, barrelEnd.transform.position, Random.rotation);
            bullet.GetComponent<Rigidbody>().AddForce(barrelEnd.transform.forward * speed);
            bullet.GetComponent<IDealDamage>().damage = damage;
            canFire = false;
            StartCoroutine(Wait());
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(durationBetweenBullets);
        canFire = true;
    }
}