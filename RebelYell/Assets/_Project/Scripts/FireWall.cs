using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWall : MonoBehaviour, IDealDamage
{
    public int damage = 50;
    public float speed = 1;
    public GameObject particle;

    int IDealDamage.damage { get => damage; set => damage = value; }

    void Start()
    {
        Vector3 vector = this.transform.rotation.eulerAngles;
        this.transform.rotation = Quaternion.Euler(0, vector.y, 0);
    }

    public void DealDamage()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        ITakeDamage dam = other.GetComponent<ITakeDamage>();
        if (dam != null && other.tag != "Player")
            dam.TakeDamage(50);
        if (other.GetComponent<Bullet>() != null)
        {
            Instantiate(particle, other.transform.position, other.transform.rotation);
            Destroy(other.gameObject);
        }
    }

    void Update()
    {
        this.transform.position += this.transform.forward * Time.deltaTime * speed;
    }
}