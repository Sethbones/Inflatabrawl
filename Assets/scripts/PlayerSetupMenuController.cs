using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSetupMenuController : MonoBehaviour
{
    private int PlayerIndex;

    [SerializeField] private TextMeshProUGUI TitleText;
    [SerializeField] private GameObject ReadyPanel;
    [SerializeField] private GameObject MenuPanel;
    [SerializeField] private Button readyButton;

    //costume shaneninagans
    public List<Sprite> CostumeColors = new List<Sprite>();
    public List<Sprite> CostumeEyes = new List<Sprite>();
    public List<Sprite> CostumeHats = new List<Sprite>();
    public int CurrentCostumeSpriteColors = 0;
    public int CurrentCostumeSpriteEyes = 0;
    public int CurrentCostumeSpriteHats = 0;
    public Image ColorPart;
    public Image EyesPart;
    public Image CostumePart;


    private float ignoreInputTime = 1.5f;
    private bool inputEnabled;

    public void setPlayerIndex(int pi)
    {
        PlayerIndex = pi;
        TitleText.SetText("Player " + (pi + 1).ToString());
        ignoreInputTime = Time.time + ignoreInputTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > ignoreInputTime)
        {
            inputEnabled = true; //fix later
        }
    }

    public void SetColor()
    {
        if (!inputEnabled) { return; }

        //PlayerConfigurationManager.Instance.setPlayercolor //oh yeah i didn't code that part
        ReadyPanel.SetActive(true);
        readyButton.interactable = true;
        MenuPanel.SetActive(false);
        readyButton.Select();
    }

    public void movecolorleft()
    {
        if (CurrentCostumeSpriteColors <= 0)
        {
            CurrentCostumeSpriteColors = 0;
        }
        else
        {
            CurrentCostumeSpriteColors -= 1;
            ColorPart.sprite = CostumeColors[CurrentCostumeSpriteColors];
        }
    }

    public void movecolorright()
    {
        if (CurrentCostumeSpriteColors >= CostumeColors.Count)
        {
            CurrentCostumeSpriteColors = CostumeColors.Count - 1;
        }
        else
        {
            CurrentCostumeSpriteColors += 1;
            ColorPart.sprite = CostumeColors[CurrentCostumeSpriteColors];
        }
    }


    public void moveeyeleft()
    {
        if (CurrentCostumeSpriteEyes <= 0)
        {
            CurrentCostumeSpriteEyes = 0;
        }
        else
        {
            CurrentCostumeSpriteEyes -= 1;
            EyesPart.sprite = CostumeEyes[CurrentCostumeSpriteEyes];
        }
    }

    public void moveeyeright()
    {
        if (CurrentCostumeSpriteEyes >= CostumeEyes.Count)
        {
            CurrentCostumeSpriteEyes = CostumeEyes.Count - 1;
        }
        else
        {
            CurrentCostumeSpriteEyes += 1;
            EyesPart.sprite = CostumeEyes[CurrentCostumeSpriteEyes];
        }
    }


    public void movehatleft()
    {
        if (CurrentCostumeSpriteHats <= 0)
        {
            CurrentCostumeSpriteHats = 0;
        }
        else
        {
            CurrentCostumeSpriteHats -= 1;
            CostumePart.sprite = CostumeHats[CurrentCostumeSpriteHats];
        }
    }

    public void movehatright()
    {
        if (CurrentCostumeSpriteHats >= CostumeHats.Count)
        {
            CurrentCostumeSpriteHats = CostumeHats.Count - 1;
        }
        else
        {
            CurrentCostumeSpriteHats += 1;
            CostumePart.sprite = CostumeHats[CurrentCostumeSpriteHats];
        }
    }


    public void ReadyPlayer()
    {
        if (!inputEnabled) { return; }

        PlayerConfigurationManager.Instance.ReadyPlayer(PlayerIndex);
        PlayerConfigurationManager.Instance.SetPlayerColor(PlayerIndex, CostumeColors[CurrentCostumeSpriteColors]);
        PlayerConfigurationManager.Instance.SetPlayerEyes(PlayerIndex, CostumeEyes[CurrentCostumeSpriteEyes]);
        PlayerConfigurationManager.Instance.SetPlayerHat(PlayerIndex, CostumeHats[CurrentCostumeSpriteHats]);
        readyButton.gameObject.SetActive(false);
    }

    public void randomcustomize()
    {
        var randomcolor = CurrentCostumeSpriteColors = Random.Range(0, CostumeColors.Count);
        var randomeyes = CurrentCostumeSpriteEyes = Random.Range(0, CostumeEyes.Count);
        var randomhat = CurrentCostumeSpriteHats = Random.Range(0, CostumeHats.Count);
        ColorPart.sprite = CostumeColors[randomcolor];
        EyesPart.sprite = CostumeEyes[randomeyes];
        CostumePart.sprite = CostumeHats[randomhat];
    }
}
