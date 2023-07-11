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
    
    private void Start() 
    {
          
    }


    public void NewControlPoint()
    {
        if(pointCount < 15)
        {
            destroyAll = false;
            colectPointsList[pointCount].SetActive(true);
            newControlPoint.gameObject.LeanMove(newControlPoint.gameObject.GetComponent<RectTransform>().position += new Vector3(0, -475, 0), 0.1f).setEaseInOutExpo();
            pointCount++;
        }
        else
        {
            newControlPoint.gameObject.SetActive(false);
            Debug.Log("Limite máximo de Pontos de Coleta");
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
            colectPointsList[i].gameObject.SetActive(false);
            colectPointsList[i].GetComponent<PointDropdown>().ClearPoint();
        }
        pointCount = 0;
        LeanTween.moveY(newControlPoint.gameObject.GetComponent<RectTransform>(), 1600, 0.5f).setEaseInOutExpo();
        newControlPoint.gameObject.SetActive(true);
    }

    public void Cancel()
    {
        panelDestroyAllConfirmed.LeanScale(new Vector3(0, 0, 0), 0.3f);
    }

    
    
}
