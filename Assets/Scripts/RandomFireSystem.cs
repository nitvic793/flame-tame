using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomFireSystem : MonoBehaviour
{
    public GameObject FirePrefab = null;
    public int MAX_FIRE_INTENSITY = 10;
    public int MIN_FIRE_INTENSITY = 5;

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
        Vector3 firePosition;
        GameObject curretFire = null;
        totalTime += deltaTime;
        if (totalTime > nextRandomFire)
        {
            nextRandomFire = Random.Range(1, 20);
            totalTime = 0;
            int buildingToSetFire = Random.Range(0, buildings.Count);

            if (!buildings[buildingToSetFire].burntDown)
            {
                buildings[buildingToSetFire].IsOnFire = true;
                buildings[buildingToSetFire].Burning(Random.Range(MIN_FIRE_INTENSITY,MAX_FIRE_INTENSITY));
                firePosition = buildings[buildingToSetFire].GetPosition();
                curretFire = Instantiate(FirePrefab, firePosition, Quaternion.Euler(-90, -90, -90));       // load fire prefab to show building burning
                curretFire.transform.parent = buildings[buildingToSetFire].GetObject().transform;
            }
        }
    }

}
