using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{
    public Toggle fullscreenTog, vsyncTog;

    public List<ResItem> resolutions = new List<ResItem>();
    private int selectedResoultion;
    public TMP_Text resolutionLabel;

    public AudioMixer theMixer;

    public TMP_Text masterLabel;
    public TMP_Text musicLabel;
    public TMP_Text soundsLabel;


    public Slider masterSlider, musicSlider, soundsSlider;

    // Start is called before the first frame update
    void Start()
    {
        fullscreenTog.isOn = Screen.fullScreen;

        if (QualitySettings.vSyncCount == 0)
        {
            vsyncTog.isOn = false;
        }
        else
        {
            vsyncTog.isOn = true;
        }

        bool foundRes = false;
        for (int i = 0; i < resolutions.Count; i++)
        {
            if (Screen.width == resolutions[i].horizontal && Screen.height == resolutions[i].vertical)
            {
                foundRes = true;
                selectedResoultion = i;

                UpdateResLabel();
            }
        }

        if (!foundRes)
        {
            ResItem newRes = new ResItem();
            newRes.horizontal = Screen.width;
            newRes.vertical = Screen.height;

            resolutions.Add(newRes);
            selectedResoultion = resolutions.Count - 1;

            UpdateResLabel();
        }

        float MasterVol = 0f;
        theMixer.GetFloat("MasterVol", out MasterVol);
        masterSlider.value = MasterVol;

        float MusicVol = 0f;
        theMixer.GetFloat("MusicVol", out MusicVol);
        musicSlider.value = MusicVol;

        float SFXVol = 0f;
        theMixer.GetFloat("SFXVol", out SFXVol);
        soundsSlider.value = SFXVol;

        masterLabel.text = Mathf.RoundToInt(masterSlider.value + 80).ToString();
        musicLabel.text = Mathf.RoundToInt(musicSlider.value + 80).ToString();
        soundsLabel.text = Mathf.RoundToInt(soundsSlider.value + 80).ToString();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ResLeft()
    {
        selectedResoultion--;
        if (selectedResoultion < 0)
        {
            selectedResoultion = 0;
        }

        UpdateResLabel();
    }

    public void ResRight()
    {
        selectedResoultion++;
        if (selectedResoultion > resolutions.Count - 1)
        {
            selectedResoultion = resolutions.Count - 1;
        }

        UpdateResLabel();
    }

    public void UpdateResLabel()
    {
        resolutionLabel.text = resolutions[selectedResoultion].horizontal.ToString() + " x " + resolutions[selectedResoultion].vertical.ToString();
    }

    public void ApplyGraphics()
    {
        //Screen.fullScreen = fullscreenTog.isOn;

        if (vsyncTog.isOn)
        {
            QualitySettings.vSyncCount = 1;

        }
        else
        {
            QualitySettings.vSyncCount = 0;
        }

        Screen.SetResolution(resolutions[selectedResoultion].horizontal, resolutions[selectedResoultion].vertical, fullscreenTog.isOn);
    }

    public void SetMasterVol()
    {
        masterLabel.text = Mathf.RoundToInt(masterSlider.value + 80).ToString();

        theMixer.SetFloat("MasterVol", masterSlider.value);
        PlayerPrefs.SetFloat("MasterVol", masterSlider.value);
    }
    public void SetMusicVol()
    {
        musicLabel.text = Mathf.RoundToInt(musicSlider.value + 80).ToString();

        theMixer.SetFloat("MusicVol", musicSlider.value);
        PlayerPrefs.SetFloat("MusicVol", musicSlider.value);
    }
    public void SetSoundsVol()
    {
        soundsLabel.text = Mathf.RoundToInt(soundsSlider.value + 80).ToString();

        theMixer.SetFloat("SFXVol", soundsSlider.value);
        PlayerPrefs.SetFloat("SFXVol", soundsSlider.value);
    }
}

[System.Serializable]
public class ResItem
{
    public int horizontal, vertical;
}
