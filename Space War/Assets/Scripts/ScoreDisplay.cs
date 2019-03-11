using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreDisplay : MonoBehaviour {

    TextMeshProUGUI scoreText;
    Points points;

	// Use this for initialization
	void Start () {
        scoreText = GetComponent<TextMeshProUGUI>();
        points = FindObjectOfType<Points>();
	}
	
	// Update is called once per frame
	void Update () {
        scoreText.text = points.GetScore().ToString();
	}
}
