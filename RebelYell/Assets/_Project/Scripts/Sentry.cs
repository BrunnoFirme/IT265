using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sentry : MonoBehaviour, IHaveTarget
{
    public Transform rotate;
    public string targetTag = "Player";
    public float turnSpeed = 0.1f;
    GameObject _target;
    GameObject IHaveTarget.target { get => _target; set => _target = value; }
    Gun gun;

    void Start()
    {
        gun = this.GetComponent<Gun>();
    }

    Quaternion desriedLocation;

    void Update()
    {
        if (_target != null)
            Look();
        Quaternion rotation = rotate.transform.localRotation;
        rotate.transform.rotation = Quaternion.Lerp(rotate.transform.localRotation, desriedLocation, turnSpeed * Time.deltaTime);
        rotate.transform.rotation = Quaternion.Euler(0, rotate.transform.eulerAngles.y, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == targetTag)
            _target = other.gameObject;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == targetTag)
            _target = null;
    }

    void Look()
    {
        Quaternion rot = rotate.transform.rotation;
        rotate.LookAt(_target.transform);
        desriedLocation = rotate.transform.rotation;
        rotate.rotation = rot;
        gun.Fire();
    }
}
