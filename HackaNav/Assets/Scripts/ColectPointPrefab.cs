using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColectPointPrefab : MonoBehaviour
{ 
    [SerializeField] Image iconImage;
    [SerializeField] List<Sprite> pointIcons = new List<Sprite>();
    private ColectPoints colectPoints;

    private void Start() 
    {
        colectPoints = FindObjectOfType<ColectPoints>();    
    }

    private void Update() 
    {
        if(colectPoints.destroyAll)
        {
            Destroy(this.gameObject, 0.1f);
        }    
    }
    public void OnSelectPoint(int value)
    {
        for(int i = 0; i < pointIcons.Count; i++) 
        if(value == i)
        {
            iconImage.sprite = pointIcons[i];
        }
    }
}
