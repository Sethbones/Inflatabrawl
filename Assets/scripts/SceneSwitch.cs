using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    public string sceneName;
    public void LoadScene()
    {
        Debug.Log(message: "loadingscene");
        SceneManager.LoadScene(sceneName);
    }
}
