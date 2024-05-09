using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResolutionControl : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown ResolutionDropdown;

    private Resolution[] resolutions;
    private List<Resolution> filteredResolutions;

    private float currentRefreshRate;
    private int currentResolutionIndex = 0;
    void Start()
    {
        resolutions = Screen.resolutions;
        filteredResolutions = new List<Resolution>();

        ResolutionDropdown.ClearOptions();
        currentRefreshRate = Screen.currentResolution.refreshRate;

        for(int i = 0; i < resolutions.Length; i++)
        {
            if (resolutions[i].refreshRate == currentRefreshRate)
            {
                filteredResolutions.Add(resolutions[i]);
            }
        }

        List<string> Options = new List<string>();
        for(int i = 0;i<filteredResolutions.Count;i++)
        {
            string resolutionOption = filteredResolutions[i].width+ "x" + filteredResolutions[i].height+ " " +filteredResolutions[i].refreshRate +"Hz"; 
            Options.Add(resolutionOption);
            if (filteredResolutions[i].width == Screen.width && filteredResolutions[i].height == Screen.height)
            {
                currentResolutionIndex = i;
            }
        }


        ResolutionDropdown.AddOptions(Options);
        ResolutionDropdown.value = currentResolutionIndex;
        ResolutionDropdown.RefreshShownValue();
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = filteredResolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, true);
    }

}
