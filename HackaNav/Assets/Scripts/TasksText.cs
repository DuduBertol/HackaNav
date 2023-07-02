using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TasksText : MonoBehaviour
{
    [SerializeField] string taskName;
    [SerializeField] TMP_InputField inputFieldText;

    private void Start() 
    {
        inputFieldText = GetComponent<TMP_InputField>();
        inputFieldText.text = PlayerPrefs.GetString(taskName);  
    }
    
    public void SavePlayerPrefs()
    {
        PlayerPrefs.SetString(taskName, inputFieldText.text);  
    }
}
