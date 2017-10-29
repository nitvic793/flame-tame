using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageResize : MonoBehaviour {

    public RectTransform transform;
	// Use this for initialization
	void Start () {
        transform = gameObject.GetComponent<RectTransform>();
        transform.sizeDelta = new Vector2(Screen.width, Screen.height);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
