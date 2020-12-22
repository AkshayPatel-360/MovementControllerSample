using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ExampleScript : MonoBehaviour
{
    public AnimV2 animV2;
    public AnimationCurve animationCurve;

    public FloatEvent floatEvent;
    public Vector3Event vector3Event;

    public float timeForEffect;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            StartCoroutine(ScaleEffect());
        }
    }



    public void ButtonClick()
    {
        StartCoroutine(ScaleEffect());
    }

    public IEnumerator ScaleEffect()
    {

        float timePassed = 0;
        
        while(  timePassed  < timeForEffect )
        {
            timePassed += Time.deltaTime;

            float y = animationCurve.Evaluate(Mathf.Clamp01(timePassed / timeForEffect));

            floatEvent.Invoke(y);
            vector3Event.Invoke(Vector3.one * y);
            yield return null;

        }

    }
   

    [System.Serializable]
    public class FloatEvent : UnityEvent<float> { }

    [System.Serializable]

    public class Vector3Event : UnityEvent<Vector3> { }



}
