using UnityEngine;
using System.Collections;

public class camera : MonoBehaviour {

    public GameObject TrackedObject;

    private Vector3 offset;

	// Use this for initialization
	void Start () {
	    
	}
	
	void LateUpdate () {
        var screenCoords = Camera.main.WorldToScreenPoint(TrackedObject.transform.position);
        if (screenCoords.y > (Camera.main.pixelHeight / 2))
        {
            offset = TrackedObject.transform.position - transform.position;
            transform.position += new Vector3();
        }
	}
}
