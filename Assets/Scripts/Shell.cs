using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    float timer = 1.0f;
    public Vector3 shellVelocity = new Vector3(0.0f, 0.0f, 0.0f);
    float gravity = 0.10f;
    public enum ShellType
    {
        Standard,
        Crackle
    };

    public ShellType CurrentShellType = ShellType.Standard;

    // Start is called before the first frame update
    void Start()
    {
        if(CurrentShellType == ShellType.Crackle)
        {
            this.transform.localPosition += new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f), 0.0f);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (CurrentShellType == ShellType.Standard)
        {
            shellVelocity.y -= gravity * Time.deltaTime;
            this.transform.localPosition += shellVelocity;
        }
        
        timer -= Time.deltaTime;
        if (timer < 0.0f) DestroyObject(this.gameObject);
        
    }
}
