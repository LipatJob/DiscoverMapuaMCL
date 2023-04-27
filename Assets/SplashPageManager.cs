using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashPageManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(passiveMe(2));
    }

    void LoadArScene()
    {
        SceneManager.LoadScene("AR 1");
    }


    IEnumerator passiveMe(int secs)
    {
        yield return new WaitForSeconds(secs);
        LoadArScene();
    }

}
