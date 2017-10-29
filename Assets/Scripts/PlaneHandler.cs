using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneHandler : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out hit);
            if (hit.transform != null)
            {
                if (hit.transform.gameObject.name == "Plane")
                {
                    Debug.Log("On Plane");
                }
            }
        }        
    }


}
