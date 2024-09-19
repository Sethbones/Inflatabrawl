using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSpawn : MonoBehaviour
{
    public GameObject spawnedplayer;
    public int _SetPlayerID = 0; //0 = dummy i.e cannot move
    public bool _IsEnabled = true; //check if the player is even selected. not to be set directly
    public PlayerInput PlayerControls;
    // Start is called before the first frame update
    void Start()
    {
        if (spawnedplayer != null)
        {
            //Instantiate(spawnedplayer, transform);
            spawnedplayer.GetComponent<Playermovement>()._RespawnPoint = gameObject;
            spawnedplayer.GetComponent<Playermovement>()._PlayerID = _SetPlayerID;
            spawnedplayer.transform.position = gameObject.transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
