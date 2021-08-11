using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sentry : MonoBehaviour, IHaveTarget, IStun
{
    public Transform rotate;
    public float turnSpeed = 0.1f;
    public bool locked = true;
    GameObject _target;
    GameObject IHaveTarget.target { get => _target; set => _target = value; }
    Gun gun;
    bool stuned = false;

    void Start()
    {
        gun = this.GetComponent<Gun>();
    }

    Quaternion desriedLocation;

    void Update()
    {
        if (_target != null)
            Look();
    }

    void Look()
    {
        if (stuned)
            return;
        Quaternion rot = rotate.transform.rotation;
        rotate.LookAt(_target.transform);
        desriedLocation = rotate.transform.rotation;
        rotate.rotation = rot;
        gun.Fire();
        rotate.transform.rotation = Quaternion.Lerp(rotate.transform.rotation, desriedLocation, turnSpeed * Time.deltaTime);
        if (locked)
            rotate.transform.rotation = Quaternion.Euler(0, rotate.transform.eulerAngles.y, 0);
    }

    public void Stun(float amount)
    {
        StartCoroutine(Wait(amount));
    }

    IEnumerator Wait(float amount)
    {
        stuned = true;
        yield return new WaitForSeconds(amount);
        stuned = false;
    }
}
