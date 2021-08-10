using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(IHaveTarget),typeof(NavMeshAgent))]
public class ResetTrigger : MonoBehaviour
{
    IHaveTarget haveTarget;
    Vector3 pos;
    NavMeshAgent agent;

    private void Start()
    {
        haveTarget = this.GetComponent<IHaveTarget>();
        agent = this.GetComponent<NavMeshAgent>();
        pos = this.transform.position;
    }

    private void Update()
    {
        if (haveTarget.target == null)
            agent.SetDestination(pos);
    }

}
