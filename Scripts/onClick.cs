using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class onClick : MonoBehaviour {

    public Button buton, buton1; 
    public AudioSource applause,wrong;
    public GameObject confetti;
    public static bool isclicked;
    // Use this for initialization
    public void Start()
    {
        isclicked = false;
        confetti.SetActive(false);
    }
    public void onclick()
    {
        isclicked = true;
        int c = 2;
        if (EventSystem.current.currentSelectedGameObject.name.Equals("Button"))
            c = 0;
        else if (EventSystem.current.currentSelectedGameObject.name.Equals("Button1"))
            c = 1;
        
        if (dbconnection.control[c] == 1)
        {
            Debug.Log("doğru");
            confetti.SetActive(true);
            applause.Play();
            Invoke("test",applause.clip.length-0.2f);
        }
        else
        {
            Debug.Log("yanlış");
            wrong.Play();
            isclicked = false;
        }
        Debug.Log(Application.streamingAssetsPath);

       
    }
    public void test()
    {
        confetti.SetActive(false);
        dbconnection.executequeries(dbconnection.dbconn, dbconnection.dbcmd);
        isclicked = false;
    }

    void Update()
    {
        if (isclicked)
        {
            buton.interactable = false;
            buton1.interactable = false;

        }
        else
        {
            buton.interactable = true;
            buton1.interactable = true;
        }
        
    }
}
