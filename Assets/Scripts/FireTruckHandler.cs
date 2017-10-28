using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTruckHandler : MonoBehaviour {

    public Transform fireDepartment = null;
    public GameObject fireTruckPrefab = null;
    public Transform startPositionTransform = null;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void DeployFireTruck()
    {
        var fireTruck = Instantiate(fireTruckPrefab, startPositionTransform.position, Quaternion.Euler(new Vector3()));
        fireTruck.GetComponent<FireEngine>().fireHQTransform = fireDepartment;
    }
}
