using System;
using System.Net.Http;
using System.Threading.Tasks;
using UnityEngine;

public class SheetLoader : MonoBehaviour
{
    [SerializeField] private string _url = "https://docs.google.com/spreadsheets/d/1y0oRbKB5jMAen0686DfgH3IQ0Sx8efMdY3v0DOM2Uto/export?format=tsv&range=A2:F3";
    [SerializeField] private string _savePath = "Assets\\DongModule\\SheetLoader\\05.ScriptableObjects\\Data\\";
    private HttpClient _client = new HttpClient();
    
    #if UNITY_EDITOR

    [ContextMenu("LoadData")]
    public async Task LoadDataAsync()
    {
        try
        {
            string data = await _client.GetStringAsync(_url);
            SheetToData(data);
            Debug.Log("Sheet Loading Complete");
        }
        catch (HttpRequestException e)
        {
            Debug.LogError(e);
        }
    }
    
    private void SheetToData(string tsv)
    {
        string[] row = tsv.Split('\n');
        string[] col = new string[row[0].Split('\t').Length - 1];
        
        for (int i = 0; i < row.Length; ++i)
        {
            col = row[i].Split('\t');
            SheetSO sheet = ScriptableObject.CreateInstance<SheetSO>();

            sheet.Int = int.Parse(col[1]);
            sheet.Float = float.Parse(col[2]);
            sheet.Bool = Convert.ToBoolean(int.Parse(col[3]));
            sheet.String = col[4];
            var colVec = col[5].Split(',');
            sheet.Vector2 = new Vector2Int(int.Parse(colVec[0]), int.Parse(colVec[1]));
            
            string assetPath = $"{_savePath}Sheet{col[0]}.asset";
            UnityEditor.AssetDatabase.CreateAsset(sheet, assetPath);
            UnityEditor.AssetDatabase.SaveAssets();
        }
    }
    
    #endif
}
