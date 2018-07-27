using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class whalemove : MonoBehaviour {

	public float movement;
    void Start()
    {
        AudioSource audio;
        audio = GetComponent<AudioSource>();
        audio.Play(44100);  
    }
	void Update () {
		if(transform.position.x < 270 && transform.position.x > 0)
		{   
			transform.Translate(0,0,-movement*Time.deltaTime);
		}
		else if (transform.position.x > 270 )
		{

			transform.Translate(0, 0, movement * Time.deltaTime);
			transform.Rotate(0,180,0);
		}
		if (transform.position.x > -270 && transform.position.x < 0)
		{
			transform.Translate(0, 0, -movement * Time.deltaTime);
		}
		else if (transform.position.x < -270)
		{

			transform.Translate(0, 0, movement * Time.deltaTime);
			transform.Rotate(0, 180, 0);
		}
		else if (transform.position.x == 0)
		{
			Debug.Log("0");
		}
	}
}

