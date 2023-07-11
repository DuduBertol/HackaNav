using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PointDropdown : MonoBehaviour
{
    [SerializeField] Image thisImage;
    [SerializeField] List<Sprite> pointIcons = new List<Sprite>();
    [SerializeField] string dropdownName;
    [SerializeField] TMP_Dropdown thisDropdown;
    [SerializeField] TMP_InputField thisInputField;

    void Start()
    {
        thisInputField.text = PlayerPrefs.GetString(dropdownName + "string");
        thisDropdown.value = PlayerPrefs.GetInt(dropdownName);
        thisImage.sprite = pointIcons[PlayerPrefs.GetInt(dropdownName)];
    }

    public void ChangeImage(int value)
    {
        for (int i = 0; i < pointIcons.Count; i++)
        {
            if(value == i)
            {
                thisImage.sprite = pointIcons[i];
                PlayerPrefs.SetInt(dropdownName, i);
            }
        }
    }

    public void OnTextFinish()
    {
        PlayerPrefs.SetString(dropdownName + "string", thisInputField.text);
    }

    public void ClearPoint()
    {
        thisImage.sprite = pointIcons[0];
        thisDropdown.value = 0;
        PlayerPrefs.SetInt(dropdownName, 0);
        thisInputField.text = null;
        PlayerPrefs.SetString(dropdownName + "string", thisInputField.text);
    }
}
