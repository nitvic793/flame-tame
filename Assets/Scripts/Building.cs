using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{

    
    public int fireIntensity = 0;
    private Renderer buildingRenderer = null;
    private Color defaultColor;

    public int id;
    public int fireStartTime;       //In seconds
    public int fireIntensityLevel;
    public int buildingHealth = 100;
    public bool IsOnFire = false;
    public bool burntDown = false;
    public int peopleCapacity;
    public int priority;
    public Building next;


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

    void Burning()
    {
        if (!IsOnFire)
        {
            IsOnFire = true;
            buildingHealth -= fireIntensityLevel;

            if(buildingHealth <= 0)
            {
                IsOnFire = false;
                burntDown = true;
            }
        }
    }

    void PutOutFire(int waterPressure)
    {
        if (IsOnFire && !burntDown)
        {
            fireIntensityLevel -= waterPressure;
            if(fireIntensityLevel <= 0)
            {
                IsOnFire = false;
            }
        }
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }
}
