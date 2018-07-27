using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class reloadscript : MonoBehaviour {

    // Use this for initialization
    public void reloadOnclick()
    {

        AudioSource audio;
        audio = GetComponent<AudioSource>();
        audio.Play();

        Invoke("sceneswap", audio.time + 0.1f);
        
    }
    public void sceneswap()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
