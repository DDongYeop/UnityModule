using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SheetLoader))]
public class SheetLoaderEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        SheetLoader sheetLoader = (SheetLoader)target;
        if (GUILayout.Button("Get Sheet Dat"))
            sheetLoader.LoadDataAsync();
    }
}
