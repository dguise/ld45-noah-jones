using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extensions
{
    public static IEnumerator DelayedDo(this MonoBehaviour mb, float seconds, Action callback)
    {
        yield return new WaitForSeconds(seconds);
        callback();
    }
}
