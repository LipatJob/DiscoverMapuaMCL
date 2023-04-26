using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlignmentManager : MonoBehaviour
{
    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        Input.compass.enabled = true;
        Input.location.Start();
        target.transform.rotation = Quaternion.Euler(0, -Input.compass.magneticHeading, 0);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
