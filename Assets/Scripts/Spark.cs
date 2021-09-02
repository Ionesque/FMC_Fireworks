using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spark : MonoBehaviour {

    Vector3 sparkVelocity = new Vector3(0.0f, 0.0f, 0.0f);
    Renderer r;
    float timer = 2.0f;
    float gravity = 3.0f;
    Color c;

	// Use this for initialization
	void Start () {
        Lookup l = GameObject.Find("~Lookup Table").GetComponent<Lookup>();
        r = GetComponent<Renderer>();
        sparkVelocity = l.GenVelocity();
        c = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), 1.0f);
        r.material.color = c;
    }
	
	// Update is called once per frame
	void Update () {
        this.transform.localPosition += new Vector3((sparkVelocity.x * sparkVelocity.z) * Time.deltaTime, (sparkVelocity.y * sparkVelocity.z) * Time.deltaTime, 0.0f);
        
        
        c.a = 1.0f;
        r.material.color = c;
        timer -= Time.deltaTime;
        if(timer < 0.0f) DestroyObject(this.gameObject);
	}
}
