using UnityEngine;

public class SaveSample : MonoBehaviour, IDataObserver
{
    [SerializeField] private int _saveData;
    
    public void WriteData(ref SaveData data)
    {
        data.SampleData = _saveData;
    }

    public void ReadData(SaveData data)
    {
        _saveData = data.SampleData;
    }
}
