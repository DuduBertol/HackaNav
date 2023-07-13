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
    [SerializeField] TMP_InputField namePlayer;
    [SerializeField] TMP_InputField city;
    [SerializeField] TMP_Dropdown state;
    [SerializeField] Image stateImage;
    [SerializeField] List<Sprite> stateSprites = new List<Sprite>();


    public void OpenImageOptions() { panelImageOptions.LeanScale(new Vector3(1, 1, 1), 0.3f); }
    public void CloseCLick() { panelImageOptions.LeanScale(new Vector3(0, 0, 0), 0.3f); }
    public void Image1() 
    { 
        playerImage.sprite = playerSprites[0]; 
        panelImageOptions.LeanScale(new Vector3(0, 0, 0), 0.3f);
    }
    public void Image2() 
    { 
        playerImage.sprite = playerSprites[1]; 
        panelImageOptions.LeanScale(new Vector3(0, 0, 0), 0.3f);
    }

    public void Image3() 
    { 
        playerImage.sprite = playerSprites[2]; 
        panelImageOptions.LeanScale(new Vector3(0, 0, 0), 0.3f);
    }
    public void Image4() 
    { 
        playerImage.sprite = playerSprites[3]; 
        panelImageOptions.LeanScale(new Vector3(0, 0, 0), 0.3f);
    }
    public void Image5() 
    { 
        playerImage.sprite = playerSprites[4]; 
        panelImageOptions.LeanScale(new Vector3(0, 0, 0), 0.3f);
    }
    public void Image6() 
    { 
        playerImage.sprite = playerSprites[5]; 
        panelImageOptions.LeanScale(new Vector3(0, 0, 0), 0.3f);
    }
}
