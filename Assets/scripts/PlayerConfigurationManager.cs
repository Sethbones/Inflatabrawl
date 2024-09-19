using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerConfigurationManager : MonoBehaviour
{
    private List<PlayerConfiguration> PlayerConfigs;

    [SerializeField] private int MaxPlayers = 8; //not used i think
    [SerializeField] private int MinPlayers = 2;
    
    public static PlayerConfigurationManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.Log("SINGLETON - Trying to create another instance of singleton!!");
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
            PlayerConfigs = new List<PlayerConfiguration>();
        }
    }
    public void SetPlayerColor(int index, Sprite color)
    {
        PlayerConfigs[index].playercolor = color;
    }
    public void SetPlayerEyes(int index, Sprite eyes)
    {
        PlayerConfigs[index].playereyes = eyes;
    }
    public void SetPlayerHat(int index, Sprite hat)
    {
        PlayerConfigs[index].playerhat = hat;
    }
    //public void SetPlayerCostumes()
    //{

    //}
    public void ReadyPlayer(int index)
    {
        PlayerConfigs[index].IsReady = true;
        if (PlayerConfigs.Count >= MinPlayers && PlayerConfigs.All(p => p.IsReady == true))
        {
            SceneManager.LoadScene("DebugMap");
        }
    }

    public void HandlePlayerJoin(PlayerInput pi)
    {
        Debug.Log("player joined" + pi.playerIndex);

        if (!PlayerConfigs.Any(p => p.PlayerIndex == pi.playerIndex))
        {
            pi.transform.SetParent(transform);
            PlayerConfigs.Add(new PlayerConfiguration(pi));
        }
    }
    public List<PlayerConfiguration> GetPlayerConfigs()
    {
        return PlayerConfigs;
    }
}

public class PlayerConfiguration
{
    public PlayerConfiguration(PlayerInput pi)
    {
        PlayerIndex = pi.playerIndex;
        Input = pi;
    }
    public PlayerInput Input { get; set; }
    public int PlayerIndex { get; set; }
    public bool IsReady { get; set; }
    public Sprite playercolor { get; set; }
    public Sprite playereyes { get; set; }
    public Sprite playerhat { get; set; }
}
