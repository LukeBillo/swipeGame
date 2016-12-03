using UnityEngine;
using System.Collections;

public class playerScript : MonoBehaviour {

    private Vector3 direction = Vector3.zero;
    private Vector2 swipeOrigin = Vector2.zero;
    private Vector2 swipeEnd = Vector2.zero;

    Rigidbody rbPlayer;
    Transform playerTransform;

    private bool flickPlayer = false;
    private bool attached = false;

    public float speed;

    // Use this for initialization
    void Start () {
        rbPlayer = GetComponent<Rigidbody>();
        playerTransform = GetComponent<Transform>();

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

                if (attached)
                {
                    playerTransform.parent = null;
                    rbPlayer.isKinematic = false;
                }

                direction = new Vector3(swipeEnd.x - swipeOrigin.x, swipeEnd.y - swipeOrigin.y, 0);

                flickPlayer = true;
            }
        }

        // when the player drops off the screen...kill him!
        Vector3 screenCoords = Camera.main.WorldToScreenPoint(transform.position);
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

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("We collided!");

        if (collision.transform.tag == "Enemy")
        {
            playerTransform.parent = collision.transform;
            rbPlayer.isKinematic = true;
            attached = true;
        }
    }
}
