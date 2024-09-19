using Rewired.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharselSquareCode : MonoBehaviour
{
    public bool _Occupied;
    public int _menuState = 1;
    public int _AssignedPlayerID = 1;
    public GameObject _Player;
    public GameObject _AssignedSpawnPoint;
    public PlayerInput controls;
    public GameObject[] _ListOfColors;
    public int colortotransfer;
    public GameObject eyestotransfer;
    public GameObject hattotransfer;
    public List<Sprite> SpriteColors = new List<Sprite>();
    public List<Sprite> SpriteEyes = new List<Sprite>();
    public List<Sprite> SpriteCostumes = new List<Sprite>();
    public int CurrentSpriteColors = 0;
    public int CurrentSpriteEyes = 0;
    public int CurrentSpriteCostumes = 0;
    public SpriteRenderer ColorPart;
    public SpriteRenderer EyesPart;
    public SpriteRenderer CostumePart;
    public PlayerInput inheritedinput;
    //0 - waiting for another player
    //1 - customization
    // Start is called before the first frame update
    void Start()
    {
        //var colorinstant = Instantiate(_ListOfColors[colortotransfer], gameObject.transform);
    }

    // Update is called once per frame
    void Update()
    {
        //debug menu shit till char select is actually done
        if (Input.GetKeyDown(KeyCode.Return))
        {
            _Occupied = true;
            _menuState = 1;
        }

        //debug input for color swapping
        if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            if (CurrentSpriteColors >= SpriteColors.Count)
            {
                CurrentSpriteColors = SpriteColors.Count - 1;
            }
            else
            {
                CurrentSpriteColors += 1;
                ColorPart.sprite = SpriteColors[CurrentSpriteColors];
            }
        }
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            if (CurrentSpriteColors <= 0)
            {
                CurrentSpriteColors = 0;
            }
            else
            {
                CurrentSpriteColors -= 1;
                ColorPart.sprite = SpriteColors[CurrentSpriteColors];
            }
        }

        //debug input for Eye swapping
        if (Input.GetKeyDown(KeyCode.Keypad6))
        {
            if (CurrentSpriteEyes >= SpriteEyes.Count)
            {
                CurrentSpriteEyes = SpriteEyes.Count - 1;
            }
            else
            {
                CurrentSpriteEyes += 1;
                EyesPart.sprite = SpriteEyes[CurrentSpriteEyes];
            }
        }
        if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            if (CurrentSpriteEyes <= 0)
            {
                CurrentSpriteEyes = 0;
            }
            else
            {
                CurrentSpriteEyes -= 1;
                EyesPart.sprite = SpriteEyes[CurrentSpriteEyes];
            }
        }

        //debug input for Costume swapping
        if (Input.GetKeyDown(KeyCode.Keypad9))
        {
            if (CurrentSpriteCostumes >= SpriteCostumes.Count)
            {
                CurrentSpriteCostumes = SpriteCostumes.Count - 1;
            }
            else
            {
                CurrentSpriteCostumes += 1;
                CostumePart.sprite = SpriteCostumes[CurrentSpriteCostumes];
            }
        }
        if (Input.GetKeyDown(KeyCode.Keypad7))
        {
            if (CurrentSpriteCostumes <= 0)
            {
                CurrentSpriteCostumes = 0;
            }
            else
            {
                CurrentSpriteCostumes -= 1;
                CostumePart.sprite = SpriteCostumes[CurrentSpriteCostumes];
            }
        }

        GetComponent<Animator>().SetInteger("MenuState", _menuState);
        if (_Occupied)
        {
            _AssignedSpawnPoint.GetComponent<PlayerSpawn>().spawnedplayer = _Player;
            _AssignedSpawnPoint.GetComponent<PlayerSpawn>()._IsEnabled = true;
            _AssignedSpawnPoint.GetComponent<PlayerSpawn>().PlayerControls = controls;
            Debug.Log(controls);
        }

        if (Input.GetKeyDown(KeyCode.Keypad5))
        {
            _Player.gameObject.GetComponent<Playermovement>().Colortopass = _ListOfColors[colortotransfer];
            _Player.gameObject.GetComponent<Playermovement>().eyetopass = eyestotransfer;
            _Player.gameObject.GetComponent<Playermovement>().hattopass = hattotransfer;
        }
    }
}
