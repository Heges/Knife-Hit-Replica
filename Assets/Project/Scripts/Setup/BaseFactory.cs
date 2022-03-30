using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseFactory : ScriptableObject
{
    protected T CreateInstance<T>(T pref) where T: MonoBehaviour
    {
        T instance = Instantiate(pref);
        return instance;
    }
}
