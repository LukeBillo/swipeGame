using UnityEngine;
using System.Collections;

public class enemySpawner : MonoBehaviour {

    public float rate = 1;

    private float timerStart = 0;

    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        timerStart += Time.deltaTime;
        if (timerStart > rate)
        {
            // time is up...spawn a new enemy
            var enemy = (GameObject)Instantiate(Resources.Load("Enemy"), transform.localPosition, Quaternion.identity, transform);
            timerStart = 0;
            enemy.transform.position += new Vector3(Random.Range(-500, 500), 0, 0 );
        }
	}
}
