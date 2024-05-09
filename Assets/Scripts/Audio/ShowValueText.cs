using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowValueText : MonoBehaviour
{
    // Start is called before the first frame update
    TextMeshProUGUI percentageText;
    void Start()
    {
        percentageText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    public void textUpdate(float value)
    {
        percentageText.text = value + "%";
    }
}
