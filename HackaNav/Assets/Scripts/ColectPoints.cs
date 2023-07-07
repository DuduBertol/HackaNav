using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColectPoints : MonoBehaviour
{
    [SerializeField] Transform parentRectTransform;
    [SerializeField] Button newControlPoint;
    [SerializeField] GameObject model;
    [SerializeField] GameObject panelDestroyAllConfirmed;
    public bool destroyAll;
    [SerializeField] int pointCount;
    
    


    public void NewControlPoint()
    {
        if(pointCount < 15)
        {
            destroyAll = false;
            Instantiate(model, newControlPoint.transform.position, Quaternion.identity, parentRectTransform);
            pointCount++;
            newControlPoint.gameObject.LeanMove(newControlPoint.gameObject.GetComponent<RectTransform>().position += new Vector3(0, -400, 0), 0.1f).setEaseInOutExpo();
        }
        else
        {
            newControlPoint.gameObject.SetActive(false);
            Debug.Log("Limite máximo de Pontos de Coleta");
        }
        
    }

    public void DestroyAll()
    {
        panelDestroyAllConfirmed.SetActive(true);
        panelDestroyAllConfirmed.LeanScale(new Vector3(1, 1, 1), 0.3f);
        //puxar tela de confirmação
        //confirmou
        //setar variavel true
        //destruir GO
    }

    public void DestroyAllConfirmed()
    {
        panelDestroyAllConfirmed.SetActive(false);
        destroyAll = true;
        pointCount = 0;
        LeanTween.moveY(newControlPoint.gameObject.GetComponent<RectTransform>(), 1500, 0.5f).setEaseInOutExpo();
        newControlPoint.gameObject.SetActive(true);
    }

    public void Cancel()
    {
        panelDestroyAllConfirmed.SetActive(false);
    }

    
}
