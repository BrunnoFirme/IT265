using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Grunt : MonoBehaviour, IHaveTarget
{
    GameObject IHaveTarget.target { get => _target; set => _target = value; }
    GameObject _target;

    NavMeshAgent navMeshAgent;

    void Start()
    {
        navMeshAgent = this.GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (_target != null)
            MoveToPlayer();
    }

    void MoveToPlayer()
    {
        this.transform.LookAt(_target.transform.position);
        navMeshAgent.SetDestination(_target.transform.position);
        this.transform.rotation = Quaternion.Euler(0, this.transform.eulerAngles.y, 0);
    }
}
