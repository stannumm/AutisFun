using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shapemanagerscript : MonoBehaviour {

    public Text text;
    private GameObject prefab;
    public GameObject[] shapes;
    int index = 0;
	void Start()
    {
       prefab = Instantiate(shapes[index]);
    }

	void Update ()
    {
	    if(drawLine.haswon)
        {
            Destroy(prefab,1f);
            index++;

            GameObject[] objects = GameObject.FindGameObjectsWithTag("linerenderer");

            foreach (GameObject o in objects)
                Destroy(o,1f);

            Invoke("create",1.1f);

            drawLine.haswon = false;
        }
        

        if (index == 2)
        {
            text.text = "Kutuları Birleştir\n Harfi Tamamla";
        }
        else
            text.text = "Kutuları Birleştir\n Şekli Tamamla";

        if (index == 3)
            index = 0;
    }
    public void create()
    {
        prefab = Instantiate(shapes[index]);
    }
 
}
