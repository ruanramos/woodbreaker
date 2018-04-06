using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorDeArestas : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Camera cam = Camera.main;
        EdgeCollider2D colider = GetComponent<EdgeCollider2D>();
        Vector2 inferiorLeft = cam.ScreenToWorldPoint(new Vector3(-0, 0, 0));
        Vector2 superiorLeft = cam.ScreenToWorldPoint(new Vector3(0, Screen.height, 0));
        Vector2 superiorRight = cam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        Vector2 inferiorRight = cam.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0));
        colider.points = new Vector2[5] { inferiorLeft, superiorLeft, superiorRight, inferiorRight, inferiorLeft };
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
