using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spark : MonoBehaviour {

    Vector3 sparkVelocity = new Vector3(0.0f, 0.0f, 0.0f);
    Renderer r;
    float timer = 2.0f;
    float gravity = 3.0f;
    Color c;

    Global g;

    public bool angular = false;
    public float AngleRangeMin = 45.0f;
    public float AngleRangeMax = 45.0f;
    public float AngleVelocity = 1.0f;

	// Use this for initialization
	void Start () {
        Lookup l = GameObject.Find("~Lookup Table").GetComponent<Lookup>();
        g = GameObject.Find("~Global").GetComponent<Global>();
        r = GetComponent<Renderer>();
        if (angular)
        {
            sparkVelocity = l.GenAngular(AngleRangeMin, AngleRangeMax) * Random.Range(0.5f * AngleVelocity, 1.1f * AngleVelocity);
        }
        else
        {
            sparkVelocity = l.GenVelocity() * Random.Range(0.9f, 1.1f);
        }
        c = g.ReturnColor();



        r.material.color = c;
    }
	
	// Update is called once per frame
	void Update () {
        this.transform.localPosition += new Vector3((sparkVelocity.x * sparkVelocity.z) * Time.deltaTime, (sparkVelocity.y * sparkVelocity.z) * Time.deltaTime, 0.0f);
        
        
        c.a = 1.0f;
        r.material.color = c;
        
	}
}
