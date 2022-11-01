using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer
{
    public Timer(float duration)
    {      
        this.duration = duration;
    }
    private readonly float duration;

    public event Action<float> TimeChanged;
    public IEnumerator Launch(Action onEnded)
    {
        var expiredTime = duration;
        while(expiredTime > 0f)
        {
            expiredTime -= Time.fixedDeltaTime;
            TimeChanged?.Invoke(expiredTime);
            yield return null;
        }

        onEnded?.Invoke();
    }
}