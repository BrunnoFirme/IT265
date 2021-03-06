using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent),typeof(Gun))]
public class Grunt : MonoBehaviour, IHaveTarget, IStun
{
    GameObject IHaveTarget.target { get => _target; set => _target = value; }
    GameObject _target;

    NavMeshAgent navMeshAgent;
    Gun gun;
    bool stuned = false;

    public int ShootDistance = 20;

    void Start()
    {
        navMeshAgent = this.GetComponent<NavMeshAgent>();
        gun = this.GetComponent<Gun>();
    }

    void Update()
    {
        if (_target != null)
            AITHoughtLoop();
    }

    void AITHoughtLoop()
    {
        if (stuned)
        {
            navMeshAgent.SetDestination(this.transform.position);
            return;
        }
        if (Vector3.Distance(this.transform.position, _target.transform.position) < ShootDistance && HasSightLine())
            Shoot();
        else
            MoveToPlayer();
    }

    void MoveToPlayer()
    {
        navMeshAgent.SetDestination(_target.transform.position);
    }

    void Shoot()
    {
        this.transform.LookAt(_target.transform.position);
        this.transform.rotation = Quaternion.Euler(0, this.transform.eulerAngles.y, 0);
        gun.Fire();
    }

    bool HasSightLine()
    {
        RaycastHit hit;
        Vector3 dir = (_target.transform.position - this.transform.position).normalized;

        if (Physics.Raycast(transform.position, dir, out hit, Mathf.Infinity))
        {
            Debug.DrawRay(transform.position, dir * 100, Color.yellow);
            if (hit.transform.tag == _target.tag)
                return true;
        }
        return false;
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
