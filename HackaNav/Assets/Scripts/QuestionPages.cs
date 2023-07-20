using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionPages : MonoBehaviour
{
    [SerializeField] List<GameObject> questionPages = new List<GameObject>();
    public void OpenAbout()
    {
        LeanTween.scale(questionPages[0], new Vector3(1, 1, 1), 0.3f).setEaseInExpo();
    }
    public void CloseAbout()
    {
        LeanTween.scale(questionPages[0], new Vector3(0, 0, 0), 0.3f).setEaseOutExpo();
    }

    public void OpenCadastro()
    {
        LeanTween.scale(questionPages[1], new Vector3(1, 1, 1), 0.3f).setEaseInExpo();
    }
    public void CloseCadastro()
    {
        LeanTween.scale(questionPages[1], new Vector3(0, 0, 0), 0.3f).setEaseOutExpo();
    }

    public void OpenPerfil()
    {
        LeanTween.scale(questionPages[2], new Vector3(1, 1, 1), 0.3f).setEaseInExpo();
    }

    public void ClosePerfil()
    {
        LeanTween.scale(questionPages[2], new Vector3(0, 0, 0), 0.3f).setEaseOutExpo();
    }
    public void OpenHome()
    {
        LeanTween.scale(questionPages[3], new Vector3(1, 1, 1), 0.3f).setEaseInExpo();
    }
    public void CloseHome()
    {
        LeanTween.scale(questionPages[3], new Vector3(0, 0, 0), 0.3f).setEaseOutExpo();
    }

    public void OpenRotina()
    {
        LeanTween.scale(questionPages[4], new Vector3(1, 1, 1), 0.3f).setEaseInExpo();
    }
    public void CloseRotina()
    {
        LeanTween.scale(questionPages[4], new Vector3(0, 0, 0), 0.3f).setEaseOutExpo();
    }

    public void OpenCalendario()
    {
        LeanTween.scale(questionPages[5], new Vector3(1, 1, 1), 0.3f).setEaseInExpo();
    }
    public void CloseCalendario()
    {
        LeanTween.scale(questionPages[5], new Vector3(0, 0, 0), 0.3f).setEaseOutExpo();
    }

    public void OpenRanking()
    {
        LeanTween.scale(questionPages[6], new Vector3(1, 1, 1), 0.3f).setEaseInExpo();
    }
    public void CloseRanking()
    {
        LeanTween.scale(questionPages[6], new Vector3(0, 0, 0), 0.3f).setEaseOutExpo();
    }
}
