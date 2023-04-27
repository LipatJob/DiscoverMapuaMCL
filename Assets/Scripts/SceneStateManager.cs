using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SceneState
{
    public string StartingLocation= "";
    public string SelectedDestination = "";
}

public class SceneStateManager : MonoBehaviour
{

    public static SceneState instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = new SceneState();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
