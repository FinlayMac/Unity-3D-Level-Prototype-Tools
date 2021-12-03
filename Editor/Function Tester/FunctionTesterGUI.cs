
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(FunctionTester))]
public class FunctionTesterGUI : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        FunctionTester functionTester = (FunctionTester)target;
        
        if (GUILayout.Button("Activate Function"))
        { functionTester.RunFunction(); }
    }
}
