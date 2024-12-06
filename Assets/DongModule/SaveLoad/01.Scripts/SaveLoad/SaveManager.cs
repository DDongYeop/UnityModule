using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance;

    private string _path;
    private string _fileName = "data.json";
    private List<IDataObserver> _observers = new List<IDataObserver>();

    private SaveData _data;
    
    private void Awake()
    {
        if (Instance != null)
            Debug.LogError("Multiple SaveLoadManager is running");
        Instance = this;
    }

    private void OnEnable()
    {
        Init();
    }

    private void OnDisable()
    {
        SaveData();
    }

    private void Init()
    {
        _path = Path.Combine(Application.persistentDataPath, "savefiles");
        if (!Directory.Exists(_path))
            Directory.CreateDirectory(_path);

        _observers = FindObjectsByType<MonoBehaviour>(FindObjectsSortMode.None).OfType<IDataObserver>().ToList();
        LoadData();
    }

    public void SaveData()
    {
        string filePath = Path.Combine(_path, _fileName);
        if (!File.Exists(_fileName))
            File.Create(filePath);
        
        _data = new SaveData();

        foreach (var observer in _observers)
            observer.WriteData(ref _data);

        string str = JsonUtility.ToJson(_data);
        File.WriteAllText(filePath, str);
    }

    public void LoadData()
    {
        string filePath = Path.Combine(_path, _fileName);
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            _data = JsonUtility.FromJson<SaveData>(json);

            foreach (var observer in _observers)
                observer.ReadData(_data);
        }
        else
            Debug.Log("저장 파일이 없습니다.");
    }
}
