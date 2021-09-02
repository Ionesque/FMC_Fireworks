using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    Vector3 shellVelocity = new Vector3(0.0f, 0.0f, 0.0f);
    float gravity = 30.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        shellVelocity.z -= gravity * Time.deltaTime;
        this.transform.localPosition += new Vector3(0.0f, shellVelocity.z, 0.0f);
    }
}
