using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma : MonoBehaviour {

    public float movementVelocity;
    public float xLimit;

	// Use this for initialization
	void Start ()
    {
        xLimit = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x - GetComponent<SpriteRenderer>().bounds.extents.x;
	}
	
	// Update is called once per frame
	void Update ()
    {
        float mouseHorizontalDirection = Input.GetAxis("Mouse X"); // -1 = pra esquerda, 0 = parado e 1  = pra direita
        GetComponent<Transform>().position += Vector3.right * mouseHorizontalDirection * movementVelocity * Time.deltaTime;
        float actualX = transform.position.x;
        actualX = Mathf.Clamp(actualX, -xLimit, xLimit);
        transform.position = new Vector3(actualX, transform.position.y, transform.position.z);
	}
}
