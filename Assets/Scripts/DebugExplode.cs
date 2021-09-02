using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugExplode : MonoBehaviour {

    public GameObject objSpark;

    float timer = 0.0f;

	// Use this for initialization
	void Start () {
        Instantiate(objSpark);
    }
	
	// Update is called once per frame
	void Update () {
        if (timer > 1.0f)
        {
            Instantiate(objSpark);
            timer = 0.0f;
        }
        timer += Time.deltaTime;
    }
}
