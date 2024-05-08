using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class KeybindScript : MonoBehaviour
{
    private Dictionary<string, KeyCode> Keys = new Dictionary<string, KeyCode>();

    public TextMeshProUGUI right, left,interact , jump, shoot, gravityInvert , DimensionShift;

    private GameObject currentKey;

    private Color32 normal = new Color32(39, 171, 249, 255);
    private Color32 selected = new Color32(239, 116, 36, 255);

    void Start()
    {
        Keys.Add("Right",(KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Right","D")));
        Keys.Add("Left", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Left", "S")));
        Keys.Add("Interact", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Interact", "E")));
        Keys.Add("Jump", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Jump", "Space")));
        Keys.Add("Shoot", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Fire1", "Mouse0")));
       //Keys.Add("GravityInvert", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("GravityInvert", "Q")));
       //Keys.Add("DimensionShift", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("DimensionShift", "R")));

        right.text = Keys["Right"].ToString();
        left.text = Keys["Left"].ToString();
        interact.text = Keys["Interact"].ToString();
        jump.text = Keys["Jump"].ToString();
        shoot.text = Keys["Shoot"].ToString();
        //gravityInvert.text = Keys["GravityInvert"].ToString();
        //DimensionShift.text = Keys["DimensionShift"].ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnGUI()
    {
        if(currentKey != null)
        {
            Event e = Event.current;
            if (e.isKey)
            {
                Keys[currentKey.name] = e.keyCode;
                currentKey.transform.GetChild(0).GetComponent <TextMeshProUGUI>().text = e.keyCode.ToString();
                currentKey.GetComponent<Image>().color = Color.white;
                currentKey = null;
            }
        }
    }

    public void changeKey(GameObject clicked)
    {
        if(currentKey != null)
        {
            currentKey.GetComponent<Image>().color = Color.white;
        }
        currentKey = clicked;
        currentKey.GetComponent<Image>().color = Color.gray;
    }

    public void saveKeys()
    {
        foreach(var key in Keys)
        {
            PlayerPrefs.SetString(key.Key,key.Value.ToString());
            Debug.Log("Hello");
        }
        PlayerPrefs.Save();
    }
}
