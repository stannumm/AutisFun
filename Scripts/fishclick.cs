using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class fishclick : MonoBehaviour {

    string name;
    void Start()
    {
        name = transform.name;
    }
	// Use this for initialization
	void OnMouseDown()
    {
        if (name.Equals("sardine"))
            Application.LoadLevel(1);
        else if (name.Equals("cruscarp"))
            Application.LoadLevel(2);
        else if (name.Equals("whale"))
            Application.LoadLevel(3);

    }
}
