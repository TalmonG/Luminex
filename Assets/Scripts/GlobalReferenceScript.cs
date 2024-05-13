using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GlobalReferenceScript : MonoBehaviour
{
    public static GlobalReferenceScript instance { get; set; }

    public TextMeshProUGUI AmmoCounter;
    public TextMeshProUGUI CurrentWeaponText;
    public RawImage[] CurrentWeaponSymbol;
    public Image DimensionChargeAmount;
    public Sprite[] DimensionBubbles;
    public GameObject GravityArrow;
    public Slider Health;
    public Slider Oxygen;
    public GameObject Player;

    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(instance);
        }
        else
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
