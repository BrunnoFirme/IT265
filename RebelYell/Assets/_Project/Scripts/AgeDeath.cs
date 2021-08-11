using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(IDie))]
public class AgeDeath : MonoBehaviour
{
    public float age = 1;
    IDie dieScript;
    private void OnEnable()
    {
        dieScript = this.GetComponent<IDie>();
    }

    private void Start()
    {
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(age);
        dieScript.Die();
    }
}
