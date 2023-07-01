using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TasksText : MonoBehaviour
{
    [SerializeField] string taskName;
    [SerializeField] TextMeshProUGUI inputText;

    private void Start() 
    {
        inputText.text = PlayerPrefs.GetString(taskName);  
    }
    
    public void SavePlayerPrefs()
    {
        PlayerPrefs.SetString(taskName, inputText.text);  
    }
}
