using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    float timer = 1.0f;
    public Vector3 shellVelocity = new Vector3(0.0f, 0.0f, 0.0f);
    float gravity = 0.10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        shellVelocity.y -= gravity * Time.deltaTime;
        Debug.Log(shellVelocity.z);
        this.transform.localPosition += shellVelocity;
        timer -= Time.deltaTime;
        if (timer < 0.0f) DestroyObject(this.gameObject);
    }
}
