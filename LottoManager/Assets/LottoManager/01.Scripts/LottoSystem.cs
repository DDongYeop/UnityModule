using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LottoSystem : MonoBehaviour
{
    [SerializeField] private List<TMP_InputField> _inputFields = new List<TMP_InputField>();
    [SerializeField] private int _lengthNum = 45;

    private int[] _mainNum = new int[5] { 0, 0, 0, 0, 0 };
    private int bonusNum;
    private int _index;

    public void ApplicationButtonClick()
    {
        for (int i = 0; i < _mainNum.Length; i++)
            _mainNum[i] = Random.Range(0, _lengthNum + 1);

        for (int i = 0; i < _inputFields.Count; i++)
        {
            for (int j = 0; j < _mainNum.Length; j++)
            {
                if (int.Parse(_inputFields[i].text) == _mainNum[j])
                {
                    _inputFields[i].text = null;
                    _mainNum[j] = -1;
                    _index++;
                }
            }
        }

        if (_index == 5)
        {
            bonusNum = Random.Range(0, _lengthNum + 1);
            for (int i = 0; i < _inputFields.Count; i++)
            {
                if (int.Parse(_inputFields[i].text) == _mainNum[i])
                {

                }
            }
        }
    }

    public void TextEdit(int id)
    {
        if (int.Parse(_inputFields[id].text) >= _lengthNum + 1)
        {
            _inputFields[id].text = null;
        }
    }
}
