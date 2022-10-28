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
    private List<Resolution> _resolutions = new List<Resolution>();
    private int _resolutionNum;

    private void Awake() 
    {
        _resolutionDropdown = GetComponentInChildren<TMP_Dropdown>();
        _fullscreenBTN = GetComponentInChildren<Toggle>();
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
            option.text = item.width + "x" + item.height;
            _resolutionDropdown.options.Add(option);
        }

        _resolutionDropdown.RefreshShownValue();

        if (!PlayerPrefs.HasKey("IsFirst"))
        {
            _resolutionNum = _resolutions.Count - 1;
            _resolutionDropdown.value = _resolutionNum;
            _fullscreenBTN.isOn = true;

            PlayerPrefs.SetInt("IsFirst", 1);
        }

        OkBtnClick();
    }

    public void DropboxOptionChange(int x)
    {
        _resolutionNum = x;

        OkBtnClick();
    }

    public void FullScreen(bool isFull)
    {
        if (isFull)
            _screenMode = FullScreenMode.FullScreenWindow;
        else
            _screenMode = FullScreenMode.Windowed;

        OkBtnClick();
    }

    private void OkBtnClick()
    {
        Screen.SetResolution(_resolutions[_resolutionNum].width, _resolutions[_resolutionNum].height, _screenMode);
    }
}