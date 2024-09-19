using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GlobalVars : MonoBehaviour
{
    //basically the project wide global variables currently does nothing
    public static GlobalVars instance;

    public List<Transform> StaticTargets;
    public bool Debug = false;
    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.F2))
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else if (Input.GetKeyDown(KeyCode.F3))
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
