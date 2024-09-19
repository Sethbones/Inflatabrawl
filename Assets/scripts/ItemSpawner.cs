using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class ItemSpawner : MonoBehaviour
{
    public const float _spawntimer = 500; //this is the amount of time it takes for each spawn
    public float _TimeBetweenSpawns; //inherits spawntimer
    public bool _HasItemSpawned = false; //check if an item spawned
    public bool _HasSpawnCollected = false; //check if the spawned item has been collected
    public GameObject[] _ItemsToSpawn; //will definitely be replaced but for now its fine. its great for whitelisting certain weapons as is but not much for anything else 
    public GameObject _SpawnSelection; //the item that's chosen to be spawned
    public GameObject[] _ItemWhiteList; //if or when the itemspawner gets rewritten this will get used
    public GameObject[] _ItemBlackList; //if or when the itemspawner gets rewritten this will get used
    // Start is called before the first frame update
    void Start()
    {
        //_SpawnSelection = _ItemsToSpawn[Random.Range(0, _ItemsToSpawn.Length)];
        //_SpawnSelection = Random.Range(0, _ItemsToSpawn.Length);
        //Instantiate(_SpawnSelection, transform);
    }
    /// <summary>
    /// so basically here's the gist of how this works:
    /// there's an array of gameobjects assigned manually for now that spawns a random gameobject one from said array and spawns it
    /// it also checks if an item already exists in the current space and doesn't spawn more
    /// the idea here is to keep everything public so "modders" can make levels and assign specific weapons for said level
    /// </summary>
    // Update is called once per frame
    void Update()
    {
        _SpawnSelection = _ItemsToSpawn[Random.Range(0, _ItemsToSpawn.Length)]; //might not be the most efficient thing ever but fuck it this works for now
        if (!_HasItemSpawned || _TimeBetweenSpawns <= 0)
        {
            Instantiate(_SpawnSelection, transform);
            _HasItemSpawned = true;
            _HasSpawnCollected = false;
            _TimeBetweenSpawns = _spawntimer;
        }


        if (_HasItemSpawned)
        {
            if (_HasSpawnCollected)
            {
                _TimeBetweenSpawns -= 200 * Time.deltaTime;
            }
        }

        if (transform.childCount > 0)
        {
            _HasSpawnCollected = false;
        }
        else { _HasSpawnCollected = true; }

    }
}
