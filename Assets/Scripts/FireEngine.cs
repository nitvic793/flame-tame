using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FireEngine : MonoBehaviour
{
    /// <summary>
    /// Currently available fuel
    /// </summary>
    public float Fuel = 100.0F;

    /// <summary>
    /// Transform of destination object
    /// </summary>
    public Transform destinationTransform = null;

    public Transform fireHQTransform = null;

    /// <summary>
    /// Capacity of fire fighers for fire truck
    /// </summary>
    public int fireFighterCapacity = 4;

    public bool isGoingBackToHQ = false;

    public bool isSelected = false;

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
    }

    /// <summary>
    /// Processes Input. Update destination if clicked building is on fire.
    /// </summary>
    private void ProcessInput()
    {
        if (!isSelected && Input.GetMouseButton(0))
        {
            RaycastHit hit;
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out hit);
            if (hit.transform != null)
            {
                bool hasObject = false;
                if (hit.transform.parent != null)
                {
                    hasObject = hit.transform.parent.Equals(gameObject.transform);
                }

                if (gameObject.Equals(hit.transform.gameObject) || hasObject)
                {
                    isSelected = true;
                    DeselectOtherEngines();
                    Debug.Log("Selected");
                }
            }
        }
        else if (Input.GetMouseButton(0) && isSelected) //if left click
        {
            RaycastHit hit;
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out hit);
            if (hit.transform != null)
            {
                buildingOnFire = hit.transform.gameObject.GetComponent<Building>();
                var hq = hit.transform.gameObject.GetComponent<FireDepartment>();
                if (hq != null)
                {
                    isGoingBackToHQ = false;
                    destinationTransform = null;
                    isSelected = false;
                }
                else if (buildingOnFire != null && buildingOnFire.IsOnFire)
                {
                    destinationTransform = hit.transform;
                    isGoingBackToHQ = false;
                    isSelected = false;
                }
            }
        }
    }

    /// <summary>
    /// Update position of fire engine. If near building on fire, extinguish fire.
    /// </summary>
    private void UpdateFireEngine()
    {
        if (isGoingBackToHQ)
        {
            navMeshAgent = transform.GetComponent<NavMeshAgent>();
            navMeshAgent.destination = fireHQTransform.position;
            if(Vector3.Distance(fireHQTransform.position, transform.position) < 8)
            {
                isGoingBackToHQ = false;
                Destroy(this.gameObject);
                Player.fireTrucksAvailable += 1;
                Fuel = 100f;
                if (FireDepartment.allTrucksDeployed)
                {
                    FireDepartment.allTrucksDeployed = false;
                }
            }
        }
        else if (destinationTransform != null && buildingOnFire != null && buildingOnFire.IsOnFire && Fuel>0)
        {
            if (navMeshAgent != null && navMeshAgent.remainingDistance == 0 && Vector3.Distance(buildingOnFire.transform.position, transform.position) < 10)
            {
                buildingOnFire.fireBeingPutOut = true;
            }
            else
            {
                UpdateFuel(Time.deltaTime);
            }

            navMeshAgent = transform.GetComponent<NavMeshAgent>();
            navMeshAgent.destination = destinationTransform.position;
        }
        else
        {
            buildingOnFire = null;
            destinationTransform = null;
        }
    }

    /// <summary>
    /// Reduce fuel for units travelled.
    /// </summary>
    /// <param name="deltaTime"></param>
    private void UpdateFuel(float deltaTime)
    {
        totalFuelTime += deltaTime;
        if (totalFuelTime > 2f)
        {
            totalFuelTime = 0f;
            Fuel -= 1f;
        }
    }

    private void DeselectOtherEngines()
    {
        var fireEngines = FindObjectsOfType<FireEngine>();
        foreach(var fireEngine in fireEngines)
        {
            if (!fireEngine.gameObject.Equals(gameObject))
            {
                fireEngine.isSelected = false;
            }
        }
    }

    void OnGUI()
    {
        Vector2 screenPoint = RectTransformUtility.WorldToScreenPoint(Camera.main, transform.position);
        if (isSelected)
        {
            if (GUI.Button(new Rect(screenPoint.x, Screen.height - screenPoint.y, 50, 30), new GUIContent("Refuel")))
            {
                //code here
                Debug.Log("Test");
                isSelected = false;
                isGoingBackToHQ = true;
                destinationTransform = null;
            }
        }
    }


}
