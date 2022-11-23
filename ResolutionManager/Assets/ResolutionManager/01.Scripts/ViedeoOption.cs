using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ViedeoOption : MonoBehaviour
{
    private FullScreenMode _screenMode;
    private TMP_Dropdown _resolutionDropdown;
    private Toggle _fullscreenBTN;
    private TMP_Dropdown _dropdown;
    private List<Resolution> _resolutions = new List<Resolution>();
    private int _resolutionNum;

    private void Awake() 
    {
        _resolutionDropdown = GetComponentInChildren<TMP_Dropdown>();
        _fullscreenBTN = GetComponentInChildren<Toggle>();
        _dropdown = transform.GetChild(0).GetComponent<TMP_Dropdown>();
    }

    private void Start() 
    {
        InitUI();
    }

    private void InitUI()
    {
        _resolutions.AddRange(Screen.resolutions);
        _resolutionDropdown.options.Clear();

        foreach (Resolution item in _resolutions)
        {
            TMP_Dropdown.OptionData option = new TMP_Dropdown.OptionData();
            option.text = item.width + " X " + item.height;
            _resolutionDropdown.options.Add(option);
        }

        _resolutionDropdown.RefreshShownValue();

        if (!PlayerPrefs.HasKey("resolutionNum"))
        {
            PlayerPrefs.SetInt("resolutionNum", _resolutions.Count - 1);
            PlayerPrefs.SetInt("FullScreen", 1);
            _fullscreenBTN.isOn = true;
        }

        if (PlayerPrefs.GetInt("FullScreen") == 1)
            _screenMode = FullScreenMode.FullScreenWindow;
        else if (PlayerPrefs.GetInt("FullScreen") == 0)
            _screenMode = FullScreenMode.Windowed;

        _resolutionNum = PlayerPrefs.GetInt("resolutionNum");
        _dropdown.value = _resolutionNum;
        OkBtnClick();
    }

    public void DropboxOptionChange(int x)
    {
        _resolutionNum = x;
        PlayerPrefs.SetInt("resolutionNum", x);

        OkBtnClick();
    }

    public void FullScreen(bool isFull)
    {
        if (isFull)
        {
            _screenMode = FullScreenMode.FullScreenWindow;
            PlayerPrefs.SetInt("FullScreen", 1);
        }
        else
        {
            _screenMode = FullScreenMode.Windowed;
            PlayerPrefs.SetInt("FullScreen", 0);
        }

        OkBtnClick();
    }

    private void OkBtnClick()
    {
        Screen.SetResolution(_resolutions[_resolutionNum].width, _resolutions[_resolutionNum].height, _screenMode);
    }
}