using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Toggleable<T>
{
    public bool toogle = true;
    public T myData;
    public bool GetValue(out T myVar)
    {
        myVar = myData;
        return toogle;
    }
}
