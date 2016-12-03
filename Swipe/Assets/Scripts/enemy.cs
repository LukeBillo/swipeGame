using UnityEngine;
using System.Collections;

public class enemy : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 screenPoint = Camera.main.WorldToViewportPoint(transform.position);
        // if they're not in viewport then they probably shouldn't exist
        bool onScreen = ((screenPoint.x < 0) || (screenPoint.x > Camera.main.pixelWidth))
            && (screenPoint.y < 0);
        Debug.Log(screenPoint);
        if (!onScreen)
        {
            Destroy(this.gameObject);
        }
    }
}
