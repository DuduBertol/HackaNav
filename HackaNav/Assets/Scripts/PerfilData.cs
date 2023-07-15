using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PerfilData : MonoBehaviour
{
    [SerializeField] Image playerImage;
    [SerializeField] List<Sprite> playerSprites = new List<Sprite>();
    [SerializeField] GameObject panelImageOptions;
    //[SerializeField] TMP_InputField namePlayer;
    [SerializeField] TMP_InputField city;
    [SerializeField] TMP_Dropdown state;
    [SerializeField] Image stateImage;
    public List<Sprite> stateSprites = new List<Sprite>();
    public int stateID;
    [SerializeField] Color alpha;
    [SerializeField] Color normal;

    private void Start() 
    {
        playerImage.sprite = playerSprites[PlayerPrefs.GetInt("PlayerIcon")];

        //namePlayer.text = PlayerPrefs.GetString("NamePlayer");
        city.text = PlayerPrefs.GetString("CityPlayer");

        stateID = PlayerPrefs.GetInt("StateValue");
        state.value = stateID;
    }
    public void OpenImageOptions() { panelImageOptions.LeanScale(new Vector3(1, 1, 1), 0.3f); }
    public void CloseCLick() { panelImageOptions.LeanScale(new Vector3(0, 0, 0), 0.3f); }
    public void Image1() 
    { 
        playerImage.sprite = playerSprites[0]; 
        panelImageOptions.LeanScale(new Vector3(0, 0, 0), 0.3f);
        PlayerPrefs.SetInt("PlayerIcon", 0);
    }
    public void Image2() 
    { 
        playerImage.sprite = playerSprites[1]; 
        panelImageOptions.LeanScale(new Vector3(0, 0, 0), 0.3f);
        PlayerPrefs.SetInt("PlayerIcon", 1);
    }

    public void Image3() 
    { 
        playerImage.sprite = playerSprites[2]; 
        panelImageOptions.LeanScale(new Vector3(0, 0, 0), 0.3f);
        PlayerPrefs.SetInt("PlayerIcon", 2);
    }
    public void Image4() 
    { 
        playerImage.sprite = playerSprites[3]; 
        panelImageOptions.LeanScale(new Vector3(0, 0, 0), 0.3f);
        PlayerPrefs.SetInt("PlayerIcon", 3);
    }
    public void Image5() 
    { 
        playerImage.sprite = playerSprites[4]; 
        panelImageOptions.LeanScale(new Vector3(0, 0, 0), 0.3f);
        PlayerPrefs.SetInt("PlayerIcon", 4);
    }
    public void Image6() 
    { 
        playerImage.sprite = playerSprites[5]; 
        panelImageOptions.LeanScale(new Vector3(0, 0, 0), 0.3f);
        PlayerPrefs.SetInt("PlayerIcon", 5);
    }

    public void ChooseState(int value)
    {
        if (value == 0)
        {
            stateImage.color = alpha;
        }
        else
        {
            stateImage.color = normal;
        }
        for(int i = 0; i < stateSprites.Count; i++)
        {
            if(value == i)
            {

                stateImage.sprite = stateSprites[i];
                PlayerPrefs.SetInt("StateValue", value);
            }
        }
    }

    public void InputTextFinish()
    {
        //PlayerPrefs.SetString("NamePlayer", namePlayer.text);
        PlayerPrefs.SetString("CityPlayer", city.text);
    }
}
