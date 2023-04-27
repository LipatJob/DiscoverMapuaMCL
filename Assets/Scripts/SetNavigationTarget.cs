using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

[Serializable]
public class Target {
    public string name;
    public GameObject positionObject;
}

public class SetNavigationTarget : MonoBehaviour
{
    [SerializeField]
    private TMP_Dropdown targetDropDown;
    [SerializeField]
    private List<Target> targetObjects = new List<Target>();

    private NavMeshPath path;
    private LineRenderer line;
    private Vector3 targetPosition = Vector3.zero;

    public static SetNavigationTarget instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public bool isNavigating = false;
    // Start is called before the first frame update
    void Start()
    {
        path = new UnityEngine.AI.NavMeshPath();
        line = transform.GetComponent<LineRenderer>();
        line.enabled = isNavigating;
    }

    // Update is called once per frame
    void Update()
    {
        if(isNavigating && targetPosition != Vector3.zero)
        {
            NavMesh.CalculatePath(transform.position, targetPosition, NavMesh.AllAreas, path);
            line.positionCount = path.corners.Length;
            line.SetPositions(path.corners);
        }

        if (isNavigating && isWithinMetersOfTarget(5)) {
            ArSceneManager.instance.Arrived();
        }

        
    }

    public void SetCurrentTarget(string targetName)
    {
        Target currentTarget = targetObjects.Find(x => x.name.ToLower().Equals(targetName.ToLower()));
        if(currentTarget != null)
        {
            targetPosition = currentTarget.positionObject.transform.position;
            Debug.Log("Set current target");
        }
    }

    public void ToggleLineVisibility() {
        isNavigating = !isNavigating;
        line.enabled = isNavigating;
        Debug.Log(isNavigating);
    }


    private bool isWithinMetersOfTarget(int meters) {
        return Vector3.Distance(targetPosition, transform.position) < meters;
    }


}
