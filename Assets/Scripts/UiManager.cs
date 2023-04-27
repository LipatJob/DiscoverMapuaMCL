using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public enum UiState { Orienting, Selecting, Navigating, Arrived }

public class UiManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject OrientationModeUi;
    public GameObject SelectionModeUi;
    public GameObject NavigationModeUi;
    public GameObject ArrivedModeUi;
    public TMP_Dropdown targetDropDown;


    public UiState currentUiState { get; private set; } = UiState.Orienting;

    public static UiManager instance;
    

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetUiState(UiState state)
    {
        currentUiState = state;
        OrientationModeUi.SetActive(false);
        SelectionModeUi.SetActive(false);
        NavigationModeUi.SetActive(false);
        ArrivedModeUi.SetActive(false);
        switch (state)
        {
            case UiState.Orienting:
                OrientationModeUi.SetActive(true);
                break;
            case UiState.Selecting:
                SelectionModeUi.SetActive(true);
                break;
            case UiState.Navigating:
                NavigationModeUi.SetActive(true);
                break;
            case UiState.Arrived:
                ArrivedModeUi.SetActive(true);
                break;
            default:
                break;
        }
    }

    public void OnDestinationConfirmed() {
        ArSceneManager.instance.SelectedDestination(targetDropDown.options[targetDropDown.value].text);
    }
}   
