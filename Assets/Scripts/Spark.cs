using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spark : MonoBehaviour {

    Vector3 sparkVelocity = new Vector3(0.0f, 0.0f, 0.0f);
    Renderer r;
    float timer = 2.0f;
    float gravity = 3.0f;
    Color c;

    public Global g;

	// Use this for initialization
	void Start () {
        Lookup l = GameObject.Find("~Lookup Table").GetComponent<Lookup>();
        r = GetComponent<Renderer>();
        sparkVelocity = l.GenVelocity() * Random.Range(0.9f, 1.1f); ;
        int rand_c = (int)Random.Range(0.0f, 7.0f);
        if (rainbow)
        {
            switch (rand_c)
            {
                case (0):
                    c = new Color(Random.Range(0.5f, 1.0f), 0.0f, 0.0f);
                    break;
                case (1):
                    c = new Color(Random.Range(0.5f, 1.0f), Random.Range(0.25f, 0.75f), 0.0f);
                    break;
                case (2):
                    c = new Color(Random.Range(0.5f, 1.0f), Random.Range(0.5f, 1.0f), 0.0f);
                    break;
                case (3):
                    c = new Color(0.0f, Random.Range(0.5f, 1.0f), 0.0f);
                    break;
                case (4):
                    c = new Color(0.0f, 0.0f, Random.Range(0.5f, 1.0f));
                    break;
                case (5):
                    c = new Color(0.0f, Random.Range(0.5f, 1.0f), Random.Range(0.5f, 1.0f));
                    break;
                case (6):
                    c = new Color(Random.Range(0.5f, 1.0f), 0.0f, Random.Range(0.5f, 1.0f));
                    break;
                default:
                    Debug.Log("ERROR: Invalid color picked out of range");
                    break;
            }
        }
        else
        {
            c = new Color(Random.Range(0.5f, 1.0f), Random.Range(0.5f, 1.0f), Random.Range(0.5f, 1.0f));
        }

        
        r.material.color = c;
    }
	
	// Update is called once per frame
	void Update () {
        this.transform.localPosition += new Vector3((sparkVelocity.x * sparkVelocity.z) * Time.deltaTime, (sparkVelocity.y * sparkVelocity.z) * Time.deltaTime, 0.0f);
        
        
        c.a = 1.0f;
        r.material.color = c;
        
	}
}
