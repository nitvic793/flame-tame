using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{

    public bool IsOnFire = false;
    public int health = 100;
    public int fireIntensity = 0;
    private Renderer buildingRenderer = null;
    private Color defaultColor;

    // Use this for initialization
    void Start()
    {
        
        buildingRenderer = gameObject.GetComponent<Renderer>();
        defaultColor = buildingRenderer.material.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsOnFire)
        {
            buildingRenderer.material.color = Color.red;
        }
        else
        {
            buildingRenderer.material.color = defaultColor;
        }
    }

}
