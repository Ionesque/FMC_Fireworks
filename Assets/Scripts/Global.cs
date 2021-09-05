using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This will always be availiable regardless of scene
/// </summary>
public class Global : MonoBehaviour
{
    public bool rainbow_mode = false;
    public bool kitty_mode = false;
    int rand_c = 0;
    bool exit1 = false;
    bool exit2 = false;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 30;   // More time for calculations on mobile device target
    }

    // Update is called once per frame
    void Update()
    {
        if (exit1 && exit2) Application.Quit();
    }


    public void RandColor()
    {
        rand_c = (int)Random.Range(0.0f, 7.0f);
    }
    public Color ReturnColor()
    {
        

        if (rainbow_mode)
        {
            switch (rand_c)
            {
                case (0):
                    return (new Color(Random.Range(0.5f, 1.0f), 0.0f, 0.0f));
                    break;
                case (1):
                    return (new Color(Random.Range(0.5f, 1.0f), Random.Range(0.25f, 0.75f), 0.0f));
                    break;
                case (2):
                    return (new Color(Random.Range(0.5f, 1.0f), Random.Range(0.5f, 1.0f), 0.0f));
                    break;
                case (3):
                    return (new Color(0.0f, Random.Range(0.5f, 1.0f), 0.0f));
                    break;
                case (4):
                    return (new Color(0.0f, 0.0f, Random.Range(0.5f, 1.0f)));
                    break;
                case (5):
                    return (new Color(0.0f, Random.Range(0.5f, 1.0f), Random.Range(0.5f, 1.0f)));
                    break;
                case (6):
                    return (new Color(Random.Range(0.5f, 1.0f), 0.0f, Random.Range(0.5f, 1.0f)));
                    break;
                default:
                    Debug.Log("ERROR: Invalid color picked out of range");
                    break;
            }
        }
        return new Color(Random.Range(0.5f, 1.0f), Random.Range(0.5f, 1.0f), Random.Range(0.5f, 1.0f));
    }

    public void SetRainbow(bool i)
    {
        rainbow_mode = i;
    }

    public void SetKitty(bool i)
    {
        kitty_mode = i;
    }

    public void SetQuit1(bool i)
    {
        exit1 = i;
    }

    public void SetQuit2(bool i)
    {
        exit2 = i;
    }
}
