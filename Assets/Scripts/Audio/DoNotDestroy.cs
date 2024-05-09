using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotDestroy : MonoBehaviour
{
    private void Awake()
    {
        GameObject[] musicOBJ = GameObject.FindGameObjectsWithTag("GameMusic");
        if(musicOBJ.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
