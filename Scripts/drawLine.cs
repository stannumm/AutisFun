using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drawLine : MonoBehaviour {

    public AudioSource correct, matchthecubes;
    public RaycastHit hit;
    public GameObject trailPrefab,lineprefab,startobject,linerenderer,rendererprefab;
    private GameObject thisTrail;
    private Vector3 startPos;
    private Plane objPlane;
    public GameObject[] objects,lines;
    public float trailLength;
    public Vector3 temppos;
    public float distances;
    public static bool haswon;
    void Start()
    {
        objPlane = new Plane(Camera.main.transform.forward * -1, this.transform.position);
        objects = GameObject.FindGameObjectsWithTag("shape");
        trailLength = 0;
    }

    void Update()
    {

        if ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) || Input.GetMouseButtonDown(0))
        {
            objects = GameObject.FindGameObjectsWithTag("shape");

            Ray mRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(mRay, out hit))
            {
                if (hit.collider.tag == "shape")
                {
                    startobject = hit.collider.gameObject;
                    thisTrail = (GameObject)Instantiate(trailPrefab, this.transform.position, Quaternion.identity);

                    distances = sort(hit.collider.gameObject,objects);

                    float rayDistance;

                    if (objPlane.Raycast(mRay, out rayDistance))
                    {
                        startPos = mRay.GetPoint(rayDistance);
                    }
                }
            }
            temppos = startPos;
        }
        else if (((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) || Input.GetMouseButton(0)))
        {
            Ray mRay = Camera.main.ScreenPointToRay(Input.mousePosition);
           
            float rayDistance;

            if (objPlane.Raycast(mRay, out rayDistance))
            {
                thisTrail.transform.position = mRay.GetPoint(rayDistance);
                trailLength += Vector3.Distance(temppos, thisTrail.transform.position);
                temppos = mRay.GetPoint(rayDistance);
            }

        }
        else if ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended) || Input.GetMouseButtonUp(0))
        {

            Ray mRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Vector3.Distance(thisTrail.transform.position, startPos) < 0.1)
            {
                Destroy(thisTrail);

            }
            else if (!Physics.Raycast(mRay, out hit))
            {
                Destroy(thisTrail);

            }
            else if (trailLength > distances +2 || trailLength < distances-2)
            {
                Destroy(thisTrail);

            }
            else
            { 
                rendererprefab = Instantiate(linerenderer);
                rendererprefab.GetComponent<LineRenderer>().SetPosition(0,hit.collider.transform.position);
                rendererprefab.GetComponent<LineRenderer>().SetPosition(1, startobject.transform.position);

                Destroy(thisTrail);
            }


            GameObject[] a = GameObject.FindGameObjectsWithTag("linerenderer");
            Debug.Log(objects.Length+" object length "+a.Length+" a length");
            if (objects.Length == a.Length)
            {
                won(objects);
                correct.Play();
                haswon = true;
                Debug.Log("cum" );
            }
            trailLength = 0;
        }
   
    }

    public float sort(GameObject g,GameObject[] objects)
    {
        float distances = 99999999;
        for(int i = 0; i < objects.Length; i++)
        {
            float distance = Vector3.Distance(g.transform.position, objects[i].transform.position);
            if (distance !=0 && distances > distance)
            {
                distances = distance;
            }
          
        }
        return distances;
    }

    public void won(GameObject[] objects)
    {
        foreach(GameObject g in objects)
        {
            g.GetComponent<MeshRenderer>().enabled = false;
        }
    }

}
