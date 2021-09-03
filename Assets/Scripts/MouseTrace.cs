using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTrace : MonoBehaviour
{
    Camera cam;
    Vector3 fingerPos;
    public GameObject shell;
    Transform t;

    float[] heldTime = new float[8]
    {
        0.0f,
        0.0f,
        0.0f,
        0.0f,
        0.0f,
        0.0f,
        0.0f,
        0.0f
    };

    float[] refireTime = new float[8]
    {
        0.25f,
        0.25f,
        0.25f,
        0.25f,
        0.25f,
        0.25f,
        0.25f,
        0.25f
    };

    bool[] fired = new bool[8]
    {
        false,
        false,
        false,
        false,
        false,
        false,
        false,
        false
    };

    private void Start()
    {
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;


        // Bit shift the index of the layer (8) to get a bit mask
        int layerMask = 1 << 8;


        // This would cast rays only against colliders in layer 8.
        // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
        layerMask = ~layerMask;

        if (Input.GetButton("Fire1"))
        {
            Vector3 mousePos = Input.mousePosition;
            {
                //Debug.Log(mousePos.x);
                //Debug.Log(mousePos.y);
                Physics.Raycast(ray, out hit, 100f, layerMask);
                if(!fired[0]) Instantiate(shell, hit.point, Quaternion.identity);
                fired[0] = true;
                heldTime[0] += Time.deltaTime;
                Debug.Log(heldTime[0]);
                if(heldTime[0] > 0.25f)
                {
                    refireTime[0] -= Time.deltaTime;
                    if (refireTime[0] < 0.0f)
                    {
                        Instantiate(shell, hit.point, Quaternion.identity);
                        refireTime[0] = Random.Range(0.15f, 0.40f);
                    }
                }
            }
        }
        else
        {
            heldTime[0] = 0.0f;
            fired[0] = false;
        }
        
        //fingerPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position); //Mobile
        fingerPos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //Desktop
    }

    // See Order of Execution for Event Functions for information on FixedUpdate() and Update() related to physics queries
    void FixedUpdate()
    {
        
    }
}
