using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Age : MonoBehaviour
{
    public float time = 5;

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(time);
        Destroy(this.gameObject);
    }

    private void Start()
    {
        StartCoroutine(Wait());
    }
}
