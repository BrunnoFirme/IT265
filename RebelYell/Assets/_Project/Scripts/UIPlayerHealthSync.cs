using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayerHealthSync : MonoBehaviour
{
    public Image bar;
    public Text text;
    public Health health;
    public Energy energy;

    public Image bar2;
    public Text text2;

    private void OnEnable()
    {
        health.HealthUpdate += UpdateHealth;
        energy.OnEnergyUse += UpdateEnergy;
    }

    private void Start()
    {
        UpdateHealth();
    }

    private void OnDisable()
    {
        health.HealthUpdate -= UpdateHealth;
        energy.OnEnergyUse -= UpdateEnergy;
    }

    private void UpdateHealth()
    {
        bar.rectTransform.localScale = new Vector3((float)health.health/ (float)health.maxHealth, 1, 1);
        text.text = health.health.ToString();
    }

    private void UpdateEnergy()
    {
        bar2.rectTransform.localScale = new Vector3((float)energy.charge / (float)energy.maxCharge, 1, 1);
        text2.text = energy.charge.ToString();
    }
}
