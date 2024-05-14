using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DimensionManager : MonoBehaviour
{
    // Enable the "NormalDimensionTutorial" GameObject
    public void EnableNormalDimensionTutorial()
    {
        Transform normalDimensionTutorialTransform = transform.Find("NormalDimensionTutorial");

        if (normalDimensionTutorialTransform != null)
        {
            normalDimensionTutorialTransform.gameObject.SetActive(true);
            Debug.Log("EnableNormalDimensionTutorial");
        }
        else
        {
            Debug.LogError("NormalDimensionTutorial GameObject not found!");
        }
    }

    // Disable the "NormalDimensionTutorial" GameObject
    public void DisableNormalDimensionTutorial()
    {
        Transform normalDimensionTutorialTransform = transform.Find("NormalDimensionTutorial");

        if (normalDimensionTutorialTransform != null)
        {
            normalDimensionTutorialTransform.gameObject.SetActive(false);
            Debug.Log("DisableNormalDimensionTutorial");
        }
        else
        {
            Debug.LogError("NormalDimensionTutorial GameObject not found!");
        }
    }

    // Enable the "NormalDimensionLevelOne" GameObject
    public void EnableNormalDimensionLevelOne()
    {
        Transform normalDimensionLevelOneTransform = transform.Find("NormalDimensionLevelOne");

        if (normalDimensionLevelOneTransform != null)
        {
            normalDimensionLevelOneTransform.gameObject.SetActive(true);
            Debug.Log("EnableNormalDimensionLevelOne");
        }
        else
        {
            Debug.LogError("NormalDimensionLevelOne GameObject not found!");
        }
    }

    // Disable the "NormalDimensionLevelOne" GameObject
    public void DisableNormalDimensionLevelOne()
    {
        Transform normalDimensionLevelOneTransform = transform.Find("NormalDimensionLevelOne");

        if (normalDimensionLevelOneTransform != null)
        {
            normalDimensionLevelOneTransform.gameObject.SetActive(false);
            Debug.Log("DisableNormalDimensionLevelOne");
        }
        else
        {
            Debug.LogError("NormalDimensionLevelOne GameObject not found!");
        }
    }

    // Enable the "NormalDimensionLevelTwo" GameObject
    public void EnableNormalDimensionLevelTwo()
    {
        Transform normalDimensionLevelTwoTransform = transform.Find("NormalDimensionLevelTwo");

        if (normalDimensionLevelTwoTransform != null)
        {
            normalDimensionLevelTwoTransform.gameObject.SetActive(true);
        }
        else
        {
            Debug.LogError("NormalDimensionLevelTwo GameObject not found!");
        }
    }

    // Disable the "NormalDimensionLevelTwo" GameObject
    public void DisableNormalDimensionLevelTwo()
    {
        Transform normalDimensionLevelTwoTransform = transform.Find("NormalDimensionLevelTwo");

        if (normalDimensionLevelTwoTransform != null)
        {
            normalDimensionLevelTwoTransform.gameObject.SetActive(false);
        }
        else
        {
            Debug.LogError("NormalDimensionLevelTwo GameObject not found!");
        }
    }

    // Enable the "NormalDimensionLevelThree" GameObject
    public void EnableNormalDimensionLevelThree()
    {
        Transform normalDimensionLevelThreeTransform = transform.Find("NormalDimensionLevelThree");

        if (normalDimensionLevelThreeTransform != null)
        {
            normalDimensionLevelThreeTransform.gameObject.SetActive(true);
        }
        else
        {
            Debug.LogError("NormalDimensionLevelThree GameObject not found!");
        }
    }

    // Disable the "NormalDimensionLevelThree" GameObject
    public void DisableNormalDimensionLevelThree()
    {
        Transform normalDimensionLevelThreeTransform = transform.Find("NormalDimensionLevelThree");

        if (normalDimensionLevelThreeTransform != null)
        {
            normalDimensionLevelThreeTransform.gameObject.SetActive(false);
        }
        else
        {
            Debug.LogError("NormalDimensionLevelThree GameObject not found!");
        }
    }

    // Enable the "NormalDimensionLevelFour" GameObject
    public void EnableNormalDimensionLevelFour()
    {
        Transform normalDimensionLevelFourTransform = transform.Find("NormalDimensionLevelFour");

        if (normalDimensionLevelFourTransform != null)
        {
            normalDimensionLevelFourTransform.gameObject.SetActive(true);
        }
        else
        {
            Debug.LogError("NormalDimensionLevelFour GameObject not found!");
        }
    }

    // Disable the "NormalDimensionLevelFour" GameObject
    public void DisableNormalDimensionLevelFour()
    {
        Transform normalDimensionLevelFourTransform = transform.Find("NormalDimensionLevelFour");

        if (normalDimensionLevelFourTransform != null)
        {
            normalDimensionLevelFourTransform.gameObject.SetActive(false);
        }
        else
        {
            Debug.LogError("NormalDimensionLevelFour GameObject not found!");
        }
    }
    // Enable the "NormalDimensionLevelFive" GameObject
    public void EnableNormalDimensionLevelFive()
    {
        Transform normalDimensionLevelFiveTransform = transform.Find("NormalDimensionLevelFive");

        if (normalDimensionLevelFiveTransform != null)
        {
            normalDimensionLevelFiveTransform.gameObject.SetActive(true);
        }
        else
        {
            Debug.LogError("NormalDimensionLevelFive GameObject not found!");
        }
    }

    // Disable the "NormalDimensionLevelFour" GameObject
    public void DisableNormalDimensionLevelFive()
    {
        Transform normalDimensionLevelFiveTransform = transform.Find("NormalDimensionLevelFive");

        if (normalDimensionLevelFiveTransform != null)
        {
            normalDimensionLevelFiveTransform.gameObject.SetActive(false);
        }
        else
        {
            Debug.LogError("NormalDimensionLevelFive GameObject not found!");
        }
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////
    // Inverted Section
    //////////////////////////////////////////////////////////////////////////////////////////////////////
    ///
    // Enable the "InvertedDimensionTutorial" GameObject
    public void EnableInvertedDimensionTutorial()
    {
        Transform invertedDimensionTutorialTransform = transform.Find("InvertedDimensionTutorial");

        if (invertedDimensionTutorialTransform != null)
        {
            invertedDimensionTutorialTransform.gameObject.SetActive(true);
            Debug.Log("ender");
        }
        else
        {
            Debug.LogError("InvertedDimensionTutorial GameObject not found!");
        }
    }

    // Disable the "InvertedDimensionTutorial" GameObject
    public void DisableInvertedDimensionTutorial()
    {
        Transform invertedDimensionTutorialTransform = transform.Find("InvertedDimensionTutorial");

        if (invertedDimensionTutorialTransform != null)
        {
            invertedDimensionTutorialTransform.gameObject.SetActive(false);
            Debug.Log("DisableInvertedDimensionTutorial");
        }
        else
        {
            Debug.LogError("InvertedDimensionTutorial GameObject not found!");
        }
    }

    // Enable the "InvertedDimensionLevelOne" GameObject
    public void EnableInvertedDimensionLevelOne()
    {
        Transform invertedDimensionLevelOneTransform = transform.Find("InvertedDimensionLevelOne");

        if (invertedDimensionLevelOneTransform != null)
        {
            invertedDimensionLevelOneTransform.gameObject.SetActive(true);
        }
        else
        {
            Debug.LogError("InvertedDimensionLevelOne GameObject not found!");
        }
    }

    // Disable the "InvertedDimensionLevelOne" GameObject
    public void DisableInvertedDimensionLevelOne()
    {
        Transform invertedDimensionLevelOneTransform = transform.Find("InvertedDimensionLevelOne");

        if (invertedDimensionLevelOneTransform != null)
        {
            invertedDimensionLevelOneTransform.gameObject.SetActive(false);
        }
        else
        {
            Debug.LogError("InvertedDimensionLevelOne GameObject not found!");
        }
    }

    // Enable the "InvertedDimensionLevelTwo" GameObject
    public void EnableInvertedDimensionLevelTwo()
    {
        Transform invertedDimensionLevelTwoTransform = transform.Find("InvertedDimensionLevelTwo");

        if (invertedDimensionLevelTwoTransform != null)
        {
            invertedDimensionLevelTwoTransform.gameObject.SetActive(true);
        }
        else
        {
            Debug.LogError("InvertedDimensionLevelTwo GameObject not found!");
        }
    }

    // Disable the "InvertedDimensionLevelTwo" GameObject
    public void DisableInvertedDimensionLevelTwo()
    {
        Transform invertedDimensionLevelTwoTransform = transform.Find("InvertedDimensionLevelTwo");

        if (invertedDimensionLevelTwoTransform != null)
        {
            invertedDimensionLevelTwoTransform.gameObject.SetActive(false);
        }
        else
        {
            Debug.LogError("InvertedDimensionLevelTwo GameObject not found!");
        }
    }

    // Enable the "InvertedDimensionLevelThree" GameObject
    public void EnableInvertedDimensionLevelThree()
    {
        Transform invertedDimensionLevelThreeTransform = transform.Find("InvertedDimensionLevelThree");

        if (invertedDimensionLevelThreeTransform != null)
        {
            invertedDimensionLevelThreeTransform.gameObject.SetActive(true);
        }
        else
        {
            Debug.LogError("InvertedDimensionLevelThree GameObject not found!");
        }
    }

    // Disable the "InvertedDimensionLevelThree" GameObject
    public void DisableInvertedDimensionLevelThree()
    {
        Transform invertedDimensionLevelThreeTransform = transform.Find("InvertedDimensionLevelThree");

        if (invertedDimensionLevelThreeTransform != null)
        {
            invertedDimensionLevelThreeTransform.gameObject.SetActive(false);
        }
        else
        {
            Debug.LogError("InvertedDimensionLevelThree GameObject not found!");
        }
    }

    // Enable the "InvertedDimensionLevelFour" GameObject
    public void EnableInvertedDimensionLevelFour()
    {
        Transform invertedDimensionLevelFourTransform = transform.Find("InvertedDimensionLevelFour");

        if (invertedDimensionLevelFourTransform != null)
        {
            invertedDimensionLevelFourTransform.gameObject.SetActive(true);
        }
        else
        {
            Debug.LogError("InvertedDimensionLevelFour GameObject not found!");
        }
    }

    // Disable the "InvertedDimensionLevelFour" GameObject
    public void DisableInvertedDimensionLevelFour()
    {
        Transform invertedDimensionLevelFourTransform = transform.Find("InvertedDimensionLevelFour");

        if (invertedDimensionLevelFourTransform != null)
        {
            invertedDimensionLevelFourTransform.gameObject.SetActive(false);
        }
        else
        {
            Debug.LogError("InvertedDimensionLevelFour GameObject not found!");
        }
    }
    // Enable the "InvertedDimensionLevelFour" GameObject
    public void EnableInvertedDimensionLevelFive()
    {
        Transform invertedDimensionLevelFiveTransform = transform.Find("InvertedDimensionLevelFive");

        if (invertedDimensionLevelFiveTransform != null)
        {
            invertedDimensionLevelFiveTransform.gameObject.SetActive(true);
        }
        else
        {
            Debug.LogError("InvertedDimensionLevelFive GameObject not found!");
        }
    }

    // Disable the "InvertedDimensionLevelFour" GameObject
    public void DisableInvertedDimensionLevelFive()
    {
        Transform invertedDimensionLevelFiveTransform = transform.Find("InvertedDimensionLevelFive");

        if (invertedDimensionLevelFiveTransform != null)
        {
            invertedDimensionLevelFiveTransform.gameObject.SetActive(false);
        }
        else
        {
            Debug.LogError("InvertedDimensionLevelFive GameObject not found!");
        }
    }
}
