using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public struct WaypointItem
{
    public string name;
    public GameObject gameObject;
}

public class WaypointManager : MonoBehaviour
{
    public List<WaypointItem> waypoints;
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            ToWayPoint(waypoints[Input.touchCount].name);
        }
    }

    void ToWayPoint(string name)
    {
        foreach (var waypoint in waypoints)
        {
            if (waypoint.name == name){
                target.transform.position = waypoint.gameObject.transform.position;
                break;
            }
        }
    }
}
