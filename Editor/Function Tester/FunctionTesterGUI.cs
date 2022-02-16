
using UnityEditor;
using UnityEngine;

namespace Finlay._3dToolsForLevelDesign
{
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
}