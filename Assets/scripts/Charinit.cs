using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charinit : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform[] PlayerSpawns;

    [SerializeField] private GameObject PlayerPrefab;

    void Start()
    {
        var playerConfigs = PlayerConfigurationManager.Instance.GetPlayerConfigs().ToArray();
        for (int i = 0; i < playerConfigs.Length; i++) //for every player that joined, instantiate a player
        {
            var player = Instantiate(PlayerPrefab, PlayerSpawns[i].position, PlayerSpawns[i].rotation, gameObject.transform);
            player.GetComponent<Playermovement>().InitializePlayer(playerConfigs[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
