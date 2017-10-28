using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PathFinder : MonoBehaviour
{
    /// <summary>
    /// Currently available fuel
    /// </summary>
    public float Fuel = 100.0F;

    /// <summary>
    /// Transform of destination object
    /// </summary>
    public Transform destinationTransform = null;

    /// <summary>
    /// Capacity of fire fighers for fire truck
    /// </summary>
    public int fireFighterCapacity = 4;

    private Building buildingOnFire = null;
    private NavMeshAgent navMeshAgent = null;
    private float totalFuelTime = 0;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
        UpdateFireEngine();
        UpdateFuel();
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
            if (navMeshAgent != null && navMeshAgent.remainingDistance == 0 && Vector3.Distance(buildingOnFire.transform.position, transform.position) < 15)
            {
                buildingOnFire.IsOnFire = false;
            }

            navMeshAgent = transform.GetComponent<NavMeshAgent>();
            navMeshAgent.destination = destinationTransform.position;
        }
    }

    /// <summary>
    /// Reduce fuel for units travelled.
    /// </summary>
    /// <param name="deltaTime"></param>
    private void UpdateFuel()
    {
    }


}
