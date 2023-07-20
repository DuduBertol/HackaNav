using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColectPoints : MonoBehaviour
{
    [SerializeField] List<GameObject> colectPointsList = new List<GameObject>();
    [SerializeField] Button newControlPoint;
    [SerializeField] GameObject panelDestroyAllConfirmed;
    public bool destroyAll;
    [SerializeField] int pointCount;
    [SerializeField] float buttonPosY = 1600;
    [SerializeField] GameObject limitPanel;
    
    private void Start() 
    {
        pointCount = PlayerPrefs.GetInt("pointCount");

        if(pointCount != 0)
        {
            buttonPosY = PlayerPrefs.GetFloat("buttonPos");
            LeanTween.moveLocalY(newControlPoint.gameObject, buttonPosY, 0.1f).setEaseInOutExpo();
        }

        for(int i = 0; i < colectPointsList.Count; i++)
        {
            if(PlayerPrefs.GetString("point" + i.ToString()) == "true")
            {
                colectPointsList[i].SetActive(true);
            }
            if(PlayerPrefs.GetString("point" + i.ToString()) == "false")
            {
                colectPointsList[i].SetActive(false);
            } 
        }
    }


    public void NewControlPoint()
    {
        if(pointCount < 15)
        {
            destroyAll = false;
            colectPointsList[pointCount].SetActive(true);
            PlayerPrefs.SetString("point" + pointCount.ToString(), "true");
            
            buttonPosY -= 350;
            LeanTween.moveLocalY(newControlPoint.gameObject, buttonPosY, 0.1f).setEaseInOutExpo();
            PlayerPrefs.SetFloat("buttonPos", buttonPosY);
            
            pointCount++;
            PlayerPrefs.SetInt("pointCount", pointCount);
        }
        else
        {
            newControlPoint.gameObject.SetActive(false);
            Debug.Log("Limite máximo de Pontos de Coleta");
            //criar texto temporario

            LeanTween.scale(limitPanel, new Vector3(1,1,1), 0.6f).setEaseOutExpo();
        }
        
    }

    public void DestroyAll()
    {
        panelDestroyAllConfirmed.LeanScale(new Vector3(1, 1, 1), 0.3f);
        //puxar tela de confirmação
        //confirmou
        //setar variavel true
        //destruir GO
    }

    public void DestroyAllConfirmed()
    {
        panelDestroyAllConfirmed.LeanScale(new Vector3(0, 0, 0), 0.3f);
        destroyAll = true;
        for(int i = 0; i < colectPointsList.Count; i++)
        {
            PlayerPrefs.SetString("point" + i.ToString(), "false");
            colectPointsList[i].gameObject.SetActive(false);
            colectPointsList[i].GetComponent<PointDropdown>().ClearPoint();
        }
        pointCount = 0;
        PlayerPrefs.SetInt("pointCount", 0);
        buttonPosY = 1600;
        LeanTween.moveLocalY(newControlPoint.gameObject, buttonPosY, 0.1f).setEaseInOutExpo();
        PlayerPrefs.SetFloat("buttonPos", buttonPosY);
        newControlPoint.gameObject.SetActive(true);
        LeanTween.scale(limitPanel, new Vector3(0,0,0), 0.1f);
    }

    public void Cancel()
    {
        panelDestroyAllConfirmed.LeanScale(new Vector3(0, 0, 0), 0.3f);
    }

    
    
}
