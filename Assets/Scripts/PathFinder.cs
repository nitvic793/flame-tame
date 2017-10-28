using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PathFinder : MonoBehaviour
{

    public Transform destinationTransform = null;
    public Vector3? destinationPosition = null;
    private Building buildingOnFire = null;
    private NavMeshAgent navMeshAgent = null;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
        UpdateFireEngine();        
    }

    /// <summary>
    /// Processes Input. Update destination if clicked building is on fire.
    /// </summary>
    private void ProcessInput()
    {
        if (Input.GetMouseButton(0)) //if left click
        {
            RaycastHit hit;
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out hit);
            if (hit.transform != null)
            {
                buildingOnFire = hit.transform.gameObject.GetComponent<Building>();
                if (buildingOnFire != null && buildingOnFire.IsOnFire)
                    destinationTransform = hit.transform;
            }
        }
    }

    /// <summary>
    /// Update position of fire engine. If near building on fire, extinguish fire.
    /// </summary>
    private void UpdateFireEngine()
    {
        if (destinationTransform != null)
        {
            if (navMeshAgent != null && navMeshAgent.remainingDistance == 0)
            {
                buildingOnFire.IsOnFire = false;
            }

            navMeshAgent = transform.GetComponent<NavMeshAgent>();
            navMeshAgent.destination = destinationTransform.position;
        }
        else if (destinationPosition != null)
        {
            transform.GetComponent<NavMeshAgent>().destination = destinationPosition.Value;
        }
    }


}
