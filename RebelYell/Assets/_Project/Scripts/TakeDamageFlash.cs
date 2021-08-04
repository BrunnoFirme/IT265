using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ITakeDamage))]
public class TakeDamageFlash : MonoBehaviour
{
    public GameObject flash;
    public float flashDuration = 0.1f;
    ITakeDamage dam;
    private void OnEnable()
    {
        dam = this.GetComponent<ITakeDamage>();
        dam.OnTakeDamage += CallFlash;
    }
    private void OnDisable()
    {
        dam.OnTakeDamage -= CallFlash;
    }

    void CallFlash(int a)
    {
        StopAllCoroutines();
        StartCoroutine(Flash());
    }

    IEnumerator Flash()
    {
        flash.SetActive(true);
        yield return new WaitForSeconds(flashDuration);
        flash.SetActive(false);
    }
}
