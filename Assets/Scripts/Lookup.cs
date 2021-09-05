using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lookup : MonoBehaviour {

    public Vector3[] velocity = new Vector3[360];
    public bool isReady = false;

    float mod = 4.0f;

	// Use this for initialization
	void Start () {
        GenTable();         // Generate lookup table
        isReady = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void GenTable()
    {
        for (int i = 0; i < 360; i++)
        {
            velocity[i].x = Mathf.Sin((Mathf.Deg2Rad * i)) * mod;
            velocity[i].y = Mathf.Cos((Mathf.Deg2Rad * i)) * mod;
        }
    }

    public Vector3 GenAngular(float min, float max) {
        int i = (int)Random.Range(min, max);
        return new Vector3(velocity[i].x, velocity[i].y, Random.Range(0.8f, 1.2f));
    }

    public Vector3 GenVelocity()
    {
        int i = (int)Random.Range(0.0f, 360.0f);
        return new Vector3(velocity[i].x, velocity[i].y, Random.Range(0.8f, 1.2f));
    }
        
}
