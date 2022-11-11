using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SetVolume : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;

    private Slider _matserVolumeSlider;
    private Slider _bgmVolumeSlider;
    private Slider _effectVolumeSlider;

    private void Awake()
    {
        #region 선언된 Sldier를 설정
        _matserVolumeSlider = GameObject.Find("MasterVolumeSlider").GetComponent<Slider>();
        _bgmVolumeSlider = GameObject.Find("BGMVolumeSlider").GetComponent<Slider>();
        _effectVolumeSlider = GameObject.Find("EffectVolumeSlider").GetComponent<Slider>();
        #endregion
    }

    private void Start()
    {
        #region 만약 PlayerPrefs에 저장된 값이 없다면
        if (!PlayerPrefs.HasKey("MasterVolume"))
            PlayerPrefs.SetFloat("MasterVolume", 1f);
        if (!PlayerPrefs.HasKey("BGMVolume"))
            PlayerPrefs.SetFloat("BGMVolume", 1f);
        if (!PlayerPrefs.HasKey("EffectVolume"))
            PlayerPrefs.SetFloat("EffectVolume", 1f);
        #endregion

        #region Slider의 위치를 저장된 값으로 설정
        _matserVolumeSlider.value = PlayerPrefs.GetFloat("MasterVolume");
        _bgmVolumeSlider.value = PlayerPrefs.GetFloat("BGMVolume");
        _effectVolumeSlider.value = PlayerPrefs.GetFloat("EffectVolume");
        #endregion

        #region AudioMixer의 값을 저잗된 값으로 지정
        audioMixer.SetFloat("MasterVolume", Mathf.Log10(PlayerPrefs.GetFloat("MasterVolume")) * 20);
        audioMixer.SetFloat("BGMVolume", Mathf.Log10(PlayerPrefs.GetFloat("BGMVolume")) * 20);
        audioMixer.SetFloat("EffectVolume", Mathf.Log10(PlayerPrefs.GetFloat("EffectVolume")) * 20);
        #endregion
    }

    #region Slider
    public void MasterVolume(float sliderValue)
    {
        audioMixer.SetFloat("MasterVolume", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("MasterVolume", sliderValue);
    }

    public void BGMVolume(float sliderValue)
    {
        audioMixer.SetFloat("BGMVolume", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("BGMVolume", sliderValue);
    }

    public void EffectVolume(float sliderValue)
    {
        audioMixer.SetFloat("EffectVolume", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("EffectVolume", sliderValue);
    }
    #endregion

}
