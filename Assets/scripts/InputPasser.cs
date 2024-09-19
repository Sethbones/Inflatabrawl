using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputPasser : MonoBehaviour
{
    public PlayerInput PlayerControls;
    public GameObject AssignedObject;
    // Start is called before the first frame update
    void Start()
    {
        PlayerControls = GetComponent<PlayerInput>();
        AssignedObject.GetComponent<CharselSquareCode>().inheritedinput = PlayerControls;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
