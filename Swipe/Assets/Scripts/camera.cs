using UnityEngine;
using System.Collections;

public class camera : MonoBehaviour {

    public GameObject TrackedObject;

    private Vector3 prevPos;
    private Vector3 offset;

	// Use this for initialization
	void Start () {
        prevPos = TrackedObject.transform.position;
	}
	
	void LateUpdate () {
        // vertically...we will only follow the object if it's not falling and its half way up the screen
        var screenCoords = Camera.main.WorldToScreenPoint(TrackedObject.transform.position);
        Debug.Log(TrackedObject.GetComponent<Rigidbody>().velocity.y);
        if ((screenCoords.y > (Camera.main.pixelHeight / 2)) && (TrackedObject.GetComponent<Rigidbody>().velocity.y > 0))
        {
            offset = TrackedObject.transform.position - prevPos;
            transform.position += offset;
        }
        prevPos = TrackedObject.transform.position;
        // horizontally...always follow the object
        transform.position = new Vector3(TrackedObject.transform.position.x, transform.position.y, transform.position.z);
	}
}
