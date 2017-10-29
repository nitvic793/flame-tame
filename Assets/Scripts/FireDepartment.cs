using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDepartment : MonoBehaviour
{

    private Renderer buildingRenderer = null;
    private Color defaultColor;
    public Canvas canvas;
    private bool canvasVisible = false;
    private bool clickedDept = false;
    public static bool allTrucksDeployed = false;

    // Use this for initialization
    void Start()
    {
        buildingRenderer = GetComponent<Renderer>();
        defaultColor = buildingRenderer.material.color;
        //canvas.gameObject.SetActive(canvasVisible);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("trucks " + allTrucksDeployed);
    }

    void OnMouseOver()
    {
        //If your mouse hovers over the GameObject with the script attached, output this message
        buildingRenderer.material.color = Color.green;
        if (Input.GetMouseButton(0))
        {
            clickedDept = true;
            //canvas.gameObject.SetActive(true);
        }
    }

    private void DrawTitle()
    {
        Vector3 V = Camera.main.WorldToScreenPoint(this.transform.position);
        GUIStyle style = new GUIStyle();
        style.border.left = 0;
        style.fontSize = 14;
        GUI.TextArea(new Rect(V.x - 50, Screen.height - V.y - 50, 120, 30), "Fire HQ");
    }

    private void OnGUI()
    {
        DrawTitle();
        if (clickedDept && !allTrucksDeployed)
        {
            Vector3 V = Camera.main.WorldToScreenPoint(this.transform.position);
            if(GUI.Button(new Rect(V.x, Screen.height - V.y, 120, 30), "Deploy (" + Player.fireTrucksAvailable.ToString() + ")"))
            {
                DeployFireTruck();
                clickedDept = false;
            }
            if(GUI.Button(new Rect(V.x + 125, Screen.height - V.y, 120, 30), "Buy (Cost:2000)"))
            {
                if(Player.reward >= 2000)
                {
                    Player.reward -= 2000;
                    Player.fireTrucksAvailable += 1;
                    Player.fireTrucksOwned += 1;
                }
                clickedDept = false;
            }
            if (GUI.Button(new Rect(V.x + 250, Screen.height - V.y, 30, 30), "X"))
            {
                clickedDept = false;
            }

        }
        else if (clickedDept && allTrucksDeployed)
        {
            Vector3 V = Camera.main.WorldToScreenPoint(this.transform.position);
            if(GUI.Button(new Rect(V.x, (Screen.height - V.y) - 60, 200, 50), "All trucks are deployed"))
            {
                clickedDept = false;
            }
            if (GUI.Button(new Rect(V.x , Screen.height - V.y, 120, 30), "Buy (Cost:2000)"))
            {
                if (Player.reward >= 2000)
                {
                    Player.reward -= 2000;
                    Player.fireTrucksAvailable += 1;
                    Player.fireTrucksOwned += 1;
                    allTrucksDeployed = false;
                }
                clickedDept = false;
            }
            if (GUI.Button(new Rect(V.x + 130, Screen.height - V.y, 30, 30), "X"))
            {
                clickedDept = false;
            }
        }


    }

    void OnMouseExit()
    {
        //The mouse is no longer hovering over the GameObject so output this message each frame
        buildingRenderer.material.color = defaultColor;
    }

    public void DeployFireTruck()
    {
        Debug.Log(Player.fireTrucksAvailable);
        var fireTruckGameObject = GameObject.Find("FireTruckHandler");
        var fireTruckHandler = fireTruckGameObject.GetComponent<FireTruckHandler>();
        if (Player.fireTrucksAvailable >= 1)
        {
            Debug.Log("inside " + Player.fireTrucksAvailable);
            fireTruckHandler.DeployFireTruck();
        }
        else if (Player.fireTrucksAvailable <= 0)
        {
            //display no more trucks available
            allTrucksDeployed = true;
        }
    }

    public void RemoveCanvas()
    {
        canvas.gameObject.SetActive(false);
    }
}
