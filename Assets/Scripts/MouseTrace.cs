using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTrace : MonoBehaviour
{
    Camera cam;
    Vector3 fingerPos;
    public GameObject shell;
    public GameObject shellKitty;
    public GameObject shellCrackle;
    public GameObject shellDog;
    Transform t;

    Global g;

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

    public AudioSource[] snd_Explosion = new AudioSource[4];
    int snd_Explosion_Current = 0;
    int snd_Explosion_Max = 4;

    public AudioSource[] snd_Crackle = new AudioSource[5];
    int snd_Crackle_Current = 0;
    int snd_Crackle_Max = 5;

    public AudioSource[] snd_Kitty = new AudioSource[6];
    int snd_Kitty_Current = 0;
    int snd_Kitty_Max = 5;

    public AudioSource[] snd_Dog = new AudioSource[6];
    int snd_Dog_Current = 0;
    int snd_Dog_Max = 5;

    private void Start()
    {
        g = GameObject.Find("~Global").GetComponent<Global>();
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
                if (!fired[0])
                {
                    float soundPitch = 0.7f + ((hit.point.y + 4.5f) / 10.0f) * 0.4f;
                    if (g.kitty_mode)
                    {
                        Instantiate(shellKitty, hit.point, Quaternion.identity);
                        FireSoundKitty(soundPitch);
                    }
                    else if (g.dog_mode)
                    { 
                        Instantiate(shellDog, hit.point, Quaternion.identity);
                        FireSoundDog(soundPitch);
                    }
                    else Instantiate(shell, hit.point, Quaternion.identity);

                    
                    FireSoundExplosion(soundPitch);
                }
                
                fired[0] = true;
                heldTime[0] += Time.deltaTime;
                
                if(heldTime[0] > 0.25f)
                {
                    refireTime[0] -= Time.deltaTime;
                    if (refireTime[0] < 0.0f)
                    {
                        Instantiate(shellCrackle, hit.point, Quaternion.identity);
                        float soundPitch = 0.7f + ((hit.point.y + 4.5f) / 10.0f) * 0.4f;
                        FireSoundCrackle(soundPitch);
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
    void FireSoundExplosion(float pitch)
    {
        snd_Explosion[snd_Explosion_Current].pitch = pitch;
        snd_Explosion[snd_Explosion_Current].Play();
        snd_Explosion_Current++;
        if (snd_Explosion_Current >= snd_Explosion_Max) snd_Explosion_Current = 0;
    }

    void FireSoundCrackle(float pitch)
    {
        snd_Kitty[snd_Kitty_Current].pitch = pitch;
        snd_Crackle[snd_Crackle_Current].Play();
        snd_Crackle_Current++;
        if (snd_Crackle_Current >= snd_Crackle_Max) snd_Crackle_Current = 0;
    }

    void FireSoundKitty(float pitch)
    {
        snd_Kitty[snd_Kitty_Current].pitch = pitch;
        snd_Kitty[snd_Kitty_Current].Play();
        snd_Kitty_Current++;
        if (snd_Kitty_Current >= snd_Kitty_Max) snd_Kitty_Current = 0;
    }

    void FireSoundDog(float pitch)
    {
        snd_Dog[snd_Dog_Current].pitch = pitch;
        snd_Dog[snd_Dog_Current].Play();
        snd_Dog_Current++;
        if (snd_Dog_Current >= snd_Dog_Max) snd_Dog_Current = 0;
    }
}
