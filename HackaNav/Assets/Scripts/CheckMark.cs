using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckMark : MonoBehaviour
{

    private RoutineSystem routineSystem;
    [SerializeField] int checkButtonID;
    
    private void Awake() 
    {
        routineSystem = FindObjectOfType<RoutineSystem>();
    }

    private void Start() 
    {
        routineSystem.checkedList[checkButtonID] = PlayerPrefs.GetInt(checkButtonID.ToString());

        if(routineSystem.checkedList[checkButtonID] == 1)
        {
            this.gameObject.GetComponent<Image>().sprite = routineSystem.checkedSprite;
        }
        if(routineSystem.checkedList[checkButtonID] == 2)
        {
            this.gameObject.GetComponent<Image>().sprite = routineSystem.notCheckedSprite;
        }
        if(routineSystem.checkedList[checkButtonID] == 3)
        {
            this.gameObject.GetComponent<Image>().sprite = routineSystem.anyCheckedSprite;
        }
        if (routineSystem.checkedList[checkButtonID] >= 4)
        {
            routineSystem.checkedList[checkButtonID] = 1;
            this.gameObject.GetComponent<Image>().sprite = routineSystem.checkedSprite;
        }
    }

    public void CheckMarkClick()
    {
        routineSystem.checkedList[checkButtonID]++;

        if(routineSystem.checkedList[checkButtonID] == 1)
        {
            this.gameObject.GetComponent<Image>().sprite = routineSystem.checkedSprite;
        }
        if(routineSystem.checkedList[checkButtonID] == 2)
        {
            this.gameObject.GetComponent<Image>().sprite = routineSystem.notCheckedSprite;
        }
        if(routineSystem.checkedList[checkButtonID] == 3)
        {
            this.gameObject.GetComponent<Image>().sprite = routineSystem.anyCheckedSprite;
        }
        if (routineSystem.checkedList[checkButtonID] >= 4)
        {
            routineSystem.checkedList[checkButtonID] = 1;
            this.gameObject.GetComponent<Image>().sprite = routineSystem.checkedSprite;
        }

        SavePlayerPrefs();
    }

    private void SavePlayerPrefs()
    {
        for (int i = 0; i < routineSystem.checkedList.Count; i++)
        {
            if(checkButtonID == i) 
            {
                PlayerPrefs.SetInt(checkButtonID.ToString(), routineSystem.checkedList[i]); 
            }   
        }
    }
}
