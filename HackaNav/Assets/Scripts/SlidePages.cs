using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlidePages : MonoBehaviour
{
    
    public GameObject pageController;
    public List<float> pageLocationX = new List<float>(); // move-se a PageController
    public List<float> pageLocationY = new List<float>(); // move-se individualmente cada página
    public List<GameObject> scrollPages = new List<GameObject>();
    public int pageID;
    //public List<bool> buttonClick = new List<bool>();

    void Update()
    {
        //SLIDE TOUCH LOGIC
        /* if(Input.touchCount > 0 )
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
        } */
    }

    private void ClickButton()
    {
        for(int i = 0; i < scrollPages.Count; i++)
        {
            if(pageID == i)
            {
                LeanTween.moveX(pageController.GetComponent<RectTransform>(), pageLocationX[i], 0.5f).setEaseInOutExpo();
                LeanTween.moveY(scrollPages[i].GetComponent<RectTransform>(), pageLocationY[i], 0.5f).setEaseInOutExpo(); 
            }
        }
    }

    #region SLIDE MENU BAR -- PAGE ID
    public void AboutButton() { pageID = 0; ClickButton();}
    public void ConfigButton() { pageID = 1; ClickButton();}
    public void PerfilButton() { pageID = 2; ClickButton(); }
    public void HomeButton() { pageID = 3; ClickButton();}
    public void RoutineButton() { pageID = 4; ClickButton();}
    public void CalendarButton() { pageID = 5; ClickButton();}
    public void RankingButton() { pageID = 6; ClickButton();}

    /* public void AboutButton() 
    {
        LeanTween.moveX(pageController.GetComponent<RectTransform>(), pageLocationX[0], 0.5f).setEaseInOutExpo();
        LeanTween.moveY(scrollPages[0].GetComponent<RectTransform>(), pageLocationY[0], 0.5f).setEaseInOutExpo();
    }
    public void ConfigButton() 
    {
        LeanTween.moveX(pageController.GetComponent<RectTransform>(), pageLocationX[0], 0.5f).setEaseInOutExpo();
        LeanTween.moveY(scrollPages[0].GetComponent<RectTransform>(), pageLocationY[0], 0.5f).setEaseInOutExpo();
    }
    public void PerfilButton() 
    {
        LeanTween.moveX(pageController.GetComponent<RectTransform>(), pageLocationX[0], 0.5f).setEaseInOutExpo();
        LeanTween.moveY(scrollPages[0].GetComponent<RectTransform>(), pageLocationY[0], 0.5f).setEaseInOutExpo();
    }
    public void HomeButton() 
    {
        LeanTween.moveX(pageController.GetComponent<RectTransform>(), pageLocationX[0], 0.5f).setEaseInOutExpo();
        LeanTween.moveY(scrollPages[0].GetComponent<RectTransform>(), pageLocationY[0], 0.5f).setEaseInOutExpo();
    }
    public void RoutineButton() 
    {
        LeanTween.moveX(pageController.GetComponent<RectTransform>(), pageLocationX[0], 0.5f).setEaseInOutExpo();
        LeanTween.moveY(scrollPages[0].GetComponent<RectTransform>(), pageLocationY[0], 0.5f).setEaseInOutExpo();
    }
    public void CalendarButton() 
    {
        LeanTween.moveX(pageController.GetComponent<RectTransform>(), pageLocationX[0], 0.5f).setEaseInOutExpo();
        LeanTween.moveY(scrollPages[0].GetComponent<RectTransform>(), pageLocationY[0], 0.5f).setEaseInOutExpo();
    }
    public void RankingButton() 
    {
        LeanTween.moveX(pageController.GetComponent<RectTransform>(), pageLocationX[0], 0.5f).setEaseInOutExpo();
        LeanTween.moveY(scrollPages[0].GetComponent<RectTransform>(), pageLocationY[0], 0.5f).setEaseInOutExpo();
    } */
    #endregion
}
