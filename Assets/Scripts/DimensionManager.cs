using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DimensionManager : MonoBehaviour
{
    //referencing
    public PlayerScript playerScript;
    public GameObject normalDimension;
    public GameObject invertedDimension;

    // Start is called before the first frame update
    void Start()
    {

        if (normalDimension != null)
        {
            normalDimension.SetActive(true);
            invertedDimension.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (normalDimension != null && invertedDimension != null)
        {
            if (playerScript.isNormalDimension == true)
            {

                normalDimension.SetActive(true);
                invertedDimension.SetActive(false);

            }


            else if (playerScript.isNormalDimension == false)
            {

                {
                    normalDimension.SetActive(false);
                    invertedDimension.SetActive(true);
                }
            }
        }

    }
}
