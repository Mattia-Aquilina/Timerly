using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Semplice implementazione del Singleton
public abstract class StaticInstances<T> :MonoBehaviour where T : MonoBehaviour
{
    public static T Instance { get; private set; }
    protected virtual void Awake() => Instance = this as T;

    protected virtual void OnApplicationQuit()
    {
        Instance = null;
        Destroy(gameObject);
    }
}
