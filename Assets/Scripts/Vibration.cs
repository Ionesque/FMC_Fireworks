using UnityEngine;

// Pulled from "How to Make a Phone Vibrate!! [Unity Tutorial]
// https://www.youtube.com/watch?v=o6xVLzs1kVk
// by Comp-3 Interactive

public static class Vibration
{
#if UNITY_ANDROID && !UNITY_EDITOR
    public static AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
    public static AndroidJavaObject currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
    public static AndroidJavaObject vibrate = currentActivity.Call<AndroidJavaObject>("getSystemService", "vibrator");
#else
    public static AndroidJavaClass unityPlayer;
    public static AndroidJavaObject currentActivity;
    public static AndroidJavaObject vibrate;
#endif

    public static void VibrateShort(long milliseconds = 250)
    {
        if(IsAndroid())
        {
            vibrate.Call("vibrate", milliseconds);
        }
    }

    public static void Cancel()
    {
        if (IsAndroid()) vibrate.Call("cancel");
    }

    public static bool IsAndroid()
    {
#if UNITY_ANDROID
        return true;
#else
    return false;
#endif
    }
}
