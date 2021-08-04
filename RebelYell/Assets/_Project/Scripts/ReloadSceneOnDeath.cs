using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(IDie))]
public class ReloadSceneOnDeath : MonoBehaviour
{
    IDie die;

    private void OnEnable()
    {
        die = this.GetComponent<IDie>();
        die.OnDeath += Reload;
    }

    private void OnDisable()
    {
        die.OnDeath -= Reload;
    }

    void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
