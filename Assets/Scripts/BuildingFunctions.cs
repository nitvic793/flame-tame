using UnityEngine;
using System.Collections;

public class BuildingFunctions : MonoBehaviour {

    GlobalRequisites prerequisites = new GlobalRequisites();

    float chanceOfCachingFire(Building currentTower)
    {
        float chanceOfFire;
        int fireInterval;
        if (currentTower.isBurning)
        {
            return 1;
        }
        else
        {
            fireInterval = prerequisites.currentGameTime - currentTower.fireStartTime;        // time in seconds since the building last caught fire
            fireInterval = Mathf.Clamp(fireInterval, prerequisites.MIN_FIRE_INTERVAL, prerequisites.MAX_FIRE_INTERVAL);
            chanceOfFire = (fireInterval * chanceOfCachingFire(currentTower.next) * Random.Range(0f, 0f)) / prerequisites.MAX_FIRE_INTERVAL;
            return chanceOfFire;
        }
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
