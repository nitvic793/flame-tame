using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Building : MonoBehaviour {

    public int id;
    public int fireStartTime;       //In seconds
    public int fireIntensityLevel;
    public int buildingHealth;
    public bool isBurning;
    public bool burntDown;
    public Building next;

    public Building() { }

    public Building(Building tower)
    {
        id = 0;
        fireStartTime = 0;
        fireIntensityLevel = 0;
        buildingHealth = 0;
        isBurning = false;
        burntDown = false;
    }

    public void AddBuilding(Building newTower)
    {
        if (next == null)
        {
            //add new building values
            next = new Building(newTower);
        }
        else
        {
            AddBuilding(newTower.next);
        }
    }
 }
