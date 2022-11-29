using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class LottoSystem : MonoBehaviour
{
    [SerializeField] private List<TMP_InputField> _inputFields = new List<TMP_InputField>();
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private TextMeshProUGUI _resultText;
    [SerializeField] private int _lengthNum = 45;

    [Header("Text")]
    [SerializeField] private string _takeARainCheckText = "Take a rain check";
    [SerializeField] private string _5thPlaceText = "5th place";
    [SerializeField] private string _4thPlaceText = "4th place";
    [SerializeField] private string _3rdPlaceText = "3rd place";
    [SerializeField] private string _2ndPlaceText = "2nd place";
    [SerializeField] private string _1stPlaceText = "1st place";

    [Header("Events")]
    [SerializeField] private UnityEvent _takeARainCheckEvent;
    [SerializeField] private UnityEvent _5thPlaceEvent;
    [SerializeField] private UnityEvent _4thPlaceEvent;
    [SerializeField] private UnityEvent _3rdPlaceEvent;
    [SerializeField] private UnityEvent _2ndPlaceEvent;
    [SerializeField] private UnityEvent _1stPlaceEvent;
    

    private int[] _mainNum = new int[6] { 0, 0, 0, 0, 0, 0 };
    private int bonusNum = 0;
    private int _index = 0;
    private int _bonusIndex = 0;

    public void ApplicationButtonClick()
    {
        _index = 0;
        _bonusIndex = 0;

        for (int i = 0; i < _mainNum.Length; i++)
        {
            _mainNum[i] = Random.Range(0, _lengthNum + 1);
            print(_mainNum[i]);
        }
        
        bonusNum = Random.Range(0, _lengthNum + 1);
        
        _resultText.text = $"{_mainNum[0]} {_mainNum[1]} {_mainNum[2]} {_mainNum[3]} {_mainNum[4]} {_mainNum[5]} + {bonusNum}";
        
        for (int i = 0; i < _inputFields.Count; i++)
        {
            for (int j = 0; j < _mainNum.Length; j++)
            {
                if (int.Parse(_inputFields[i].text) == _mainNum[j])
                {
                    _inputFields[i].text = "-1";
                    _mainNum[j] = -1;
                    _index++;
                }
            }
        }

        if (_index == 5)
        {
            for (int i = 0; i < _inputFields.Count; i++)
            {
                if (int.Parse(_inputFields[i].text) == _mainNum[i])
                {
                    _mainNum[i] = -10;
                    _inputFields[i].text = "-1";
                    _bonusIndex++;
                }
            }
        }

        switch (_index)
        {
            case 0:
                _text.text = _takeARainCheckText;
                _takeARainCheckEvent?.Invoke();
                break;
            case 1:
                _text.text = _takeARainCheckText;
                _takeARainCheckEvent?.Invoke();
                break;
            case 2:
                _text.text = _takeARainCheckText;
                _takeARainCheckEvent?.Invoke();
                break;
            case 3:
                _text.text = _5thPlaceText;
                _5thPlaceEvent?.Invoke();
                break;
            case 4:
                _text.text = _4thPlaceText;
                _4thPlaceEvent?.Invoke();
                break;
            case 5:
                if (_bonusIndex == 1)
                {
                    _text.text = _2ndPlaceText;
                    _2ndPlaceEvent?.Invoke();
                }
                else
                {
                    _text.text = _3rdPlaceText;
                    _3rdPlaceEvent?.Invoke();
                }
                break;
            case 6:
                _text.text = _1stPlaceText;
                _1stPlaceEvent?.Invoke();
                break;
        }

        for (int i = 0; i < _inputFields.Count; i++)
            _inputFields[i].text = null;
    }

    public void TextEdit(int id)
    {
        if (int.Parse(_inputFields[id].text) >= _lengthNum + 1)
        {
            _inputFields[id].text = null;
        }
    }
}
