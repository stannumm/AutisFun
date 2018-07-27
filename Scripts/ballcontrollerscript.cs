using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ballcontrollerscript : MonoBehaviour {

    public static int point = 0;
    public Text text,tutorial,pointtext;
    private int ballcount;
    public GameObject ball;
    public GameObject[] balls;
    public GameObject cubeta, cubeta2, cubeta3;
    private Color[] colors = { Color.black, Color.blue, Color.green, Color.red, Color.yellow, Color.magenta };
    private void Start()
    {
        balls = new GameObject[1];
        balls[0] = Instantiate(ball, new Vector3(5f, 2.2f, 0f), Quaternion.identity);
        balls[0].GetComponent<Renderer>().material.color = colors[Random.Range(0, 6)];
        ballcount = 9;

        Destroy(tutorial,5.12f);

        cubeta.GetComponentInChildren<Renderer>().material.color = colors[Random.Range(0,2)];
        cubeta2.GetComponentInChildren<Renderer>().material.color = colors[Random.Range(2, 4)];
        cubeta3.GetComponentInChildren<Renderer>().material.color = colors[Random.Range(4, 6)];



    }
    private void Update()

    {
        if (balls[0] == null && ballcount >= 0)
        {

            balls[0] = Instantiate(ball, new Vector3(5f, 2.2f, 0f), Quaternion.identity);
            balls[0].GetComponent<Renderer>().material.color = colors[Random.Range(0, 6)];
            text.text = ballcount.ToString();
            Debug.Log(ballcount);
            ballcount--;
        }
        if (GameObject.FindGameObjectsWithTag("ball").Length == 0)
            pointtext.text = "Tebrikler!\n "+"Skorun "+point.ToString();
    }
}
