using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArSceneManager : MonoBehaviour
{

    public static ArSceneManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        UiManager.instance.SetUiState(UiState.Orienting);
        QrCodeRecenter.instance.isScanning = true;
        SetNavigationTarget.instance.isNavigating = false;

    }


    public void QrCodeScanned(string startingLocation) {
        QrCodeRecenter.instance.isScanning = false;
        UiManager.instance.SetUiState(UiState.Selecting);
        SceneStateManager.instance.StartingLocation = startingLocation;
    }

    public void SelectedDestination(string destination) {
        UiManager.instance.SetUiState(UiState.Navigating);
        SceneStateManager.instance.SelectedDestination = destination;
        SetNavigationTarget.instance.SetCurrentTarget(destination);
        SetNavigationTarget.instance.isNavigating = true;
    }

    public void Arrived() {
        UiManager.instance.SetUiState(UiState.Arrived);
        SetNavigationTarget.instance.isNavigating = false;

    }

    public void NavigateAgain() {
        UiManager.instance.SetUiState(UiState.Orienting);
        SceneStateManager.instance.StartingLocation = "";
        SceneStateManager.instance.SelectedDestination = "";
        QrCodeRecenter.instance.isScanning = true;
        SetNavigationTarget.instance.isNavigating = false;
    }


    // Update is called once per frame
    void Update()
    {
        
    }


}
