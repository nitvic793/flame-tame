using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDepartment : MonoBehaviour
{

    private Renderer buildingRenderer = null;
    private Color defaultColor;
    // Use this for initialization
    void Start()
    {
        buildingRenderer = GetComponent<Renderer>();
        defaultColor = buildingRenderer.material.color;
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnMouseOver()
    {
        //If your mouse hovers over the GameObject with the script attached, output this message
        buildingRenderer.material.color = Color.green;
    }

    void OnMouseExit()
    {
        //The mouse is no longer hovering over the GameObject so output this message each frame
        buildingRenderer.material.color = defaultColor;
    }
}
