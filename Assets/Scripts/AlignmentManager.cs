using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlignmentManager : MonoBehaviour
{
    public GameObject target;
    private float previousRotation;
    private float rotationSmoothing = .1f;

    void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Input.location.Start();
        Input.compass.enabled = true;
        previousRotation = Input.compass.trueHeading;
    }

    void Update()
    {
        float currentRotation = Input.compass.trueHeading;
        float rotationDelta = (currentRotation - previousRotation) * rotationSmoothing;
        float filteredRotation = previousRotation + rotationDelta;
        target.transform.rotation = Quaternion.Euler(0, filteredRotation, 0);
        previousRotation = filteredRotation;
    }

}
