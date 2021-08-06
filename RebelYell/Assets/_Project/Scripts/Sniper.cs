using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sniper : MonoBehaviour, IHaveTarget
{
    public Transform rotate;
    public float turnSpeed = 0.1f;
    public bool locked = true;
    public Transform lineRenderStart;
    GameObject _target;
    GameObject IHaveTarget.target { get => _target; set => _target = value; }
    Gun gun;
    LineRenderer lineRenderer;

    void Start()
    {
        gun = this.GetComponent<Gun>();
        lineRenderer = this.GetComponent<LineRenderer>();
        SetEndPos(this.transform.position);
    }

    Quaternion desriedLocation;

    void SetEndPos(Vector3 pos)
    {
        lineRenderer.SetPositions(new Vector3[] { lineRenderStart.position, pos });
    }

    void Update()
    {
        if (_target != null)
            Look();
    }

    void Look()
    {
        Quaternion rot = rotate.transform.rotation;
        rotate.LookAt(_target.transform);
        desriedLocation = rotate.transform.rotation;
        rotate.rotation = rot;
        rotate.transform.rotation = Quaternion.Lerp(rotate.transform.rotation, desriedLocation, turnSpeed * Time.deltaTime);
        if (locked)
            rotate.transform.rotation = Quaternion.Euler(0, rotate.transform.eulerAngles.y, 0);
        SetEndPos(_target.transform.position);
        //Fire();
    }

    void Fire()
    {
        gun.Fire();
    }

    void LockOn()
    {

    }
}
