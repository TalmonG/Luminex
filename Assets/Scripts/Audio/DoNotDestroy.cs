using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotDestroy : MonoBehaviour
{
    private void Awake()
    {
        GameObject[] musicOBJ = GameObject.FindGameObjectsWithTag("GameMusic");
        GameObject[] managersOBJ = GameObject.FindGameObjectsWithTag("Managers");
        GameObject[] playerOBJ;
        GameObject[] HUDCanvasOBJ;

        if (musicOBJ.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
        if (managersOBJ.Length > 1)
        {
            Destroy(this.gameObject);
        }
        if (GameObject.FindGameObjectsWithTag("Player")  != null || GameObject.FindGameObjectsWithTag("HUDCanvas") != null)
        {
            playerOBJ = GameObject.FindGameObjectsWithTag("Player");
            HUDCanvasOBJ = GameObject.FindGameObjectsWithTag("HUDCanvas");
            DontDestroyOnLoad(this.gameObject);
            if (playerOBJ.Length > 1)
            {
                Destroy(this.gameObject);
            }
            DontDestroyOnLoad(this.gameObject);
            if (HUDCanvasOBJ.Length > 1)
            {
                Destroy(this.gameObject);
            }
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
