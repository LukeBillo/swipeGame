using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class score : MonoBehaviour {

    private int highestScore = 0;
    private Text scoreText;

	// Use this for initialization
	void Start () {
        scoreText = GetComponent<Text>();
        scoreText.text = "Score: " + highestScore.ToString();
    }
	
	// Update is called once per frame
	void Update () {
        int playerHeight = (int)GameObject.FindGameObjectWithTag("Player").transform.position.y;
        if (playerHeight > highestScore)
        {
            highestScore = playerHeight;
            scoreText.text = "Score: " + highestScore.ToString();
        }
        
	}
}
