using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Will generate a glow where the shell explodes
public class Glow : MonoBehaviour
{
    float timer = 1.0f;
    Renderer r;
    Global g;
    Color c;

    float red = 1.0f;
    float green = 1.0f;
    float blue = 1.0f;
    float alpha = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        r = GetComponent<Renderer>();
        g = GameObject.Find("~Global").GetComponent<Global>();
        c = g.ReturnColor();
        red = c.r;
        green = c.g;
        blue = c.b;
        c.a = alpha;
        r.material.color = c;
        Debug.Log(c);
    }

    // Update is called once per frame
    void Update()
    {
        if(timer > 0.75f)
        {
            alpha = (1.0f - timer) * 4;
            c = new Color(red, green, blue, alpha);
            c.a *= 0.5f;
            r.material.color = c;
        } 
        else
        {
            alpha = timer;
            c = new Color(red, green, blue, timer);
            c.a *= 0.5f;
            r.material.color = c;
        }
        timer -= Time.deltaTime;
    }
}
