using UnityEngine;
using System.Collections;

public class playerScript : MonoBehaviour {

    private Vector3 direction = Vector3.zero;
    private Vector2 swipeOrigin = Vector2.zero;
    private Vector2 swipeEnd = Vector2.zero;

    Rigidbody rbPlayer;

    private bool flickPlayer = false;

    public float speed;

    // Use this for initialization
    void Start () {
        rbPlayer = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        
        // if touch received
        if (Input.touchCount > 0)
        {
            // collect first touch
            Touch swipeTouch = Input.touches[0];

            if (swipeTouch.phase == TouchPhase.Began)
            {
                swipeOrigin = swipeTouch.position;
            }

            else if (swipeTouch.phase == TouchPhase.Ended)
            {
                swipeEnd = swipeTouch.position;

                direction = new Vector3(swipeEnd.x - swipeOrigin.x, swipeEnd.y - swipeOrigin.y, 0);

                flickPlayer = true;
            }
        }

        // when the player drops off the screen...kill him!
        Vector3 screenCoords = Camera.main.WorldToScreenPoint(transform.position);
        Debug.Log(screenCoords);
        if (screenCoords.y < 0)
        {
            Destroy(this.gameObject);
        }
    }

    // called during physics update
    void FixedUpdate()
    {
        if (flickPlayer)
        {
            rbPlayer.AddForce(direction * speed);
            flickPlayer = false;
        }
    }
}
