using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomFireSystem : MonoBehaviour
{

    private List<Building> buildings = new List<Building>();
    float totalTime = 0.0F;
    int nextRandomFire;

    // Use this for initialization
    void Start()
    {
        gameObject.GetComponentsInChildren(buildings);
        nextRandomFire = Random.Range(1, 20);
    }

    // Update is called once per frame
    void Update()
    {
        RandomFireLoop(Time.deltaTime);
    }

    private void RandomFireLoop(float deltaTime)
    {
        totalTime += deltaTime;
        if (totalTime > nextRandomFire)
        {
            nextRandomFire = Random.Range(1, 20);
            totalTime = 0;
            int buildingToSetFire = Random.Range(0, buildings.Count);
            buildings[buildingToSetFire].IsOnFire = true;
        }
    }

}
