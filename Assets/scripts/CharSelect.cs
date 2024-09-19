using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharSelect : MonoBehaviour
{
    public GameObject PlayerBasePrefab;
    public GameObject[] CharSlots;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<PlayerInputManager>().playerPrefab = CharSlots[CharSlots.Length];
    }

    // Update is called once per frame
    void Update()
    {
        //foreach (GameObject Emptyslots in CharSlots)
        //{
        //    if (Emptyslots.GetComponent<CharselSquareCode>()._Occupied == false)
        //    {
        //        if (Input.GetKeyDown(KeyCode.Q))
        //        {
        //            Emptyslots.GetComponent<CharselSquareCode>()._Occupied = true;
        //            Emptyslots.GetComponent<CharselSquareCode>()._menuState = 1;
        //            Emptyslots.GetComponent<CharselSquareCode>()._AssignedPlayerID = 1;
        //            Instantiate(PlayerBasePrefab, Emptyslots.transform);

        //        }
        //       // print(message: "player 1 is empty");
        //    }
        //    //print(Emptyslots.GetComponent<CharselSquareCode>()._Occupied);
        //}
    }

    void OnPlayerJoined(PlayerInput playerInput)
    {
        //Debug.Log(message: "hi");

        //foreach (GameObject Emptyslots in CharSlots)
        //{
        //    if (Emptyslots.GetComponent<CharselSquareCode>()._Occupied == false)
        //    {
        //        Emptyslots.GetComponent<CharselSquareCode>()._Occupied = true;
        //        Emptyslots.GetComponent<CharselSquareCode>()._menuState = 1;
        //        //Emptyslots.GetComponent<CharselSquareCode>()._Player = playerInput.gameObject;
        //        //Emptyslots.GetComponent<CharselSquareCode>().controls = playerInput;
        //        //Emptyslots.GetComponent<PlayerInput>().actions = playerInput.actions;
        //        //Emptyslots.AddComponent<PlayerInput>();
        //        break;
        //    }
        //}
    }
}