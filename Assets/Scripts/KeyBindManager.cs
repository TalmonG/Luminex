using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class KeyBindManager : MonoBehaviour
{
    private static KeyBindManager instance;

    public static KeyBindManager MyInstance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<KeyBindManager>();
            }
            return instance;
        }
    }

    public Dictionary<string, KeyCode> KeyBinds { get; private set; }

    private string bindName;

    void Start()
    {
        KeyBinds = new Dictionary<string, KeyCode>();

        Bindkey("RIGHT", KeyCode.D);
        Bindkey("LEFT", KeyCode.S);
        Bindkey("INTERACT", KeyCode.E);
        Bindkey("JUMP", KeyCode.Space);
        Bindkey("SHOOT", KeyCode.Mouse0);
        Bindkey("GRAVITYINVERT", KeyCode.Q);
        Bindkey("DIMENSIONSHIFT", KeyCode.R);
    }

    public void Bindkey(string key, KeyCode Keybind)
    {
        Dictionary<string, KeyCode> currentdictionary = KeyBinds;

        if (!currentdictionary.ContainsValue(Keybind))
        {
            currentdictionary.Add(key, Keybind);
            UIManager.MyInstance.updateKeyText(key, Keybind);
        }
        else if (currentdictionary.ContainsValue(Keybind))
        {
            string myKey = currentdictionary.FirstOrDefault(x => x.Value == Keybind).Key;

            currentdictionary[myKey] = KeyCode.None;
            UIManager.MyInstance.updateKeyText(key, KeyCode.None);
        }
        currentdictionary[key] = Keybind;
        UIManager.MyInstance.updateKeyText(key, Keybind);
        bindName = string.Empty;
    }

    public void RebindKey(string key)
    {
        bindName = key;
        KeyBinds[key] = KeyCode.None;
    }
}
