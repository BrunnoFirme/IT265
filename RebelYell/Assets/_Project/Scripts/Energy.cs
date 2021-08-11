using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Energy : MonoBehaviour
{
    public int charge { get { return _charge; } set { _charge = value; } }
    public int maxCharge = 100;
    int _charge;
    int index = 0;

    [SerializeField] Ability[] abilities;
    public event Action OnEnergyUse = delegate { };

    public GameObject DDOS;
    public GameObject NoEnergySound;
    public GameObject UseFireWallSound;
    public GameObject UseDDOSSound;
    public Image abilityImage;

    public void UpdateEnergy()
    {
        OnEnergyUse();
    }

    private void OnEnable()
    {
        charge = maxCharge;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (_charge >= abilities[index].cost)
            {
                if (abilities[index].gun != null)
                    abilities[index].gun.Fire();
                charge -= abilities[index].cost;
                OnEnergyUse();

                if (index == 1)
                    Instantiate(DDOS, this.transform.position, Quaternion.identity);
            }
            else
                Spawn(NoEnergySound);
        }

        if (Input.GetKeyDown(KeyCode.Q))
            NextIndex();
        //CheckInputs();
    }

    void CheckInputs()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (_charge >= abilities[0].cost)
            {
                abilities[0].gun.Fire();
                charge -= abilities[0].cost;
                OnEnergyUse();
            }
            else
            {
                Spawn(NoEnergySound);
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (_charge >= abilities[1].cost)
            {
                charge -= abilities[1].cost;
                OnEnergyUse();
                Instantiate(DDOS, this.transform.position, Quaternion.identity);
            }
            else
            {
                Spawn(NoEnergySound);
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {

        }
    }

    void Spawn(GameObject objectToSpawn)
    {
        Instantiate(objectToSpawn, this.transform.position, Quaternion.identity);
    }

    void NextIndex()
    {
        index++;
        if (index >= abilities.Length)
            index = 0;
        abilityImage.sprite = abilities[index].abilityImage;
    }
}

[System.Serializable]
struct Ability
{
    public string name;
    public Sprite abilityImage;
    public Gun gun;
    public int cost;
}
