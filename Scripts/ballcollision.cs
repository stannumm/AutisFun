using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballcollision : MonoBehaviour {

    public List<Color> colors;
    public AudioSource wrong,correct;
    public GameObject stars;
    public ParticleSystem ps;
    private GameObject starsclone;
    private GameObject[] objects;
   void Start()
    {
        stars = Resources.Load("explode_2") as GameObject;
        objects = GameObject.FindGameObjectsWithTag("kova");

        for (int i = 0; i < 3; i++)
        {
            colors.Add(objects[i].GetComponentInChildren<Renderer>().material.color);
        }

    }

    public void OnCollisionEnter(Collision collision)
    {
        
        
        if (collision.collider.tag == "control")
        {
            if (collision.collider.GetComponentInParent<Renderer>().material.color ==
                GetComponent<Renderer>().material.color)
            {
                starsclone = Instantiate(stars, transform.position, Quaternion.identity);
                ballcontrollerscript.point++;
                correct.Play();
            }
            else {
                wrong.Play();
                
            }
            Destroy(gameObject, wrong.clip.length+0.1f);
            Destroy(starsclone, 2);

        }
        else if (collision.collider.tag == "ground")
        {
            if (colors.Contains(GetComponent<Renderer>().material.color))
                wrong.Play();
            else
            {
                ballcontrollerscript.point++;
                correct.Play();
            }
            Destroy(gameObject, wrong.clip.length+0.1f);
        }
        
    }

}
