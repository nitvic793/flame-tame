using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelBar : MonoBehaviour
{


    //current progress
    public float barDisplay;

    public RectTransform canvasRectT;
    public RectTransform healthBar;
    public Transform objectToFollow;

    FireEngine fireEngine;

    void Start()
    {
        fireEngine = GetComponent<FireEngine>();
        objectToFollow = fireEngine.transform;
    }

    void Update()
    {
        Vector2 screenPoint = RectTransformUtility.WorldToScreenPoint(Camera.main, objectToFollow.position);
        //healthBar.anchoredPosition = screenPoint - canvasRectT.sizeDelta / 2f;
        //the player's health
        barDisplay = fireEngine.Fuel / 100;
        healthBar.sizeDelta = new Vector2(barDisplay*3, 0.2f);
        //healthBar = barDisplay * 3;
    }
}
