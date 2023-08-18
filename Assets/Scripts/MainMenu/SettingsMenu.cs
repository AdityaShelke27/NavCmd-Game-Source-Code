using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    Resolution[] resolutions;
    public TMPro.TMP_Dropdown ResolutionDropdown;
    public bool isFullScreen = true;
    private void Start()
    {
        resolutions = Screen.resolutions;
        ResolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        int currentResolutionIndex = 0;

        for(int i = 0; i < resolutions.Length; i++)
        {
            options.Add(resolutions[i].ToString());
            if(resolutions[i].ToString() == Screen.currentResolution.ToString())
            {
                currentResolutionIndex = i;
            }
        }

        ResolutionDropdown.AddOptions(options);
        ResolutionDropdown.value = currentResolutionIndex;
        ResolutionDropdown.RefreshShownValue();
        Screen.fullScreen = true;
        Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
    }
    public void changeGraphics(int index)
    {
        QualitySettings.SetQualityLevel(index);
    }

    public void changeResolution(int index)
    {
        string[] resolution = resolutions[index].ToString().Split();
        Screen.SetResolution(Convert.ToInt32(resolution[0]), Convert.ToInt32(resolution[2]), isFullScreen);
    }

    public void changeFullScreen(bool fullScreen)
    {
        isFullScreen = fullScreen;
        Screen.fullScreen = fullScreen;
        if (Screen.fullScreen)
        {
            Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
        }
        else
        {
            Screen.fullScreenMode = FullScreenMode.Windowed;
        }
    }
}
