using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public static List<string> Levels { get; private set; }
    public static string PreviousLevel { get; private set; }
    private void OnDestroy()
    {
        PreviousLevel = gameObject.scene.name;
        Levels.Add(PreviousLevel);
    }

    private void Start()
    {

    }
}
