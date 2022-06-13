using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SingletonB<T> : MonoBehaviour where T : Singleton<T>
{
    private static T instance;
    public static T Instance
    {
        get { return instance; }
    }
    public static bool IsInitialized
    {
        get { return instance != null; }
    }
    protected virtual void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("[Singleton] trying to instantiate a second instance of a singleton class");
        }
        else
        {
            print("Singleton Set!");
            // instance = (T)this;
        }
    }

    protected virtual void OnDestroy()
    {
        if (instance == this)
        {
            instance = null;
        }
    }
}