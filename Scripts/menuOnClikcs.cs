using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuOnClikcs : MonoBehaviour {

    // Use this for initialization

    public void menuOnClick () {

        AudioSource audio;
        audio = GetComponent<AudioSource>();
        audio.Play();

        if (SceneManager.GetActiveScene().name == "MenuLevel")
        {
            Application.Quit();
        }
        else
        {
            Invoke("sceneswap",audio.time+0.1f);
        }
	}
    public void sceneswap()
    {
        SceneManager.LoadScene("MenuLevel");
    }
}
