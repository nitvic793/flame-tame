using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{

    public GlobalComponents globalComponent = new GlobalComponents();
    
    private Renderer buildingRenderer = null;
    private Color defaultColor;

    public int id;
    public int fireStartTime;       //In seconds
    public int fireIntensityLevel;
    public int buildingHealth = 100;
    public bool IsOnFire = false;
    public bool burntDown = false;
    public bool fireBeingPutOut = false;
    public int peopleCapacity;
    public int priority;
    public float fireHitRate = 20.0f;
    public float waterHitRate = 1.0f;
    public int water = 10;
    public Building next;

    private float timer = 0.0f;
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
            timer += Time.deltaTime;
            if (timer >= fireHitRate)
            {
                Burning(fireIntensityLevel);
                timer = 0.0f;
            }
            timer += Time.deltaTime;
            if (fireBeingPutOut)
            {
                if (timer >= waterHitRate)
                {
                    PutOutFire(water);
                    timer = 0.0f;
                }
            }
        }
        else
        {
            buildingRenderer.material.color = defaultColor;
        }
    }

    public void Burning(int fireIntensity)
    {
        fireIntensityLevel = fireIntensity;
            IsOnFire = true;
            buildingHealth -= fireIntensityLevel;
            if(buildingHealth <= 0)
            {
                IsOnFire = false;
                burntDown = true;
                Destroy(this.gameObject);
                Player.reward -= globalComponent.damagesPaid;
        }
    }

    public void PutOutFire(int waterPressure)
    {
        if (IsOnFire && !burntDown)
        {
            fireIntensityLevel -= waterPressure;
            if (fireIntensityLevel <= 0 && IsOnFire)
            {
                IsOnFire = false;

                Destroy(this.gameObject.transform.GetChild(0).gameObject);
                buildingHealth = 100;
                Player.reward += globalComponent.reward;
            }
        }
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    public GameObject GetObject()
    {
        return this.gameObject;
    }
}
