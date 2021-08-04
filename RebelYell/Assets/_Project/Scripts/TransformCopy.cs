using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformCopy : MonoBehaviour
{
    public GameObject otherCam;

    void Update()
    {
        this.transform.position = otherCam.transform.position;
        this.transform.rotation = otherCam.transform.rotation;
    }
}