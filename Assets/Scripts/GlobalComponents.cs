using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GlobalComponents : MonoBehaviour {

    public static int reward = 100;
    public static int damagesPaid = 150;
    public static int burntBuildings = 0;
    public static int totalBuildings = 78;
    public Text moneyCount;
    public Text truckCount;
    public Text buildingCountText;

    public GameObject Buildings = null;
    List<Building> list = new List<Building>();
    // Use this for initialization
    void Start () {
        Buildings = GameObject.Find("Obstacle");
        gameObject.GetComponentsInChildren(list);
	}
	
	// Update is called once per frame
	void Update () {
        moneyCount.text = Player.reward.ToString();
        truckCount.text = Player.fireTrucksOwned.ToString();
        buildingCountText.text = burntBuildings.ToString() + " / " + totalBuildings.ToString();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MenuScene");
        }
    }
}
