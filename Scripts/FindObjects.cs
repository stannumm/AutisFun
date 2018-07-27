using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public  class FindObjects {
    Text text;

    public  void  findtexture(Texture2D []tex)
    {

        GameObject.Find("Button").GetComponent<Image>().overrideSprite = Sprite.Create(tex[0], new Rect(0, 0, tex[0].width, tex[0].height), new Vector2(0.5f, 0.5f));
        GameObject.Find("Button1").GetComponent<Image>().overrideSprite = Sprite.Create(tex[1], new Rect(0, 0, tex[1].width, tex[1].height), new Vector2(0.5f, 0.5f));

     
    }
    public  void findtext(string Question)
    {
        text = GameObject.Find("QuestionText").GetComponent<Text>();
        text.text = Question;
    }

}
