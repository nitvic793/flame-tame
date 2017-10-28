using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDepartment : MonoBehaviour
{

    private Renderer buildingRenderer = null;
    private Color defaultColor;
    public Canvas canvas;
    private bool canvasVisible = false;

    // Use this for initialization
    void Start()
    {
        buildingRenderer = GetComponent<Renderer>();
        defaultColor = buildingRenderer.material.color;
        canvas.gameObject.SetActive(canvasVisible);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnMouseOver()
    {
        //If your mouse hovers over the GameObject with the script attached, output this message
        buildingRenderer.material.color = Color.green;
        if (Input.GetMouseButton(0))
        {
            canvas.gameObject.SetActive(true);
        }
    }

    void OnMouseExit()
    {
        //The mouse is no longer hovering over the GameObject so output this message each frame
        buildingRenderer.material.color = defaultColor;
    }

    public void DeployFireTruck()
    {
        var fireTruckGameObject = GameObject.Find("FireTruckHandler");
        var fireTruckHandler = fireTruckGameObject.GetComponent<FireTruckHandler>();
        fireTruckHandler.DeployFireTruck();
    }

    public void RemoveCanvas()
    {
        canvas.gameObject.SetActive(false);
    }
}
