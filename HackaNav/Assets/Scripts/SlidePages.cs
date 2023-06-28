using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidePages : MonoBehaviour
{
    
    public GameObject pageController;
    public List<float> pageLocationX = new List<float>(); 
    public List<GameObject> scrollPages = new List<GameObject>();

    void Update()
    {
        //SLIDE TOUCH LOGIC
        if(Input.touchCount > 0 )
        {
            Touch t = Input.GetTouch(0);

            if(t.phase == TouchPhase.Moved)
            {
                if(t.deltaPosition.y > 25)
                {
                    LeanTween.moveY(pageController.GetComponent<RectTransform>(), pageController.GetComponent<RectTransform>().position.x + 1080f, 0.5f).setEaseInOutExpo();
                }
                
                if(t.deltaPosition.y < -25)
                {
                    LeanTween.moveY(pageController.GetComponent<RectTransform>(), (pageController.GetComponent<RectTransform>().position.x - 1080f), 0.5f).setEaseInOutExpo();
                }
            }
        }
    }

    #region SLIDE MENU BAR
    public void AboutButton()
    {
        LeanTween.moveX(pageController.GetComponent<RectTransform>(), pageLocationX[0], 0.5f).setEaseInOutExpo();
        LeanTween.moveY(scrollPages[0].GetComponent<RectTransform>(), 0, 0.5f).setEaseInOutExpo();

    }
    public void ConfigButton()
    {
        LeanTween.moveX(pageController.GetComponent<RectTransform>(), pageLocationX[1], 0.5f).setEaseInOutExpo();
        LeanTween.moveY(scrollPages[3].GetComponent<RectTransform>(), 0, 0.5f).setEaseInOutExpo();
    }
    public void PerfilButton()
    {
        LeanTween.moveX(pageController.GetComponent<RectTransform>(), pageLocationX[2], 0.5f).setEaseInOutExpo();
        LeanTween.moveY(scrollPages[3].GetComponent<RectTransform>(), 0, 0.5f).setEaseInOutExpo();
    }
    public void HomeButton()
    {
        LeanTween.moveX(pageController.GetComponent<RectTransform>(), pageLocationX[3], 0.5f).setEaseInOutExpo();
        LeanTween.moveY(scrollPages[3].GetComponent<RectTransform>(), -1468f, 0.5f).setEaseInOutExpo();
    }
    public void RoutineButton()
    {
        LeanTween.moveX(pageController.GetComponent<RectTransform>(), pageLocationX[4], 0.5f).setEaseInOutExpo();
        LeanTween.moveY(scrollPages[3].GetComponent<RectTransform>(), 0, 0.5f).setEaseInOutExpo();
    }
    public void CalendarButton()
    {
        LeanTween.moveX(pageController.GetComponent<RectTransform>(), pageLocationX[5], 0.5f).setEaseInOutExpo();
        LeanTween.moveY(scrollPages[3].GetComponent<RectTransform>(), 0, 0.5f).setEaseInOutExpo();
    }public void RankingButton()
    {
        LeanTween.moveX(pageController.GetComponent<RectTransform>(), pageLocationX[6], 0.5f).setEaseInOutExpo();
        LeanTween.moveY(scrollPages[3].GetComponent<RectTransform>(), 0, 0.5f).setEaseInOutExpo();
    }

    
    #endregion
}
