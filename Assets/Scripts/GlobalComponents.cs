using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalComponents : MonoBehaviour {

    public static int reward = 100;
    public static int damagesPaid = 150;
    public Text moneyCount;
    public Text truckCount;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        moneyCount.text = Player.reward.ToString();
        truckCount.text = Player.fireTrucksOwned.ToString();
    }
}
