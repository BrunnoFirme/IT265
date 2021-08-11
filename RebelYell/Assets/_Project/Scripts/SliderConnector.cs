using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderConnector : MonoBehaviour
{
    public void SetMenu()
    {
        this.GetComponent<UI>().SetMenu((int)this.GetComponent<Slider>().value);
    }
}