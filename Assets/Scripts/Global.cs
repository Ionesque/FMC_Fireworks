using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This will always be availiable regardless of scene
/// </summary>
public class Global : MonoBehaviour
{
    public bool rainbow_mode = false;
    
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 30;   // More time for calculations on mobile device target
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
