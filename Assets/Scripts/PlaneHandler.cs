using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneHandler : MonoBehaviour
{

    GameObject marker;
    // Use this for initialization
    void Start()
    {
        marker = GameObject.Find("Marker");
    }

    // Update is called once per frame
    void Update()
    {

        RaycastHit hit;
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out hit);
        if (hit.transform != null)
        {
            marker.transform.position = hit.point;
        }

    }


}
