using UnityEngine;
using UnityEditor;

[System.Serializable]
public class EditorGUILayoutToggle : UnityEditor.EditorWindow
{
    bool showBtn = true;

    [MenuItem("Examples/Editor GUILayout Toggle Usage")]
    static void Init()
    {
        EditorGUILayoutToggle window = (EditorGUILayoutToggle)EditorWindow.GetWindow(typeof(EditorGUILayoutToggle), true, "My Empty Window");
        window.Show();
    }

    void OnGUI()
    {
        showBtn = EditorGUILayout.Toggle("Show Button", showBtn);
        if (showBtn)
            if (GUILayout.Button("Close"))
                this.Close();
    }
}